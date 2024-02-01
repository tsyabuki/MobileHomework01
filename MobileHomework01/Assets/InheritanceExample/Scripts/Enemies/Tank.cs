using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] private float _stopTimeMaximum;
    private float _stopTimeCurrent = 0;
    private float _moveReturnSpeed;

    protected override void OnHit()
    {
        if(MoveSpeed != 0)
        {
            _moveReturnSpeed = MoveSpeed;
        }
        MoveSpeed = 0f;
        _stopTimeCurrent = _stopTimeMaximum;
    }

    private void Start()
    {
        _moveReturnSpeed = MoveSpeed;
    }

    private void Update()
    {
        if (_stopTimeCurrent > 0)
        {
            _stopTimeCurrent -= Time.deltaTime;
        }
        else
        {
            MoveSpeed = _moveReturnSpeed;
            _stopTimeCurrent = -1f;
        }
    }
}
