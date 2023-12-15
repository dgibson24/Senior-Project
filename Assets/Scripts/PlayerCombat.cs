using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform LightAttackPoint;
    public Transform HeavyAttackPoint;

    public LayerMask enemyLayers;
    public float attackRange = .5f;
    public float attackDamage = 1f;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    private void Update()
    {   
        if(Time.time>= nextAttackTime)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Light_Attack");
        }
        else if (Input.GetMouseButton(1))
        {
            animator.SetTrigger("Heavy_Attack");
        }

        // detect enemies that 'Hero' collided with after anim
        Collider[] hitEnemies1 = Physics.OverlapSphere(LightAttackPoint.position, attackRange, enemyLayers);
        Collider[] hitEnemies2 = Physics.OverlapSphere(HeavyAttackPoint.position, attackRange, enemyLayers);

        // damage them
        foreach (Collider enemy in hitEnemies1)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        // damage them
        foreach (Collider enemy in hitEnemies2)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (LightAttackPoint == null)
            return;
        if (HeavyAttackPoint == null)
            return;

        Gizmos.DrawWireSphere(LightAttackPoint.position, attackRange);
        Gizmos.DrawWireSphere(HeavyAttackPoint.position, attackRange);
    }
}
