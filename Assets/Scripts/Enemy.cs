using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public Slider healthBarSlider;

    public LootSpawner lootSpawner;

    void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        
        health -= damage;
        checkDeath();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void checkDeath()
    {
        if (health <= 0)
        {
            Instantiate(lootSpawner, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private float CalculateHealthPercentage()
    {
        return(health / maxHealth);
    }
}
