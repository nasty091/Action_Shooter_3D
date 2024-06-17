using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerBody;

    public PlayerControls controls { get; private set; }
    public Player_AimController aim { get; private set; }
    public Player_Movement movement { get; private set; }
    public Player_WeaponController weapon { get; private set; }
    public Player_WeaponVisuals weaponVisuals { get; private set; }
    public Player_Interaction interaction { get; private set; }
    public Player_Health health { get; private set; }
    public Ragdoll ragdoll { get; private set; }

    public Animator anim { get; private set; }
    public Player_SoundFX sound { get; private set; }

    public bool controlsEnabled { get; private set; }
    [SerializeField] private List<Mission> missionList;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        ragdoll = GetComponent<Ragdoll>();
        health = GetComponent<Player_Health>();
        aim = GetComponent<Player_AimController>();
        movement = GetComponent<Player_Movement>();
        weapon = GetComponent<Player_WeaponController>();
        weaponVisuals = GetComponent<Player_WeaponVisuals>();
        interaction = GetComponent<Player_Interaction>();
        sound = GetComponent<Player_SoundFX>();
        controls = ControlsManager.instance.controls;
    }


    private void OnEnable()
    {
        controls.Enable();
        controls.Character.UIMissionToolTipSwitch.performed += ctx => UI.instance.inGameUI.SwitchMissionTooltip();
        controls.Character.UIPause.performed += ctx => UI.instance.PauseSwitch();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    public void SetControlsEnabledTo(bool enabled)
    {
        controlsEnabled = enabled;
        ragdoll.CollidersActive(enabled);
        aim.EnableAimLaer(enabled);
    }


    public void SaveGame()
    {
        Player_Data playerData = new Player_Data();

        Transform playerTrans = gameObject.transform;

        //playerData.position = new float[] { playerTrans.position.x, playerTrans.position.y, playerTrans.position.z }; 
        //playerData.health = this.health.currentHealth;
        playerData.mission = MissionManager.instance.currentMission; // make if here to find name of mission to get the value of each mission
        playerData.weaponDatas = weapon.GetWeaponDatas();
        //playerData.weaponSlots = weapon.GetWeaponSlots();
        //playerData.currentWeapon = weapon.CurrentWeapon();
        //playerData.lastLevelPart = LevelGenerator.instance.GetLastLevelPart();

        string json = JsonUtility.ToJson(playerData);
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            Player_Data loadedData = JsonUtility.FromJson<Player_Data>(json);

            //update player's position and health, mission, weapons 
            //this.transform.position = new Vector3(loadedData.position[0], loadedData.position[1], loadedData.position[2]);
            //this.health.currentHealth = loadedData.health;
            foreach(Mission miss in missionList)
            {
                if(loadedData.mission.name == miss.name)
                {
                    MissionManager.instance.currentMission = miss;
                }
            }


            this.weapon.SetDefaultWeapon(loadedData.weaponDatas);
            LevelGenerator.instance.SetLevelParts(MissionManager.instance.currentMission.levelParts);
            LevelGenerator.instance.InitializeGeneration();
            UI.instance.ContinueTheGame();
            UI.instance.inGameUI.UpdateHealthUI(this.health.currentHealth, this.health.maxHealth);
            //UI.instance.inGameUI.UpdateMissionInfo(loadedData.mission.missionName, loadedData.mission.missionDescription);
        }
        else
            UI.instance.mainMenuUI.ShowWarningMessage("No data to countinue");
    }

}
