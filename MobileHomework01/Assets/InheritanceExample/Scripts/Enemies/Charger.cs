using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    protected override void OnHit()
    {
        //Increase move speed on hit
        MoveSpeed *= 2;
    }
}
