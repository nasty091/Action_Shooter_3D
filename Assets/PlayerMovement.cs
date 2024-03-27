using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControlls controlls;

    private CharacterController characterController;

    [Header("Movement info")]
    [SerializeField] private float walkSpeed;
    private Vector3 moveDirection;

    private float verticalVelocity;

    [Header("Aim info")]
    [SerializeField] private Transform aim;
    [SerializeField] private LayerMask aimLayerMask;
    private Vector3 lookingDirection;

    private Vector2 moveInput;
    private Vector2 aimInput;

    private void Awake()
    {
        controlls = new PlayerControlls();

        controlls.Character.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        controlls.Character.Movement.canceled += context => moveInput = Vector2.zero;

        controlls.Character.Aim.performed += context => aimInput = context.ReadValue<Vector2>();
        controlls.Character.Aim.canceled += context => aimInput = Vector2.zero;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyMovement();
        AimTowardsMouse();
    }

    private void AimTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(aimInput);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, aimLayerMask))
        {
            lookingDirection = hitInfo.point - transform.position;
            lookingDirection.y = 0f;
            lookingDirection.Normalize();

            transform.forward = lookingDirection;

            aim.position = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
        }
    }

    private void ApplyMovement()
    {
        moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        ApplyGravity();

        if (moveDirection.magnitude > 0)
        {
            characterController.Move(moveDirection * Time.deltaTime * walkSpeed);
        }
    }

    private void ApplyGravity()
    {
        if(characterController.isGrounded == false)
        {
            verticalVelocity = verticalVelocity - 9.81f * Time.deltaTime; // 9.81 is a default value for gravity
            moveDirection.y = verticalVelocity;
        }
        else
        {
            verticalVelocity = -.5f;
        }

    }

    private void OnEnable()
    {
        controlls.Enable();
    }

    private void OnDisable()
    {
        controlls.Disable();
    }
}
