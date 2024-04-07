using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerControlls controls { get; private set; } // (read-only) This variable is available for reading but not available for any changes 
    public PlayerAim aim { get; private set; } // (read-only) 
    public PlayerMovement movement { get; private set; }
    public PlayerWeaponController weapon {  get; private set; }
    private void Awake()
    {
        controls = new PlayerControlls();
        aim = GetComponent<PlayerAim>();
        movement = GetComponent<PlayerMovement>();
        weapon = GetComponent<PlayerWeaponController>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
