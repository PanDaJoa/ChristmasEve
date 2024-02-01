using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChild_Spawner : MonoBehaviour
{
    public GameObject ChildPrefab;

    public float MinSpawnInterval = 4f;
    public float MaxSpawnInterval = 8f;
    private float SpawnTimer = 0f;
    private float SpawnInterval = 0f;

    void Start()
    {
        SetRandomSpawnInterval();
    }
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0f)
        {
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
