using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defence - Mission", menuName = "Missions/Defence - Mission")]
public class Mission_LastDefence : Mission
{
    public bool defenceBegun = false;

    [Header("Cooldown and duration")]
    public float defenceDuration = 120;
    private float defenceTimer;
    public float waveCooldown = 15;
    private float waveTimer;

    [Header("Respawn details")]
    public int amountOfRespawnPoints = 2;
    public List<Transform> respawnPoints;
    private Vector3 defencePoint;
    [Space]

    public int enemiesPerWave;
    public GameObject[] possibleEnemies;

    private string defenceTimerText;

    private GameObject bossHammer;
    private GameObject bossFlamethrower;

    private void OnEnable()
    {
        defenceBegun = false;
    }

    public override void StartMission()
    {
        defenceBegun = false;
        defenceTimer = defenceDuration;
        waveTimer = waveCooldown;

        bossHammer = GameManager.instance.bossHammer;
        bossFlamethrower = GameManager.instance.bossFlamethrower;

        defencePoint = FindObjectOfType<MissionEnd_Trigger>().transform.position;
        respawnPoints = new List<Transform>(ClosestPoints(amountOfRespawnPoints));

        UI.instance.inGameUI.UpdateMissionInfo("Get to the evacuation point.");
    }

    public override bool MissionCompleted()
    {
        if (defenceBegun == false)
        {
            StartDefenceEvent();
            return false;
        }

        return defenceTimer < 0;
    }

    private int DonePercent()
    {
        float donePercent = (defenceDuration - defenceTimer) / defenceDuration;

        return (int)Mathf.Round(donePercent * 100);
    }

    public override void UpdateMission()
    {
        if(GameManager.instance.player.health.currentHealth <= 0)
        {
            defenceBegun = false;
            GameManager.instance.bossHammer = bossHammer;
            GameManager.instance.bossFlamethrower = bossFlamethrower;
        }

        if (defenceBegun == false)
            return;

        waveTimer -= Time.deltaTime;
        if (defenceTimer > 0)
            defenceTimer -= Time.deltaTime;


        if (waveTimer < 0 && defenceTimer > 120)
        {
            CreateNewEnemies(enemiesPerWave);
            waveTimer = waveCooldown;
        }


        if (defenceTimer <= 120)
            GameManager.instance.bossHammer.SetActive(true);
        
        if (defenceTimer <= 90)
            GameManager.instance.bossFlamethrower.SetActive(true);

        defenceTimerText = System.TimeSpan.FromSeconds(defenceTimer).ToString("mm':'ss");

        string missionText = "Defend yourself till plane is ready to take off.";
        string missionDetails = "Time left: " + defenceTimerText + " (Done: " + DonePercent() + "%)";

        UI.instance.inGameUI.UpdateMissionInfo(missionText, missionDetails);

    }

    private void StartDefenceEvent()
    {
        foreach (ItemForLastDefence pickup in GameManager.instance.pickupsForLastDefence)
        {
            pickup.gameObject.SetActive(true);
        }

        waveTimer = .5f;
        defenceTimer = defenceDuration;
        defenceBegun = true;
    }

    private void CreateNewEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomEnemyIndex = Random.Range(0, possibleEnemies.Length);
            int randomRespawnIndex = Random.Range(0, respawnPoints.Count);

            Transform randomRespawnPoint = respawnPoints[randomRespawnIndex];
            GameObject randomEnemy = possibleEnemies[randomEnemyIndex];

            randomEnemy.GetComponent<Enemy>().aggresionRange = 100;

            ObjectPool.instance.GetObject(randomEnemy, randomRespawnPoint);
        }
    }

    private List<Transform> ClosestPoints(int amount)
    {
        List<Transform> closestPoints = new List<Transform>();
        List<MissionObject_EnemyRespawnPoint> allPoints =
            new List<MissionObject_EnemyRespawnPoint>(FindObjectsOfType<MissionObject_EnemyRespawnPoint>());

        while (closestPoints.Count < amount && allPoints.Count > 0)
        {
            float shortestDistance = float.MaxValue;
            MissionObject_EnemyRespawnPoint closestPoint = null;

            foreach (var point in allPoints)
            {
                float distance = Vector3.Distance(point.transform.position, defencePoint);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    closestPoint = point;
                }
            }

            if (closestPoint != null)
            {
                closestPoints.Add(closestPoint.transform);
                allPoints.Remove(closestPoint);
            }
        }

        return closestPoints;
    }
}
