using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordSwinger : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("SwordSwing");
            anim.SetBool("SwordSwing", true);
        }
        if(Input.GetMouseButtonDown(1))
        {
            anim.Play("BigSwing");
            anim.SetBool("BigSwordSwing", true);
        }
        anim.SetBool("SwordSwing", false);
        anim.SetBool("BigSwordSwing", false);
    }
}
