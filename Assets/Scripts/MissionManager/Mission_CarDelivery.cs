using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Car delivery - Mission", menuName = "Missions/Car delivery - Mission")]

public class Mission_CarDelivery : Mission
{
    private bool carWasDelivered;

    private string missionText;
    private string missionDetails;

    public override void StartMission()
    {
        carWasDelivered = false;

        FindObjectOfType<MissionObject_CarDeliveryZone>(true).gameObject.SetActive(true);

        missionText = "Find a functional vehicle.";
        missionDetails = "Deliver it to the evacuation point." + "\n" + "Distance left: ";

        UI.instance.inGameUI.UpdateMissionInfo(missionText, missionDetails);

        carWasDelivered = false;
        MissionObject_CarToDeliver.OnCarDelivery += CarDeliveryCompleted;

        Car_Controller[] cars = FindObjectsOfType<Car_Controller>();

        foreach (var car in cars)
        {
            car.AddComponent<MissionObject_CarToDeliver>();
        }

    }

    public override bool MissionCompleted()
    {
        UI.instance.missionSelection.timeMission.SetActive(true);
        PlayerPrefs.SetInt("Time", 1);

        return carWasDelivered;
    }

    private void CarDeliveryCompleted()
    {
        carWasDelivered = true;
        MissionObject_CarToDeliver.OnCarDelivery -= CarDeliveryCompleted;

        UI.instance.inGameUI.UpdateMissionInfo("Get to the evacuation point.");
    }

    public override void UpdateMission()
    {
        base.UpdateMission();

        Transform deliveryZone = FindObjectOfType<MissionObject_CarDeliveryZone>(true).transform;
        Transform playerTrans = GameManager.instance.player.transform;

        float distanceLeft = Vector3.Distance(playerTrans.position, deliveryZone.position);
        
        missionDetails = "Deliver it to the evacuation point." + "\n" + "Distance left: " + distanceLeft + " (m)";

        UI.instance.inGameUI.UpdateMissionInfo(missionText, missionDetails);
    }
}
