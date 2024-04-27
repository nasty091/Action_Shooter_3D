using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine stateMachine;

    public EnemyState idleState {  get; private set; }
    public EnemyState moveState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new EnemyStateMachine();

        idleState = new EnemyState(this, stateMachine, "Idle");
        moveState = new EnemyState(this, stateMachine, "Move");

        stateMachine.Initialize(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
    }
}
