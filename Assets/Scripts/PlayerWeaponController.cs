using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private Player player;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform gunPoint;

    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform aim;

    private void Start()
    {
        player = GetComponent<Player>();

        player.controls.Character.Fire.performed += context => Shoot();
    }

    private void Shoot()
    {

        GameObject newBullet = Instantiate(bulletPrefab, gunPoint.position, Quaternion.LookRotation(gunPoint.forward));

        newBullet.GetComponent<Rigidbody>().velocity = BulletDirection() * bulletSpeed;

        Destroy(newBullet, 10);

        GetComponentInChildren<Animator>().SetTrigger("Fire");
    }

    public Vector3 BulletDirection()
    {
        Vector3 direction = (aim.position - gunPoint.position).normalized;

        if(player.aim.CanAimPrecisely() == false && player.aim.Target() == null)
            direction.y = 0f;

        weaponHolder.LookAt(aim);
        gunPoint.LookAt(aim);

        return direction;
    }

    public Transform GunPoint() => gunPoint;

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(weaponHolder.position, weaponHolder.position + weaponHolder.forward* 25);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(gunPoint.position, gunPoint.position + BulletDirection() * 25);
    //}
}
