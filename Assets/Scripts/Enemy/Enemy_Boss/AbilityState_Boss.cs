using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityState_Boss : EnemyState
{
    private Enemy_Boss enemy;

    public AbilityState_Boss(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
        enemy = enemyBase as Enemy_Boss;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.flamethrowDuration;

        enemy.agent.isStopped = true;
        enemy.agent.velocity = Vector3.zero;
        enemy.bossVisuals.EnableWeaponTrail(true);

    }

    public override void Update()
    {
        base.Update();

        enemy.FaceTarget(enemy.player.position);

        if (stateTimer < 0)
            DiscableFlamethrower();

        if (triggerCalled)
            stateMachine.ChangeState(enemy.moveState);
    }

    public void DiscableFlamethrower()
    {
        if (enemy.flamethrowActive == false)
            return;

        enemy.ActivateFlamethrower(false);
    }

    public override void AbilityTrigger()
    {
        base.AbilityTrigger();
        enemy.ActivateFlamethrower(true);
        enemy.bossVisuals.DischargeBatteries();
        enemy.bossVisuals.EnableWeaponTrail(false);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetAbilityOnCooldown();
        enemy.bossVisuals.ResetBatteries();
    }
}
