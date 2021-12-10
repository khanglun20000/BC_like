using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : UnitBehaviour
{
    [SerializeField] int currentHealth;
    int maxHealth;

    private void Start()
    {
        maxHealth = unitStat.maxHealth.GetValue();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        print(currentHealth);
        if(currentHealth <= 0)
        {
            GetComponent<Destroy>().DoDestroy();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
