using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public enum BossWeaponType { Flamethrower, Hammer}

public class Enemy_Boss : Enemy
{
    [Header("Boss details")]
    public BossWeaponType bossWeaponType;
    public float actionCooldown = 10;
    public float attackRange;

    [Header("Ability")]
    public float minAbilityDistance;
    public float abilityCooldown;
    private float lastTimeUsedAbility;

    [Header("Flamethrower")]
    public float flamwDamageCooldown;
    public ParticleSystem flamethrower;
    public float flamethrowDuration;
    public bool flamethrowActive {  get; private set; }

    [Header("Hammer")]
    public GameObject activationPrefab;
    [SerializeField] private float hammerCheckRadius;


    [Header("Jump attack")]
    public float jumpAttackCooldown = 10;
    private float lastTimeJumped;
    public float travelTimeToTarget = 1;
    public float minJumpDistanceRequired;
    [Space]
    public float impactRadius = 2.5f;
    public float impactPower = 5; // how far (X and Z axis) object will fly when it get explosion
    public Transform impactPoint;
    [SerializeField] private float upforceMultiplier = 10;// how high (Y axis) object will fly when it get explosion
    [Space]
    [SerializeField] private LayerMask whatIsIgnore;

    [Header("Attack")]
    [SerializeField] private Transform[] damagePoints;
    [SerializeField] private float attackCheckRadius;
    [SerializeField] private GameObject meleeAttackFx;

    public IdleState_Boss idleState {  get; private set; }
    public MoveState_Boss moveState { get; private set; }
    public AttackState_Boss attackState { get; private set; }   
    public JumpAttackState_Boss jumpAttackState { get; private set; }
    public AbilityState_Boss abilityState { get; private set; }
    public DeadState_Boss deadState { get; private set; }
    
    public Enemy_BossVisuals bossVisuals { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        bossVisuals = GetComponent<Enemy_BossVisuals>();

        idleState = new IdleState_Boss(this, stateMachine, "Idle");
        moveState = new MoveState_Boss(this, stateMachine, "Move");
        attackState = new AttackState_Boss(this, stateMachine, "Attack");
        jumpAttackState = new JumpAttackState_Boss(this, stateMachine, "JumpAttack");
        abilityState = new AbilityState_Boss(this, stateMachine, "Ability");
        deadState = new DeadState_Boss(this, stateMachine, "Idle"); // Idle is just a placeholder we use ragdoll
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();  

        stateMachine.currentState.Update();

        if(ShouldEnterBattleMode()) 
            EnterBattleMode();

        MeleeAttackCheck(damagePoints, attackCheckRadius, meleeAttackFx);
    }

    public override void Die()
    {
        base.Die();

        if (stateMachine.currentState != deadState)
            stateMachine.ChangeState(deadState);
    }

    public override void EnterBattleMode()
    {
        if (inBattleMode)
            return;

        base.EnterBattleMode();
        stateMachine.ChangeState(moveState);
    }

    public void ActivateFlamethrower(bool activate)
    {
        flamethrowActive = activate;

        if (!activate)
        {
            flamethrower.Stop();
            anim.SetTrigger("StopFlamethrower");
            return;
        }

        var mainModule = flamethrower.main;
        var extraModule = flamethrower.transform.GetChild(0).GetComponent<ParticleSystem>().main;

        mainModule.duration = flamethrowDuration;
        extraModule.duration = flamethrowDuration;

        flamethrower.Clear();
        flamethrower.Play();
    }

    public void ActivateHammer()
    {
        GameObject newActivation = ObjectPool.instance.GetObject(activationPrefab, impactPoint);

        ObjectPool.instance.ReturnObject(newActivation, 1);

        MassDamage(damagePoints[0].position, hammerCheckRadius);
    }

    public bool CanDoAbility()
    {
        bool playerWithinDistance = Vector3.Distance(transform.position, player.position) < minAbilityDistance;

        if(playerWithinDistance == false)
            return false;

        if(Time.time > lastTimeUsedAbility + abilityCooldown)
        {
            return true;
        }

        return false;
    }

    public void SetAbilityOnCooldown() => lastTimeUsedAbility = Time.time;

    public void JumpImpact()
    {
        Transform impactPoint = this.impactPoint;

        if (impactPoint == null)
            impactPoint = transform;

        MassDamage(impactPoint.position, impactRadius);
    }

    private void MassDamage(Vector3 impactPoint, float impactRadius)
    {
        HashSet<GameObject> uniqeEntites = new HashSet<GameObject>();
        Collider[] colliders = Physics.OverlapSphere(impactPoint, impactRadius, ~whatIsAlly);

        foreach (Collider hit in colliders)
        {
            IDamagable damagable = hit.GetComponent<IDamagable>();

            if (damagable != null)
            {
                GameObject rootEntity = hit.transform.root.gameObject;

                if (uniqeEntites.Add(rootEntity) == false)
                    continue;

                damagable.TakeDamage();
            }

            ApplyPhysicalForceTo(impactPoint, impactRadius, hit);
        }
    }

    private void ApplyPhysicalForceTo(Vector3 impactPoint, float impactRadius, Collider hit)
    {
        Rigidbody rb = hit.GetComponent<Rigidbody>();

        if (rb != null)
            rb.AddExplosionForce(impactPower, impactPoint, impactRadius, upforceMultiplier, ForceMode.Impulse); // ForceMode.Impulse: how far object will fly when it get explosion based on it's mass
    }

    public bool CanDoJumpAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < minJumpDistanceRequired)
            return false;

        if(Time.time > lastTimeJumped + jumpAttackCooldown && IsPlayerInClearSight())
        {
            return true;
        }

        return false;
    }

    public void SetJumpAttackOnCooldown() => lastTimeJumped = Time.time;

    public bool IsPlayerInClearSight()
    {
        Vector3 myPos = transform.position + new Vector3(0, 1.5f, 0);
        Vector3 playerPos = player.position + Vector3.up;
        Vector3 directionToPlayer = (playerPos - myPos).normalized;

        if(Physics.Raycast(myPos, directionToPlayer, out RaycastHit hit, 1000, ~whatIsIgnore))
        {
            if(hit.transform == player || hit.transform.parent == player) 
                return true;
        }

        return false;
    }

    public bool PlayerInAttackRange() => Vector3.Distance(transform.position, player.position) < attackRange;

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(transform.position, attackRange);

        if(player != null)
        {
            Vector3 myPos = transform.position + new Vector3(0, 1.5f, 0);
            Vector3 playerPos = player.position + Vector3.up;

            Gizmos.color = Color.yellow;

            Gizmos.DrawLine(myPos, playerPos);
        }

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, minAbilityDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minJumpDistanceRequired);

        if(damagePoints.Length > 0)
        {
            foreach(var damagePoint in damagePoints)
            {
                Gizmos.DrawWireSphere(damagePoint.position, attackCheckRadius);
            }

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(damagePoints[0].position, hammerCheckRadius);
        }
    }
}
