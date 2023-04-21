using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float health;
    public float maxHealth;

    public GameObject player;
    public Text healthText;
    public Slider healthSlider;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        health = maxHealth;
        SetHealthUI();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        checkDeath();
        SetHealthUI();
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
        SetHealthUI();
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
            Destroy(player);
        }
    }

    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }

    private void SetHealthUI()
    {
        healthSlider.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + "/" + Mathf.Ceil(maxHealth).ToString();
    }
}
