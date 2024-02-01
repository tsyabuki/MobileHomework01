using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidfirePowerup : PowerupBase
{
    protected override void PowerUp()
    {
        turrentController.FireCooldown = turrentController.FireCooldownStart / 2f;
    }

    protected override void PowerDown()
    {
        turrentController.FireCooldown = turrentController.FireCooldownStart;
    }
}
