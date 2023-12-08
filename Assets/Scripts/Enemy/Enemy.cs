using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // play hurt anim (if applicable)

        if(currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log("Enemy Died!");

            // die animation (if applicable)

            // disable the enemy

        }
    }
}
