using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public new string name;
    public float maxDistance;
    public float fireRate;
    public GameObject bullet;
    [Header("Bullet Force")] 
    public float shootForce;
    public float upwardForce;

    [Header("Weapon Stats")] 
    public float timeBetweenShooting;
    public float spread;
    public float reloadTime;
    public float timeBetweenShoots;
    public int magazineSize;
    public int bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft;
    public int bulletShot;

    [Header("Bools")]
    public bool shooting;
    public bool readyToShoot;
    public bool reloading;
}
