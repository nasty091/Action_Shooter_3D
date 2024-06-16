using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    // Enemies
    private List<Enemy> enemyList;

    private List<Interactable> pickupList;

    // NavMesh
    [SerializeField] private NavMeshSurface navMeshSurface;
    [Space]

    // Level parts
    [SerializeField] private Transform lastLevelPart;
    [SerializeField] private List<Transform> levelParts;
    private List<Transform> currentLevelParts;
    private List<Transform> generatedLevelParts = new List<Transform>();

    // Snap points
    [SerializeField] private SnapPoint nextSnapPoint;
    private SnapPoint defaultSnapPoint;

    // Cooldown
    [Space]
    [SerializeField] private float generationCooldown;
    private float cooldownTimer;
    private bool generationOver = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        enemyList = new List<Enemy>();
        pickupList = new List<Interactable>();

        defaultSnapPoint = nextSnapPoint;
    }


    private void Update()
    {
        if (generationOver)
            return;

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0)
        {
            if (currentLevelParts.Count > 0)
            {
                cooldownTimer = generationCooldown;
                GenerateNextLevelPart();
            }
            else if (generationOver == false)
            {
                FinishGeneration();
            }
        }
    }

    public Transform GetLastLevelPart() => lastLevelPart;
    public void SetLastLevelPart(Transform lastLevelPart) => this.lastLevelPart = lastLevelPart;
    public List<Transform> GetLevelParts() => levelParts;
    public void SetLevelParts(List<Transform> levelParts) => this.levelParts = levelParts;

    [ContextMenu("Restart generation")]
    public void InitializeGeneration()
    {
        nextSnapPoint = defaultSnapPoint;
        generationOver = false;
        currentLevelParts = new List<Transform>(levelParts);

        DestroyOldLevelPartsAndEnemies();
    }

    private void DestroyOldLevelPartsAndEnemies()
    {
        foreach (Enemy enemy in enemyList)
        {
            Destroy(enemy.gameObject);
        }

        foreach(Interactable pickup in pickupList)
        {
            Destroy(pickup.gameObject);
        }


        foreach (Transform t in generatedLevelParts)
        {
            Destroy(t.gameObject);
        }

        generatedLevelParts = new List<Transform>();
        enemyList = new List<Enemy>();
        pickupList = new List<Interactable>();
    }

    private void FinishGeneration()
    {
        generationOver = true;
        GenerateNextLevelPart();

        navMeshSurface.BuildNavMesh();

        foreach (Enemy enemy in enemyList)
        {
            enemy.transform.parent = null;
            enemy.gameObject.SetActive(true);
        }

        foreach (Interactable pickup in pickupList)
        {
            pickup.transform.parent = null;
        }

        MissionManager.instance.StartMission();
    }

    [ContextMenu("Create next level part")]
    private void GenerateNextLevelPart()
    {
        Transform newPart = null;

        if (generationOver)
            newPart = Instantiate(lastLevelPart);
        else
            newPart = Instantiate(ChooseRandomPart());

        generatedLevelParts.Add(newPart);

        LevelPart levelPartScript = newPart.GetComponent<LevelPart>();
        levelPartScript.SnapAndAlignPartTo(nextSnapPoint);

        if (levelPartScript.IntersectionDetected())
        {
            InitializeGeneration();
            return;
        }

        nextSnapPoint = levelPartScript.GetExitPoint();
        enemyList.AddRange(levelPartScript.MyEnemies());
        pickupList.AddRange(levelPartScript.MyPickups());   
    }

    private Transform ChooseRandomPart()
    {
        int randomIndex = Random.Range(0, currentLevelParts.Count);

        Transform choosenPart = currentLevelParts[randomIndex];

        currentLevelParts.RemoveAt(randomIndex);

        return choosenPart;
    }

    public Enemy GetRandomEnemy()
    {
        int randomIndex = Random.Range(0,enemyList.Count);

        return enemyList[randomIndex];
    }

    public List<Enemy> GetEnemyList() => enemyList;
}
