using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossVisuals : MonoBehaviour
{
    private Enemy_Boss enemy;

    [SerializeField] private float landingOffset = 1;
    [SerializeField] private ParticleSystem landingZoneFx;
    [SerializeField] private GameObject[] weaponTrails;

    [Header("Batteries")]     
    [SerializeField] private GameObject[] batteries;
    [SerializeField] private float initialBatteryScaleY = .2f;

    private float dischargeSpeed;
    private float rechargeSpeed;

    private bool isRecharging;

    private void Awake()
    {
        enemy = GetComponent<Enemy_Boss>();

        landingZoneFx.transform.parent = null;
        landingZoneFx.Stop();

        ResetBatteries();
        EnableWeaponTrail(false);
    }

    private void Update()
    {
        UpdateBatteriesScale();
    }

    public void EnableWeaponTrail(bool active)
    {
        if(weaponTrails.Length <= 0)
        {
            Debug.LogWarning("No weapon trails assigned");
            return;
        }

        foreach (var trail in weaponTrails)
        {
            trail.gameObject.SetActive(active);
        }
    }

    public void PlaceLandingZone(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        Vector3 offset = dir.normalized * landingOffset; 

        landingZoneFx.transform.position = target + offset;
        landingZoneFx.Clear();

        var mainModule = landingZoneFx.main;
        mainModule.startLifetime = enemy.travelTimeToTarget * 2;

        landingZoneFx.Play();
    }

    private void UpdateBatteriesScale()
    {
        if (batteries.Length <= 0)
            return;

        foreach(GameObject battery in batteries)
        {
            if (battery.activeSelf)
            {
                float scaleChange = (isRecharging ? rechargeSpeed : -dischargeSpeed) * Time.deltaTime;
                float newScaleY = 
                    Mathf.Clamp(battery.transform.localScale.y + scaleChange, 0, initialBatteryScaleY);

                battery.transform.localScale = new Vector3(0.15f, newScaleY, 0.15f);
                
                if(battery.transform.localScale.y <= 0)
                    battery.SetActive(false);
            }
        }
    }

    public void ResetBatteries()
    {
        isRecharging = true;

        rechargeSpeed = initialBatteryScaleY / enemy.abilityCooldown;
        dischargeSpeed = initialBatteryScaleY / (enemy.flamethrowDuration * .75f);

        foreach(GameObject battery in batteries)
        {
            battery.SetActive(true);
        }
    }

    public void DischargeBatteries() => isRecharging = false;
}
