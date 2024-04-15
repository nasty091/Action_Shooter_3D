using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> bulletPool;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        bulletPool = new Queue<GameObject>();

        CreateInitialPool();
    }

    public GameObject GetBullet()
    {
        if(bulletPool.Count == 0)
            CreateNewBullet();

        GameObject bulletToGet = bulletPool.Dequeue();
        bulletToGet.SetActive(true);
        bulletToGet.transform.parent = null;

        return bulletToGet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
        bullet.transform.parent = transform;
    }

    private void CreateInitialPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            CreateNewBullet();
        }
    }

    private void CreateNewBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefabs, transform);
        newBullet.SetActive(false);
        bulletPool.Enqueue(newBullet);
    }
}
