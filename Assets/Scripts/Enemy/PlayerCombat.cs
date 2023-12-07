using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Attack();
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
        // damage them
    }
}
