using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_MissionSelection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionDesciprtion;

    [Header("Mission")]
    public GameObject keyMission;
    public GameObject carMission;
    public GameObject timeMission;
    public GameObject finalMission;

    public void TurnOffAllMission()
    {
        keyMission.SetActive(false);
        carMission.SetActive(false);
        timeMission.SetActive(false);
        finalMission.SetActive(false);
    }

    public void LoadMission()
    {
        LoadKeyMission();
        LoadCarMission();
        LoadTimeMission();
        LoadFinalMission();
    }

    public void LoadKeyMission()
    {
        int keyMissionInt = PlayerPrefs.GetInt("Key", 0);
        bool newKeyMission = false;

        if (keyMissionInt == 1)
            newKeyMission = true;

        keyMission.SetActive(newKeyMission);
    }

    public void LoadCarMission()
    {
        int carMissionInt = PlayerPrefs.GetInt("Car", 0);
        bool newCarMission = false;

        if (carMissionInt == 1)
            newCarMission = true;

        carMission.SetActive(newCarMission);
    }

    public void LoadTimeMission()
    {
        int timeMissionInt = PlayerPrefs.GetInt("Time", 0);
        bool newTimeMission = false;

        if (timeMissionInt == 1)
            newTimeMission = true;

        timeMission.SetActive(newTimeMission);
    }

    public void LoadFinalMission()
    {
        int finalMissionInt = PlayerPrefs.GetInt("Final", 0);
        bool newfinalMission = false;

        if (finalMissionInt == 1)
            newfinalMission = true;

        finalMission.SetActive(newfinalMission);
    }

    public void UpdateMissionDesicription(string text)
    {
        missionDesciprtion.text = text;
    }
}
