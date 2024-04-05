using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Player player;
    private PlayerControlls controls;

    [Header("Aim info")]
    [Range(.5f, 1f)]
    [SerializeField] private float minCameraDistance = 1.5f;
    [Range(1f, 3f)]
    [SerializeField] private float maxCameraDistance = 4f;

    [Range(3f, 5f)]
    [SerializeField] private float aimSensitivity = 5f;

    [SerializeField] private Transform aim;
    [SerializeField] private LayerMask aimLayerMask;
    private Vector3 lookingDirection;
    private Vector2 aimInput;

    private void Start()
    {
        player = GetComponent<Player>();

        AssignInputEnvents();
    }

    private void Update()
    {
        aim.position = Vector3.Lerp(aim.position, DesiredAimPosition(), aimSensitivity * Time.deltaTime);
    }

    private Vector3 DesiredAimPosition()
    {
        float actualMaxCameraDistance = player.movement.moveInput.y < -.5f ? minCameraDistance : maxCameraDistance;

        Vector3 desiredAimPosition = GetMousePosition();
        Vector3 aimDirection = (desiredAimPosition - transform.position).normalized;    

        float distanceToDesiredPosition = Vector3.Distance(transform.position, desiredAimPosition);
        float clampedDistance = Mathf.Clamp(distanceToDesiredPosition, minCameraDistance, actualMaxCameraDistance);
            
        desiredAimPosition = transform.position + aimDirection * clampedDistance;
        desiredAimPosition.y = transform.position.y + 1;

        return desiredAimPosition;
    }

    public Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(aimInput);

        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, aimLayerMask))
        {
            return hitInfo.point;
        }

        return Vector3.zero;
    }

    private void AssignInputEnvents()
    {
        controls = player.controls;

        controls.Character.Aim.performed += context => aimInput = context.ReadValue<Vector2>();
        controls.Character.Aim.canceled += context => aimInput = Vector2.zero;
    }
}
