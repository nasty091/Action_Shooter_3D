using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AttackState_Boss : EnemyState
{
    private Enemy_Boss enemy;

    public AttackState_Boss(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Boss;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.anim.SetFloat("AttackAnimIndex", Random.Range(0, 2)); // We have 2 attacks with index 0 and 1
        enemy.agent.isStopped = true;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            if(enemy.PlayerInAttackRange())
                stateMachine.ChangeState(enemy.idleState);
            else
                stateMachine.ChangeState(enemy.moveState);
        }
    }
}
