using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Enemy")
        {
            if(collision.name == "Player")
            {
                Player.instance.DealDamage(damage);
            }
            Destroy(gameObject);
        }
    } 
}
