using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public enum Enemy_MeleeWeaponType { OneHand, Throw}

public class Enemy_Visuals : MonoBehaviour
{
    [Header("Weapon model")]
    [SerializeField] private Enemy_WeaponModel[] WeaponModels;
    [SerializeField] private Enemy_MeleeWeaponType weaponType;
    public GameObject currentWeaponModel {  get; private set; }

    [Header("Color")]
    [SerializeField] private Texture[] colorTextures;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

    private void Start()
    {
        WeaponModels = GetComponentsInChildren<Enemy_WeaponModel>(true); // (true) mean we can collect weapon even disabled game object
        InvokeRepeating(nameof(SetupLook), 0, 1.5f);
    }

    public void SetupWeaponType(Enemy_MeleeWeaponType type) => weaponType = type;

    public void SetupLook()
    {
        SetupRandomColor();
        SetupRandomWeapon();
    }

    private void SetupRandomWeapon()
    {
        foreach(var weaponModel in WeaponModels)
        {
            weaponModel.gameObject.SetActive(false);
        }

        List<Enemy_WeaponModel> filteredWeaponModels = new List<Enemy_WeaponModel>();

        foreach(var weaponModel in WeaponModels)
        {
            if(weaponModel.weaponType == weaponType)
                filteredWeaponModels.Add(weaponModel);
        }

        int randomIndex = Random.Range(0, filteredWeaponModels.Count);

        currentWeaponModel = filteredWeaponModels[randomIndex].gameObject;
        currentWeaponModel.SetActive(true);
    }

    private void SetupRandomColor()
    {
        int randomIndex = Random.Range(0, colorTextures.Length);

        Material newMat = new Material(skinnedMeshRenderer.material);

        newMat.mainTexture = colorTextures[randomIndex];

        skinnedMeshRenderer.material = newMat;
    }
}
