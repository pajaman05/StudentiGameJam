using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth - damage >= 0)
            currentHealth -= damage;
        else 
            currentHealth = 0;
        if(currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    public void TakeHeal(float heal)
    {
        if (currentHealth + heal <= maxHealth)
            currentHealth += heal;
        else 
            currentHealth = maxHealth;
    }

    private void Update()
    {

    }
}
