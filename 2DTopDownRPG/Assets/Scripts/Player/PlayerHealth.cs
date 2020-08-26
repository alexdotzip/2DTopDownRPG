using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : GenericHealth
{


    public override void Damage(float amountToDamage)
    {
        base.Damage(amountToDamage);

        //For UI - Only for players
        maxHealth.RuntimeValue = currentHealth;


    }
}
