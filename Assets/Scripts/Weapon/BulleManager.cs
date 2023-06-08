using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulleManager : MonoBehaviour
{
    public BulletData bulletData;
    int collisions;
    PhysicMaterial physics_mat;
    float lifeBullet;
    public GameObject explosive;
    private void Start()
    { 
        lifeBullet = bulletData.maxLifetime;
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bulletData.bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity
        bulletData.rb.useGravity = bulletData.useGravity;
    }

    private void Update()
    {
        //When to explode:
        //if (collisions > bulletData.maxCollisions) Explode();

        //Count down lifetime
        if(bulletData.hasLifeTime){
            bulletData.maxLifetime -= Time.deltaTime;
            if (bulletData.maxLifetime <= 0) Explode();
        }
        
    }
    private void Explode()
    {
        //Instantiate explosion
        if (bulletData.explosion != null && explosive == null){
            explosive = Instantiate(bulletData.explosion, transform.position, Quaternion.identity);
        }

        //Check for enemies 
        Collider[] enemies = Physics.OverlapSphere(transform.position, bulletData.explosionRange, bulletData.enemyLayer);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Add explosion force (if enemy has a rigidbody)
            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(bulletData.explosionForce, transform.position, bulletData.explosionRange);
        }
        Invoke("Delay", 0.05f);
    }
    private void Delay()
    {
        Destroy(explosive);
        bulletData.maxLifetime = lifeBullet;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Don't count collisions with other bullets
        if (collision.collider.CompareTag("Bullet")) return;

        //Count up collisions
        collisions++;

        //Explode if bullet hits an enemy directly and explodeOnTouch is activated
        if (collision.collider.CompareTag("Enemy") && bulletData.explodeOnTouch) Explode();
    }
}
