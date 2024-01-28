using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weaponPrefabs = new GameObject[3];
    private Vector3 mouseTarget;
    private float[] timePassed = new float[3];
    private int currentWeaponType;
    public Transform pivotTransform;
    [SerializeField] private GameObject currentWeapon;
    [SerializeField] private GameObject currentBulletPrefab;
    public WeaponStats[] weaponStats = new WeaponStats[3];

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            timePassed[i] = 50f;
        }

        SetWeapon(0);
    }

    void Update()
    {

        // Point towards mouse;
        mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTarget.z = 0f;
        transform.right = mouseTarget - transform.position;

        // Shooting
        for (int i = 0; i < 3; i++)
        {
            timePassed[i] += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && timePassed[currentWeaponType] >= weaponStats[currentWeaponType].cooldown)
        {
            StartCoroutine(InstantiateDelay());
            timePassed[currentWeaponType] = 0f;
        }
        InstantiateDelay();

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentWeaponType != 0)
        {
            SetWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currentWeaponType != 1)
        {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && currentWeaponType != 2)
        {
            SetWeapon(2);
        }
    }

    private void SetWeapon(int weaponType)
    {
        weaponType = Mathf.Clamp(weaponType, 0, weaponPrefabs.Length - 1);

        // Destroy the current weapon
        Destroy(currentWeapon);

        // Instantiate the new weapon prefab
        currentWeapon = Instantiate(weaponPrefabs[weaponType], pivotTransform.position, transform.rotation);
        currentWeapon.transform.SetParent(pivotTransform);

        // Set the current bullet prefab associated with the current weapon
        currentBulletPrefab = weaponStats[weaponType].bulletPrefab;

        // Disable the Bullet component if it exists in the new weapon
        BulletMovement bulletComponent = currentWeapon.GetComponent<BulletMovement>();
        if (bulletComponent != null)
        {
            bulletComponent.enabled = false;
        }

        // Update the currentWeaponType variable with the correct value
        currentWeaponType = weaponType;
    }

    IEnumerator InstantiateDelay()
    {
        BulletMovement instance;
        Vector3 shootingTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootingTarget.z = 0;
        Vector3 shootingOrigin = pivotTransform.position;

        for (int i = 0; i < weaponStats[currentWeaponType].numOfInstances; i++)
        {
            // Use the current bullet prefab associated with the current weapon
            instance = Instantiate(currentBulletPrefab, shootingOrigin, Quaternion.identity).GetComponent<BulletMovement>();

            if (instance != null)
            {
                instance.ShootTowards(shootingTarget);
            }

            yield return new WaitForSeconds(weaponStats[currentWeaponType].rateOfFire);
        }
    }
}