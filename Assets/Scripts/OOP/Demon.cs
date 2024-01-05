using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    [SerializeField] private int damageToTake;
    private void Update()
    {
        TakeDamage(damageToTake);
    }
}
