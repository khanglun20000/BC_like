using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerController : MonoBehaviour
{
    [SerializeField] SummonerData summonerData;

    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;

    private void Start()
    {
        maxHealth = summonerData.maxHealth;
        currentHealth = maxHealth;
        GetComponent<SpriteRenderer>().sprite = summonerData.avatar;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
}
