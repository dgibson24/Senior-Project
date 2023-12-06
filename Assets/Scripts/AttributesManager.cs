using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public int health;
    public int attack;
    public int armour;
    public float critDamage = 2.0f;
    public float critChance = 0.1f;

    public void TakeDamage(int amount)
    {
        health -= amount - (amount * armour/100);
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if(atm != null)
        {
            float totalDamage = attack;
            if()
            //count RNG chance
            if(Random.Range(0f,1f) < critChance)
            {
                totalDamage *= critDamage;
            }

            atm.TakeDamage(attack);
        }
    }
}
