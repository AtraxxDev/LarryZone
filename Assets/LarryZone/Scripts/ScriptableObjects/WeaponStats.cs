using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new weapon stats", menuName = "WeaponStats")]
public class WeaponStats : ScriptableObject
{
    public float rateOfFire;
    public float cooldown;
    public int numOfInstances;
    public GameObject bulletPrefab;
}
