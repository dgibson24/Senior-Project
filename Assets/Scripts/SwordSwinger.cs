using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordSwinger : MonoBehaviour
{
    Animator anim;
    AudioSource lunge;

    void Start()
    {
        anim = GetComponent<Animator>();
        lunge = GetComponent<AudioSource>();
    }
    void Update()
    {
        anim.SetBool("SwordSwing", true);
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("SwordSwing");
            lunge.Play();       
        }
        if(Input.GetMouseButtonDown(1))
        {
            anim.Play("BigSwing");
            lunge.Play();
        }
        anim.SetBool("SwordSwing", false);
    }
}
