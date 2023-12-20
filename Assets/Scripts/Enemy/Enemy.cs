using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Damage");

        if(currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            animator.SetBool("isDead", true);

            gameObject.SetActive(false);
        }
    }
}
