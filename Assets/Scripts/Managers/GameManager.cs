using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [Header("Settings")]
    public bool friendlyFire;
    [Space]
    public bool quickStart;

    public ItemForLastDefence[] pickupsForLastDefence;

    public GameObject bossHammer;
    public GameObject bossFlamethrower;

    private void Awake()
    {
        instance = this;

        player = FindObjectOfType<Player>();

        pickupsForLastDefence = FindObjectsOfType<ItemForLastDefence>(true);
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Z))
        //    ResetGame();

        if (Input.GetKeyDown(KeyCode.X))
            ActivateAllMission();

        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetInt("Final", 0);
            PlayerPrefs.SetInt("Time", 1);
        }
            
    }

    public void GameStart()
    {
        SetDefaultWeaponsForPlayer();

        //LevelGenerator.instance.InitializeGeneration();
        // We start selected mission in a LevelGenerator script ,after we done with level creation.
    }

    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void GameCompleted()
    {
        UI.instance.ShowVictoryScreenUI();
        ControlsManager.instance.controls.Character.Disable();
        player.health.currentHealth += 99999; // So player won't die in last second.
    }
    public void GameOver()
    {
        TimeManager.instance.SlowMotionFor(1.5f);
        UI.instance.ShowGameOverUI();
        CameraManager.instance.ChangeCameraDistance(5);
    }

    private void SetDefaultWeaponsForPlayer()
    {
        List<Weapon_Data> newList = UI.instance.weaponSelection.SelectedWeaponData();
        player.weapon.SetDefaultWeapon(newList);
    }

    public void ResetGame()
    {
        //Reset mission
        PlayerPrefs.SetInt("Key", 0);
        PlayerPrefs.SetInt("Car", 0);
        PlayerPrefs.SetInt("Time", 0);
        PlayerPrefs.SetInt("Final", 0);
        UI.instance.missionSelection.LoadMission();

        //Delete data saved
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save file deleted from: " + path);
        }
        else
        {
            Debug.LogWarning("Save file not found to delete at: " + path);
        }
    }

    public void ActivateAllMission()
    {
        PlayerPrefs.SetInt("Key", 1);
        PlayerPrefs.SetInt("Car", 1);
        PlayerPrefs.SetInt("Time", 1);
        PlayerPrefs.SetInt("Final", 1);
        UI.instance.missionSelection.LoadMission();
    }
}
