using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Timer Mission", menuName = "Missions/Timer - Mission")]

public class Mission_Timer : Mission
{
    public float time;
    private float currentTime;


    public override void StartMission()
    {
        currentTime = time;
    }

    private int DonePercent()
    {
        float donePercent = (time - currentTime) / currentTime;

        return (int)Mathf.Round(donePercent * 100);
    }

    public override void UpdateMission()
    {
        currentTime -= Time.deltaTime;

        if (currentTime < 0)
        {
            GameManager.instance.GameOver();
        }

        Transform deliveryZone = FindObjectOfType<MissionObject_CarDeliveryZone>(true).transform;
        Transform playerTrans = GameManager.instance.player.transform;

        float distanceLeft = Vector3.Distance(playerTrans.position, deliveryZone.position);

        string timeText = System.TimeSpan.FromSeconds(currentTime).ToString("mm':'ss");
        string missionText = "Get to evacuation point before plane take off.";
        string missionDetails = "Time left: " + timeText + "\n" + "Distance left: " + distanceLeft + " (m)";

        UI.instance.inGameUI.UpdateMissionInfo(missionText, missionDetails);
    }

    public override bool MissionCompleted()
    {
        UI.instance.missionSelection.finalMission.SetActive(true);
        PlayerPrefs.SetInt("Final", 1);

        return currentTime > 0;
    }
}
