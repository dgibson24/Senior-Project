using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    GameObject Hero = GameObject.FindGameObjectWithTag("Hero");

    GameObject sword = GameObject.FindGameObjectWithTag("Sword");

    public float speed;
    Transform target;
    public Rigidbody rb;
    public float in_range = 1;
    AttributesManager health;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Hero").transform;
        health = enemy.GetComponent<DamageTester>().enemyAtm2;
    }

    private void Update()
    {
        FollowPlayer();
        CheckHealth();
    }

    public void FollowPlayer()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist < in_range)
        {
            if(this.gameObject.Equals("SmallEnemy"))
            {
                speed = 3f;
            }
            else
            {
                speed = 1f;
            }

            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rb.MovePosition(pos);
            transform.LookAt(target);
        }
    }
    public AttributesManager GetHealth()
    {
        return health;
    }

    public void CheckHealth()
    {
        if (GetHealth() <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    
}
