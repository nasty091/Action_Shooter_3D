using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BoxCollider cd;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private TrailRenderer trailRenderer;


    [SerializeField] private GameObject bulletImpactFX;


    private Vector3 startPosition;
    private float flyDistance;
    private bool bulletDisabled;

    private void Awake()
    {
        cd = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void BulletSetup(float flyDistance)
    {
        bulletDisabled = false;
        cd.enabled = true;
        meshRenderer.enabled = true;

        trailRenderer.time = .25f;
        startPosition = transform.position;
        this.flyDistance = flyDistance + .5f; // .5f is a length of tip of laser (check method UpdateAimVisuals())
    }

    private void Update()
    {
        FadeTrailIfNeeded();

        DisableBulletIfNeeded();

        ReturnToPoolIfNeeded();

    }

    private void ReturnToPoolIfNeeded()
    {
        if (trailRenderer.time < 0)
            ObjectPool.instance.ReturnBullet(gameObject);
    }

    private void DisableBulletIfNeeded()
    {
        if (Vector3.Distance(startPosition, transform.position) > flyDistance && !bulletDisabled)
        {
            cd.enabled = false;
            meshRenderer.enabled = false;
            bulletDisabled = true;
        }
    }

    private void FadeTrailIfNeeded()
    {
        if (Vector3.Distance(startPosition, transform.position) > flyDistance - 1.5f)
            trailRenderer.time -= 4 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CreateImpactFX(collision);
        ObjectPool.instance.ReturnBullet(gameObject);
    }

    private void CreateImpactFX(Collision collision)
    {
        if (collision.contacts.Length > 0) // Find the first contact when bullet touch the other object
        {
            ContactPoint contact = collision.contacts[0];

            GameObject newImpactFX = Instantiate(bulletImpactFX, contact.point, Quaternion.LookRotation(contact.normal));

            Destroy(newImpactFX, 1f);
        }
    }
}
