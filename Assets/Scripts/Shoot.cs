using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float damage;

    public float bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    { 
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbullet = bullet.GetComponent<Rigidbody2D>();
        rbullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullet.GetComponent<Projectile>().damage = damage;
    }

}
