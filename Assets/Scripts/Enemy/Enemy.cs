using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Idle info")]
    public float idleTime;

    public EnemyStateMachine stateMachine;

    protected virtual void Awake()
    {
        stateMachine = new EnemyStateMachine();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }
}
