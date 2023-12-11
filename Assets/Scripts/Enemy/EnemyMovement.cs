using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    private GameObject Player, Sword;

    public float speed;
    Transform target;
    public Rigidbody rb;
    public float in_range = 1;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        Sword = Player.transform.Find("Sword/ItemHold").gameObject;
    }

    private void Update()
    {
        FollowPlayer();
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


    
}
