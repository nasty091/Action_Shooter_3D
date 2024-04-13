using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private Player player;
    private const float REFERENCE_BULLET_SPEED = 20f; // This is the default speed from which our mass formula is derived.

    [SerializeField] private Weapon currentWeapon;    

    [Header("Bullet details")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform gunPoint;


    [SerializeField] private Transform weaponHolder;

    [Header("Inventory")]
    [SerializeField] private int maxSlots = 2;
    [SerializeField] public List<Weapon> weaponSlots;

    private void Start()
    {
        player = GetComponent<Player>();

        AssignInputEvents();

        currentWeapon.ammo = currentWeapon.maxAmmo;
    }

    #region Slots managment - Pickup\Equip\Drop Weapon
    private void EquipWeapon(int i)
    {
        currentWeapon = weaponSlots[i];
    }

    public void PickupWeapon(Weapon newWeapon)
    {
        if(weaponSlots.Count >= maxSlots)
            return;

        weaponSlots.Add(newWeapon);
    }

    private void DropWeapon()
    {
        if (weaponSlots.Count <= 1)
            return;

        weaponSlots.Remove(currentWeapon);

        currentWeapon = weaponSlots[0];
    }
    #endregion

    private void Shoot()
    {
        if(currentWeapon.CanShoot() == false)
            return;

        GameObject newBullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.LookRotation(gunPoint.forward));

        Rigidbody rbNewBullet = newBullet.GetComponent<Rigidbody>();

        rbNewBullet.mass = REFERENCE_BULLET_SPEED / bulletSpeed;
        rbNewBullet.velocity = BulletDirection() * bulletSpeed;

        Destroy(newBullet, 10);

        GetComponentInChildren<Animator>().SetTrigger("Fire");
    }

    public Vector3 BulletDirection()
    {
        Transform aim = player.aim.Aim();

        Vector3 direction = (aim.position - gunPoint.position).normalized;

        if(player.aim.CanAimPrecisely() == false && player.aim.Target() == null)
            direction.y = 0f;

        //weaponHolder.LookAt(aim);
        //gunPoint.LookAt(aim); TODO: find a better place for it

        return direction;
    }

    public Transform GunPoint() => gunPoint;

    #region Input Events
    private void AssignInputEvents()
    {
        PlayerControlls controls = player.controls;

        controls.Character.Fire.performed += context => Shoot();

        controls.Character.EquipSlot1.performed += context => EquipWeapon(0);
        controls.Character.EquipSlot2.performed += context => EquipWeapon(1);

        controls.Character.DropCurrentWeapon.performed += context => DropWeapon();
    }
    #endregion

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(weaponHolder.position, weaponHolder.position + weaponHolder.forward* 25);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(gunPoint.position, gunPoint.position + BulletDirection() * 25);
    //}
}
