using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Player player;
    private PlayerControlls controls;

    [Header("Aim Visual - Laser")]
    [SerializeField] private LineRenderer aimLaser;

    [Header("Aim control")]
    [SerializeField] private Transform aim;

    [SerializeField] private bool isAimingPrecisely;
    [SerializeField] private bool isLookingToTarget;

    [Header("Camera control")]
    [SerializeField] private Transform cameraTarget;
    [Range(.5f, 1f)]
    [SerializeField] private float minCameraDistance = 1.5f;
    [Range(1f, 3f)]
    [SerializeField] private float maxCameraDistance = 4f;

    [Range(3f, 5f)]
    [SerializeField] private float cameraSensitivity = 5f;

    [Space]

    [SerializeField] private LayerMask aimLayerMask;

    private Vector2 mouseInput;
    private RaycastHit lastKnownMouseHit;

    private void Start()
    {
        player = GetComponent<Player>();

        AssignInputEnvents();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            isAimingPrecisely = !isAimingPrecisely;

        if(Input.GetKeyDown(KeyCode.L))
            isLookingToTarget = !isLookingToTarget;

        UpdateAimVisuals();
        UpdateAimPosition();
        UpdateCameraPosition();
    }

    private void UpdateAimVisuals()
    {
        Transform gunPoint = player.weapon.GunPoint();
        Vector3 laserDirection = player.weapon.BulletDirection();

        float laserTipLength = .5f;
        float gunDistance = 4f;

        Vector3 endPoint = gunPoint.position + laserDirection * gunDistance;

        if(Physics.Raycast(gunPoint.position, laserDirection, out RaycastHit hit, gunDistance))
        {
            endPoint = hit.point;
            laserTipLength = 0f;
        }

        aimLaser.SetPosition(0, gunPoint.position);
        aimLaser.SetPosition(1, endPoint);
        aimLaser.SetPosition(2, endPoint + laserDirection * laserTipLength);
    }

    private void UpdateAimPosition()
    {
        Transform target = Target();

        if(target != null && isLookingToTarget)
        {
            if(target.GetComponent<Renderer>() != null) 
                aim.position = target.GetComponent<Renderer>().bounds.center;
            else
                aim.position = target.position;

            return;
        }

        aim.position = GetMouseHitInfo().point;

        if (!isAimingPrecisely)
            aim.position = new Vector3(aim.position.x, transform.position.y + 1, aim.position.z);
    }


    public Transform Target()
    {
        Transform target = null;

        if(GetMouseHitInfo().transform.GetComponent<Target>() != null)
        {
            target = GetMouseHitInfo().transform;
        }

        return target;
    }
    public Transform Aim() => aim;

    public bool CanAimPrecisely() => isAimingPrecisely;

    public RaycastHit GetMouseHitInfo()
    {
        Ray ray = Camera.main.ScreenPointToRay(mouseInput);

        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, aimLayerMask))
        {
            lastKnownMouseHit = hitInfo;
            return hitInfo;
        }

        return lastKnownMouseHit;
    }

    #region Camera Region
    private void UpdateCameraPosition()
    {
        cameraTarget.position = Vector3.Lerp(cameraTarget.position, DesiredCameraPosition(), cameraSensitivity * Time.deltaTime);
    }
    private Vector3 DesiredCameraPosition()
    {
        float actualMaxCameraDistance = player.movement.moveInput.y < -.5f ? minCameraDistance : maxCameraDistance;

        Vector3 desiredCameraPosition = GetMouseHitInfo().point;
        Vector3 aimDirection = (desiredCameraPosition - transform.position).normalized;    

        float distanceToDesiredPosition = Vector3.Distance(transform.position, desiredCameraPosition);
        float clampedDistance = Mathf.Clamp(distanceToDesiredPosition, minCameraDistance, actualMaxCameraDistance);
            
        desiredCameraPosition = transform.position + aimDirection * clampedDistance;
        desiredCameraPosition.y = transform.position.y + 1;

        return desiredCameraPosition;
    }
    #endregion

    private void AssignInputEnvents()
    {
        controls = player.controls;

        controls.Character.Aim.performed += context => mouseInput = context.ReadValue<Vector2>();
        controls.Character.Aim.canceled += context => mouseInput = Vector2.zero;
    }
}
