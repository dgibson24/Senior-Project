using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    private Animator animator;
    public int radius = 1;
    [SerializeField]
    public int damage;

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

    public void Damage(int damage)
    {   
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach(Collider nearbyObject in colliders)
        {
            if(nearbyObject.tag == "Player" )
            {
                PlayerManager.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
