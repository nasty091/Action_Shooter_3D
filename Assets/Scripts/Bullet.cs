using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float impactForce;

    private BoxCollider cd;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private TrailRenderer trailRenderer;


    [SerializeField] private GameObject bulletImpactFX;

    private Vector3 startPosition;
    private float flyDistance;
    private bool bulletDisabled;

    private LayerMask allyLayerMask;

    protected virtual void Awake()
    {
        cd = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void BulletSetup(LayerMask allyLayerMask, float flyDistance = 100, float impactForce = 100)
    {
        this.allyLayerMask = allyLayerMask;
        this.impactForce = impactForce;

        bulletDisabled = false;
        cd.enabled = true;
        meshRenderer.enabled = true;

        trailRenderer.Clear();
        trailRenderer.time = .25f;
        startPosition = transform.position;
        this.flyDistance = flyDistance + .5f; // .5f is a length of tip of laser (check method UpdateAimVisuals())
    }

    protected virtual void Update()
    {
        FadeTrailIfNeeded();

        DisableBulletIfNeeded();

        ReturnToPoolIfNeeded();

    }

    protected void ReturnToPoolIfNeeded()
    {
        if (trailRenderer.time < 0)
            ReturnBulletToPool();
    }

    protected void DisableBulletIfNeeded()
    {
        if (Vector3.Distance(startPosition, transform.position) > flyDistance && !bulletDisabled)
        {
            cd.enabled = false;
            meshRenderer.enabled = false;
            bulletDisabled = true;
        }
    }

    protected void FadeTrailIfNeeded()
    {
        if (Vector3.Distance(startPosition, transform.position) > flyDistance - 1.5f)
            trailRenderer.time -= 4 * Time.deltaTime;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(FriendlyFire() == false)
        {
            // Use a bitwise AND to check if the collision layer is in allyLayerMask
            if ((allyLayerMask & (1 << collision.gameObject.layer)) > 0)
            {
                ReturnBulletToPool(10);
                return;
            }
        }

        CreateImpactFX();
        ReturnBulletToPool();

        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        damagable?.TakeDamage();

        Enemy_Shield shield = collision.collider.GetComponent<Enemy_Shield>();

        if (shield != null)
        {
            shield.ReduceDurability();
            return;
        }

        ApplyBulletImpactToEnemy(collision);
    }

    private void ApplyBulletImpactToEnemy(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            Vector3 force = rb.velocity.normalized * impactForce;
            Rigidbody hitRigibody = collision.collider.attachedRigidbody;

            enemy.BulletImpact(force, collision.contacts[0].point, hitRigibody);
        }
    }

    protected void ReturnBulletToPool(float delay = 0) => ObjectPool.instance.ReturnObject(gameObject, delay);

    protected void CreateImpactFX()
    {
        GameObject newImpactFX = ObjectPool.instance.GetObject(bulletImpactFX, transform);
        ObjectPool.instance.ReturnObject(newImpactFX, 1);
    }

    private bool FriendlyFire() => GameManager.instance.friendlyFire;
}
