using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class OutflankingStalking : Stalking
{
    protected Timer _resetOutflankTimer;
    protected Timer _outflankingTimer;
    protected bool _canOutflank;
    private float time;
    private float lastDistance;
    private Vector2 _startOutflankingPosition;
    private Vector2 _endOutflankingPosition;
    private int _lastLayer;
    [SerializeField] protected float resetOutflankDelay;
    [SerializeField] protected float outflankingDuration;

    protected override void Awake()
    {
        base.Awake();
        _resetOutflankTimer = new Timer(this);
        _outflankingTimer = new Timer(this);
        _resetOutflankTimer.TimeIsOver += PrepareOutflank;
        _outflankingTimer.TimeIsOver += StopOutflank;
        outflankingDuration = UnityEngine.Random.Range(2, 4);
    }

    private void PrepareOutflank()
    {
        _startOutflankingPosition = transform.position;
        float distance = stalkingTarget.position.x - transform.position.x;
        _endOutflankingPosition = new Vector2(stalkingTarget.position.x + distance, transform.position.y); ;
        _canOutflank = true;
        time = 0;
        _lastLayer = gameObject.layer;
        _outflankingTimer.StartTimer(outflankingDuration);
    }

    private void StopOutflank()
    {
        _canOutflank = false;
        gameObject.layer = _lastLayer;
        _resetOutflankTimer.StartTimer(resetOutflankDelay);
    }

    protected override void FixedUpdate()
    {
        float distance = Math.Abs(transform.position.x - stalkingTarget.position.x);
        if(distance <= allowedDistance)
        {
            if(lastDistance > allowedDistance) _resetOutflankTimer.RestartTimer(resetOutflankDelay);
            else if(_canOutflank) Outflank();
        }
        else 
            Move();
        lastDistance = distance;
    }

    protected virtual void Outflank()
    {
        gameObject.layer = 8;
        time = (time + Time.fixedDeltaTime)/outflankingDuration;
        var newPosition = Vector2.Lerp(_startOutflankingPosition, _endOutflankingPosition, time);
        _rigidbody2D.MovePosition(newPosition);
    }
}
