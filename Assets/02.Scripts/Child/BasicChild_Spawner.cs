using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChild_Spawner : MonoBehaviour
{
    public GameObject ChildPrefab;

    public float MinSpawnInterval = 4f;
    public float MaxSpawnInterval = 8f;
    public float SpawnTimer = 0f;
    public float SpawnInterval = 0f;

    public int PoolSize = 20;
    public List<Basic_Child> ChildPool;

    private void Awake()
    {
        ChildPool = new List<Basic_Child>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject basicChild = Instantiate(ChildPrefab);
            basicChild.SetActive(false);
            ChildPool.Add(basicChild.GetComponent<Basic_Child>());
        }
    }
    void Start()
    {
        SetRandomSpawnInterval();
    }
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0f)
        {
            //Basic_Child
            SpawnChild();
            SetRandomSpawnInterval();
            SpawnTimer = SpawnInterval;
        }
    }

    private void SpawnChild()
    {
        Instantiate(ChildPrefab, transform.position, transform.rotation);
    }
    private void SetRandomSpawnInterval()
    {
        SpawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
    }
}