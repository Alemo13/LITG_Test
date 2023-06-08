using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Bullet Data")]
public class BulletData : ScriptableObject
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask enemyLayer;

    //Stats
    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;
    public bool hasLifeTime;

    //Damage
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;

    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

}
