using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Grenade : MonoBehaviour
{
    [SerializeField] private GameObject explosionFx;
    [SerializeField] private float impactRadius; // how far (X and Z axis) object will fly when it get explosions
    [SerializeField] private float upwardsMultiplier = 1; // how high object will fly when it get explosion
    private float impactPower;
    private Rigidbody rb;
    private float timer;

    private LayerMask allyLayerMask;
    private bool canExplode = true;

    private int grenadeDamage;

    private void Awake() => rb = GetComponent<Rigidbody>();

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0 && canExplode)
            Explode();
    }

    private void Explode()
    {
        canExplode = false;

        PlayExplosionFx();

        HashSet<GameObject> uniqeEntities = new HashSet<GameObject>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, impactRadius);

        foreach (Collider hit in colliders)
        {
            IDamagable damagable = hit.GetComponent<IDamagable>();

            if (damagable != null)
            {
                if (IsTargetValid(hit) == false)
                    continue;

                GameObject rootEntity = hit.transform.root.gameObject;
                if (uniqeEntities.Add(rootEntity) == false)
                    continue;

                damagable.TakeDamage(grenadeDamage);
            }

            ApplyPhysicalForceTo(hit);
        }
    }

    private void ApplyPhysicalForceTo(Collider hit)
    {
        Rigidbody rb = hit.GetComponent<Rigidbody>();

        if (rb != null)
            rb.AddExplosionForce(impactPower, transform.position, impactRadius, upwardsMultiplier, ForceMode.Impulse); // ForceMode.Impulse: how far object will fly when it get explosion based on it's mass
    }

    private void PlayExplosionFx()
    {
        GameObject newFx = ObjectPool.instance.GetObject(explosionFx, transform);
        ObjectPool.instance.ReturnObject(newFx, 1);
        ObjectPool.instance.ReturnObject(gameObject);
    }

    public void SetupGrenade(LayerMask allyLayerMask, Vector3 target, float timeToTarget, float countdown, float impactPower, int grenadeDamage)
    {
        canExplode = true;

        this.grenadeDamage = grenadeDamage;
        this.allyLayerMask = allyLayerMask;
        rb.velocity = CalculateLaunchVelocity(target, timeToTarget);
        timer = countdown + timeToTarget;
        this.impactPower = impactPower;
    }

    private bool IsTargetValid(Collider collider)
    {
        //If friendly fire is enabled, all colliders are valid targets
        if (GameManager.instance.friendlyFire)
            return true;

        //If collider is on allyLater, target is not valid
        if((allyLayerMask.value & (1 << collider.gameObject.layer)) > 0)
            return false;

        return true;
    }

    private Vector3 CalculateLaunchVelocity(Vector3 target, float timeToTarget)
    {
        Vector3 direction = target - transform.position;
        Vector3 directionXZ = new Vector3(direction.x, 0, direction.z);

        Vector3 velocityXZ = directionXZ / timeToTarget;

        float velocityY =
            (direction.y - (Physics.gravity.y * Mathf.Pow(timeToTarget, 2)) / 2) / timeToTarget;

        Vector3 launchVelocity = velocityXZ + Vector3.up * velocityY;

        return launchVelocity;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, impactRadius);
    }
}
