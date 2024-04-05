using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;

    private PlayerControlls controls;

    private CharacterController characterController;

    private Animator animator;

    [Header("Movement info")]
    private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float turnSpeed;
    private float verticalVelocity;

    public Vector2 moveInput {  get; private set; }
    private Vector3 movementDirection;

    private bool isRunning;


    private void Start()
    {
        player = GetComponent<Player>();

        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        speed = walkSpeed;

        AssignInputEvents();
    }

    private void Update()
    {
        ApplyMovement();
        ApplyRotation();
        AnimatorControllers();
    }

    private void AnimatorControllers()
    {
        float xVelocity = Vector3.Dot(movementDirection.normalized, transform.right); // transform.right = (1,0,0)
        float zVelocity = Vector3.Dot(movementDirection.normalized, transform.forward); // transform.forward = (0,0,1)

        animator.SetFloat("xVelocity", xVelocity, .1f, Time.deltaTime);
        animator.SetFloat("zVelocity", zVelocity, .1f, Time.deltaTime);

        bool playRunAnimation = isRunning && movementDirection.magnitude > 0;
        animator.SetBool("isRunning", playRunAnimation);
    }

    private void ApplyRotation()
    {
        Vector3 lookingDirection = player.aim.GetMousePosition() - transform.position;
        lookingDirection.y = 0f;
        lookingDirection.Normalize();

        Quaternion desiredRotation = Quaternion.LookRotation(lookingDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, turnSpeed * Time.deltaTime);
    }

    private void ApplyMovement()
    {
        movementDirection = new Vector3(moveInput.x, 0, moveInput.y);
        ApplyGravity();

        if (movementDirection.magnitude > 0)
        {
            characterController.Move(movementDirection * Time.deltaTime * speed);
        }
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded == false)
        {
            verticalVelocity = verticalVelocity - 9.81f * Time.deltaTime; // 9.81 is a default value for gravity
            movementDirection.y = verticalVelocity;
        }
        else
        {
            verticalVelocity = -.5f;
        }

    }

    private void AssignInputEvents()
    {
        controls = player.controls;

        controls.Character.Movement.performed += context => moveInput = context.ReadValue<Vector2>();
        controls.Character.Movement.canceled += context => moveInput = Vector2.zero;



        controls.Character.Run.performed += context =>
        {
            speed = runSpeed;
            isRunning = true;
        };
        controls.Character.Run.canceled += context =>
        {
            speed = walkSpeed;
            isRunning = false;
        };
    }
}
