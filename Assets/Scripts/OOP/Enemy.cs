using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health = 100;
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Take Damage:" + damageAmount);
        return;
    }

    public virtual void DealDamage(int damageToDeal)
    {
        Debug.Log("No virtual");
    }
}
