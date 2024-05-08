using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    protected virtual void Awake()
    {
        cd = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void BulletSetup(float flyDistance = 100, float impactForce = 100)
    {
        this.impactForce = impactForce;

        bulletDisabled = false;
        cd.enabled = true;
        meshRenderer.enabled = true;

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
        CreateImpactFX(collision);
        ReturnBulletToPool();

        Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
        Enemy_Shield shield = collision.collider.GetComponent<Enemy_Shield>();

        if(shield != null)
        {
            shield.ReduceDurability();
            return;
        }

        if (enemy != null)
        {
            Vector3 force = rb.velocity.normalized * impactForce;
            Rigidbody hitRigibody = collision.collider.attachedRigidbody;

            enemy.GetHit();
            enemy.DeathImpact(force, collision.contacts[0].point, hitRigibody);

        }
    }

    protected void ReturnBulletToPool() => ObjectPool.instance.ReturnObject(gameObject);

    protected void CreateImpactFX(Collision collision)
    {
        if (collision.contacts.Length > 0) // Find the first contact when bullet touch the other object
        {
            ContactPoint contact = collision.contacts[0];

            GameObject newImpactFX = ObjectPool.instance.GetObject(bulletImpactFX);
            newImpactFX.transform.position = contact.point;

            ObjectPool.instance.ReturnObject(newImpactFX, 1);
        }
    }
}
