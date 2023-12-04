using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm1;
    public AttributesManager enemyAtm2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F9))
        {
            playerAtm.DealDamage(enemyAtm1.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            playerAtm.DealDamage(enemyAtm2.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.F11))
        {
            enemyAtm1.DealDamage(playerAtm.gameObject);
        }

        if(Input.GetKeyDown(KeyCode.F12))
        {
            enemyAtm2.DealDamage(playerAtm.gameObject);
        }
    }
}
