using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform player;
    public float damage;
    public float projectileSpeed;
    public float cooldown;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.position;
            Vector2 direction = (targetPos - myPos).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            bullet.GetComponent<EnemyProjectile>().damage = damage;
            StartCoroutine(ShootPlayer());
        }
    }
}
