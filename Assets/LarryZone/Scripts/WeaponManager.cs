using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weaponPrefabs = new GameObject[3];
    private Vector3 mouseTarget;
    private float[] timePassed = new float[3];
    private int weaponType;
    public Transform pivotTransform;
    private GameObject currentWeapon;
    public WeaponStats[] weaponStats = new WeaponStats[3];



    private void Start()
    {
        for (int i = 0; i < 3; i++) {
            timePassed[i] = 50f;
        }
        currentWeapon = Instantiate(weaponPrefabs[0], pivotTransform.position, transform.rotation);
        currentWeapon.transform.SetParent(pivotTransform);
    }

    // Update is called once per frame
    void Update()
    {
        Bullet bullet_;

        //Point towards mouse;
        mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTarget.z = 0f;
        transform.right = mouseTarget - transform.position;


        //Shooting
        for (int i = 0; i < 3; i++)
        {
            timePassed[i] += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && timePassed[weaponType] >= weaponStats[weaponType].cooldown)
        {
            StartCoroutine(InstantiateDelay(weaponPrefabs[weaponType], weaponStats[weaponType]));
            timePassed = 0f;
        }
        InstantiateDelay(weaponPrefabs[weaponType], weaponStats[weaponType]);



        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponType != 0)
        {
            weaponType = 0;
            Destroy(currentWeapon);
            currentWeapon = Instantiate(weaponPrefabs[weaponType], pivotTransform.position, transform.rotation);
            currentWeapon.transform.SetParent(pivotTransform);
            bullet_ = currentWeapon.GetComponent<Bullet>();
            if (bullet_ != null)
            {
                bullet_.enabled = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weaponType != 1)
        {
            weaponType = 1;
            Destroy(currentWeapon);
            currentWeapon = Instantiate(weaponPrefabs[weaponType], pivotTransform.position, transform.rotation);
            currentWeapon.transform.SetParent(pivotTransform);
            bullet_ = currentWeapon.GetComponent<Bullet>();
            if(bullet_ != null)
            {
                bullet_.enabled = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && weaponType != 2)
        {
            weaponType = 2;
            currentWeapon = Instantiate(weaponPrefabs[weaponType], pivotTransform.position, transform.rotation);
            currentWeapon.transform.SetParent(pivotTransform);
            bullet_ = currentWeapon.GetComponent<Bullet>();
            if (bullet_ != null)
            {
                bullet_.enabled = false;
            }
        }
    }


    IEnumerator InstantiateDelay(GameObject weapon, WeaponStats weaponStats)
    {
        BulletMovement instance;
        Vector3 shootingTarget = new Vector3();
        shootingTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootingTarget.z = 0;
        Vector3 shootingOrigin = pivotTransform.position;
        for (int i = 0; i < weaponStats.numOfInstances; i++) {
            instance = Instantiate(weapon, shootingOrigin, Quaternion.identity).GetComponent<BulletMovement>();
            if (instance != null)
            {
                instance.ShootTowards(shootingTarget);
            }
            yield return new WaitForSeconds(weaponStats.rateOfFire);
        }
    }
}
