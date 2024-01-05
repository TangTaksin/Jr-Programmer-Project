using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    [SerializeField] private int damageAmount;
    private void Update()
    {
        TakeDamage(damageAmount);
        DealDamage(1);
    }

    public override void DealDamage(int amount)
    {
        Debug.Log(amount);

    }
}
