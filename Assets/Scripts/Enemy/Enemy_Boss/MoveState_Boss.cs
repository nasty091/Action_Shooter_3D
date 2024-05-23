using UnityEngine;

public class MoveState_Boss : EnemyState
{
    private Enemy_Boss enemy;
    private Vector3 destination;

    private float actionTimer;

    public MoveState_Boss(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Boss;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.agent.speed = enemy.walkSpeed;
        enemy.agent.isStopped = false;

        destination = enemy.GetPatrolDestination();
        enemy.agent.SetDestination(destination);

        actionTimer = enemy.actionCooldown;
    }

    public override void Update()
    {
        base.Update();

        actionTimer -= Time.deltaTime;
        enemy.FaceTarget(GetNextPathPoint());

        if (enemy.inBattleMode)
        {
            Vector3 playerPos = enemy.player.position;

            enemy.agent.SetDestination(playerPos);

            if(actionTimer < 0)
            {
                PerformRandomAction();
            }
            else if (enemy.PlayerInAttackRange())
                stateMachine.ChangeState(enemy.attackState);

        }
        else
        {
            if (Vector3.Distance(enemy.transform.position, destination) < .25f)
                stateMachine.ChangeState(enemy.idleState);
        }
    }

    private void PerformRandomAction()
    {
        actionTimer = enemy.actionCooldown;

        if(Random.Range(0, 2) == 0) // rolls number from 0 to 1
        {
            if (enemy.CanDoAbility()) 
                stateMachine.ChangeState(enemy.abilityState);
        }
        else
        {
            if(enemy.CanDoJumpAttack())
                stateMachine.ChangeState(enemy.jumpAttackState);
        }
    }
}
