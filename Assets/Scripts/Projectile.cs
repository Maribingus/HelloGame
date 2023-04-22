using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public GameObject effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "Player")
        {
            if(collision.GetComponent<Enemy>() != null)
            {
                collision.GetComponent<Enemy>().DealDamage(damage);
            }
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
