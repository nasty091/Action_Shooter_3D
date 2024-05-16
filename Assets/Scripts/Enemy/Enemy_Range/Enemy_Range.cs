using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CoverPerk { Unavailable, CanTakeCover, CanTakeAndChangeCover}
public enum UnStoppablePerk { Unavailable, Unstoppable}
public enum GrenadePerk { Unavailable, CanThrowGrenade}

public class Enemy_Range : Enemy
{
    //public List<CoverPoint> collectedCoverPoints2 = new List<CoverPoint>();
    [Header("Enemy perks")]
    public CoverPerk coverPerk;
    public UnStoppablePerk unstoppablePerk;
    public GrenadePerk grenadePerk;

    [Header("Grenade perk")]
    public float grenadeCooldown;
    private float lastTimeGrenadeThrown = -10;

    [Header("Advance perk")]
    public float advanceSpeed;
    public float advanceStoppingDistance;
    public float advanceDuration = 2.5f;

    [Header("Cover system")]
    public float minCoverTime;
    public float safeDistance;

    public CoverPoint currentCover { get; private set; }
    public CoverPoint lastCover { get; private set; }

    [Header("Weapon details")]
    public float attackDelay;
    public Enemy_RangeWeaponType weaponType;
    public Enemy_RangeWeaponData weaponData;

    [Space]
    public Transform gunPoint;
    public Transform weaponHolder;
    public GameObject bulletPrefab;

    [Header("Aim details")]
    public float slowAim = 4;
    public float fastAim = 20;
    public Transform aim;
    public Transform playersBody;
    public LayerMask whatToIgnore;

    [SerializeField] List<Enemy_RangeWeaponData> availableWeaponData;

    #region States
    public IdleState_Range idleState {  get; private set; }
    public MoveState_Range moveState { get; private set; }  
    public BattleState_Range battleState { get; private set; }
    public RunToCoverState_Range runToCoverState { get; private set; }
    public AdvancePlayerState_Range advancePlayerState { get; private set; }
    public ThrowGrenadeState_Range throwGrenadeState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new IdleState_Range(this, stateMachine, "Idle");
        moveState = new MoveState_Range(this, stateMachine, "Move");
        battleState = new BattleState_Range(this, stateMachine, "Battle");
        runToCoverState = new RunToCoverState_Range(this, stateMachine, "Run");
        advancePlayerState = new AdvancePlayerState_Range(this, stateMachine, "Advance");
        throwGrenadeState = new ThrowGrenadeState_Range(this, stateMachine, "ThrowGrenade");
    }

    protected override void Start()
    {
        base.Start();

        playersBody = player.GetComponent<Player>().playerBody;
        aim.parent = null;

        InitializePerk();

        stateMachine.Initialize(idleState);
        visuals.SetupLook();
        SetupWeapon();
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }

    public bool CanThrowGrenade()
    {
        if(grenadePerk == GrenadePerk.Unavailable)
            return false;

        if(Vector3.Distance(player.transform.position, transform.position) < safeDistance)
            return false;

        if (Time.time > grenadeCooldown + lastTimeGrenadeThrown)
            return true;

        return false;
    }

    public void ThrowGrenade()
    {
        lastTimeGrenadeThrown = Time.time;
        Debug.Log("THROWING GRENADE!");
    }

    protected override void InitializePerk()
    {
        if (IsUnstoppable())
        {
            advanceSpeed = 1;
            anim.SetFloat("AdvanceAnimIndex", 1); // 1 is slow walk animation
        }
    }

    public override void EnterBattleMode()
    {
        if (inBattleMode)
            return;

        base.EnterBattleMode();

        if (CanGetCover())
            stateMachine.ChangeState(runToCoverState);
        else
            stateMachine.ChangeState(battleState);
    }

    #region Cover System

    public bool CanGetCover()
    {
        if(coverPerk == CoverPerk.Unavailable)
            return false;

        currentCover = AttempToFindCover()?.GetComponent<CoverPoint>();

        if(lastCover != currentCover && currentCover != null)
            return true;

        Debug.LogWarning("No cover found");
        return false;
    }

    private Transform AttempToFindCover()
    {
        List<CoverPoint> collectedCoverPoints = new List<CoverPoint>();

        foreach(Cover cover in CollectNearByCovers())
        {
            collectedCoverPoints.AddRange(cover.GetValidCoverPoints(transform));
        }
        //collectedCoverPoints2 = collectedCoverPoints;
        CoverPoint closestCoverPoint = null;
        float shortestDistance = float.MaxValue;

        foreach(CoverPoint coverPoint in collectedCoverPoints)
        {
            float currentDistance = Vector3.Distance(transform.position, coverPoint.transform.position);
            if(currentDistance < shortestDistance)
            {
                closestCoverPoint = coverPoint;
                shortestDistance = currentDistance;
            }
        }

        if(closestCoverPoint != null )
        {
            lastCover?.SetOccupied(false);
            lastCover = currentCover;

            currentCover = closestCoverPoint;
            currentCover.SetOccupied(true);

            return currentCover.transform;
        }

        return null;
    }

    private List<Cover> CollectNearByCovers()
    {
        float coverRadiusCheck = 30;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, coverRadiusCheck);
        List<Cover> collectedCovers = new List<Cover>();

        foreach(Collider collider in hitColliders)
        {
            Cover cover = collider.GetComponent<Cover>();

            if (cover != null && collectedCovers.Contains(cover) == false) 
                collectedCovers.Add(cover);
        }

        return collectedCovers;
    }
    
    #endregion

    public void FireSingleBullet()
    {
        anim.SetTrigger("Shoot");

        Vector3 bulletsDirection = (aim.position - gunPoint.position).normalized;

        GameObject newBullet = ObjectPool.instance.GetObject(bulletPrefab);
        newBullet.transform.position = gunPoint.position;
        newBullet.transform.rotation = Quaternion.LookRotation(gunPoint.forward);

        newBullet.GetComponent<Enemy_Bullet>().BulletSetup();

        Rigidbody rbNewBullet = newBullet.GetComponent<Rigidbody>();

        Vector3 bulletDirectionWithSpread = weaponData.ApplyWeaponSpread(bulletsDirection);

        rbNewBullet.mass = 20 / weaponData.bulletSpeed;
        rbNewBullet.velocity = bulletDirectionWithSpread * weaponData.bulletSpeed;
    }
    public void SetupWeapon()
    {
        List<Enemy_RangeWeaponData> fileredData = new List<Enemy_RangeWeaponData>();

        foreach(var weaponData in availableWeaponData)
        {
            if(weaponData.weaponType == weaponType)
                fileredData.Add(weaponData);
        }

        if (fileredData.Count > 0)
        {
            int random = Random.Range(0, fileredData.Count);
            weaponData = fileredData[random];
        }
        else
            Debug.Log("No available weapon data was found");

        gunPoint = visuals.currentWeaponModel.GetComponent<Enemy_RangeWeaponModel>().gunPoint;
    }

    #region Enemy's aim region
    
    public void UpdateAimPosition()
    {
        float aimSpeed = IsAimOnPlayer() ? fastAim : slowAim;
        aim.position = Vector3.MoveTowards(aim.position, playersBody.position, aimSpeed * Time.deltaTime);
    }

    public bool IsAimOnPlayer()
    {
        float distanceAimToPlayer = Vector3.Distance(aim.position, player.position);

        return distanceAimToPlayer < 2;
    }

    public bool IsSeeingPlayer()
    {
        Vector3 myPosition = transform.position + Vector3.up;
        Vector3 directionToPlayer = playersBody.position - myPosition;

        if(Physics.Raycast(myPosition, directionToPlayer, out RaycastHit hit, Mathf.Infinity, ~whatToIgnore)) //~whatToIgnore means what layer will be ignored
        {
            if(hit.transform == player)
            {
                UpdateAimPosition();
                return true;
            }
        }
        return false;
    }
    
    #endregion

    public bool IsUnstoppable() => unstoppablePerk == UnStoppablePerk.Unstoppable;

    //Draw a line from enemy to player
    //protected override void OnDrawGizmos()
    //{
    //    base.OnDrawGizmos();
    //    Gizmos.DrawLine(transform.position, player.transform.position);
    //}
}
