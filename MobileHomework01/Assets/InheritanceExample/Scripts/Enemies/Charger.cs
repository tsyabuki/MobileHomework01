using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [SerializeField] private GameObject _droppedBuff;

    protected override void OnHit()
    {
        //Increase move speed on hit
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        base.Kill();

        Instantiate(_droppedBuff, transform.position, Quaternion.identity);
    }
}
