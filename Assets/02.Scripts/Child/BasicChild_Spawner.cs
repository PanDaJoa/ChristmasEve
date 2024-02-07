using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicChild_Spawner : MonoBehaviour
{
    bool isGameEnded = false;

    public GameObject Basic_ChildPrefab;
    public GameObject Sword_ChildPrefab;
    public GameObject Hammer_ChildPrefab;

    public GameObject Boom_ChildPrefab;

    public float MinSpawnInterval = 6f;
    public float MaxSpawnInterval = 14f;
    public float SpawnTimer = 0f;
    public float SpawnInterval = 0f;

    public float GameEndTimer = 90f;

    public float BossTimer = 70f;

    public int PoolSize = 30;
    public List<Basic_Child> ChildPool;
    public List<BoomChild_Child> BoomChildPool;

    private void Awake()
    {
        ChildPool = new List<Basic_Child>();
        BoomChildPool = new List<BoomChild_Child>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject basicChild = Instantiate(Basic_ChildPrefab);
            basicChild.SetActive(false);
            ChildPool.Add(basicChild.GetComponent<Basic_Child>());
        }
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject basicChild = Instantiate(Sword_ChildPrefab);
            basicChild.SetActive(false);
            ChildPool.Add(basicChild.GetComponent<Basic_Child>());
        }
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject basicChild = Instantiate(Hammer_ChildPrefab);
            basicChild.SetActive(false);
            ChildPool.Add(basicChild.GetComponent<Basic_Child>());
        }
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject boomChild = Instantiate(Boom_ChildPrefab);
            boomChild.SetActive(false);
            BoomChildPool.Add(boomChild.GetComponent<BoomChild_Child>());
        }
    }
    void Start()
    {
        SetRandomSpawnInterval();
        SpawnTimer = SpawnInterval;
    }

    
    void Update()
    {
        GameEndTimer -= Time.deltaTime;
        SpawnTimer -= Time.deltaTime;
        BossTimer -= Time.deltaTime;

        if (SpawnTimer <= 0f)
        {
            SpawnChild();
            SpawnTimer = SpawnInterval;
        }
        if (BossTimer <= 0f)
        {
            BossTime();
        }
        if (GameEndTimer <= 0f && BossTimer <= 0f)
        {
            isGameEnded = true;
            DestroyOrDisableSpawner();
        }

    }

        private void SetRandomSpawnInterval()
    {
        SpawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
    }
    private void SpawnChild()
    {
        int randomNumber = Random.Range(0, 7);
        Basic_Child child = null;
        BoomChild_Child boomchild = null;

        switch (randomNumber)
        {
            case 0:
                child = GetInactiveChildOfType(ChildType.Basic);
                break;
            case 1:
                child = GetInactiveChildOfType(ChildType.Basic);
                break;
            case 2:
                child = GetInactiveChildOfType(ChildType.Basic);
                break;

            case 3:
                child = GetInactiveChildOfType(ChildType.Sword);
                break;
            case 4:
                child = GetInactiveChildOfType(ChildType.Sword);
                break;
            case 5:
                child = GetInactiveChildOfType(ChildType.Hammer);
                break;
            case 6:
                boomchild = GetInactiveBoomChildOfType(BoomChildType.Boom);
                break;

        }

        if (child != null)
        {
            child.transform.position = this.transform.position;
            child.Init();
            child.gameObject.SetActive(true);
        }

        if (boomchild != null)
        {
            boomchild.transform.position = this.transform.position;
            boomchild.Init();
            boomchild.gameObject.SetActive(true);
        }
    }
    private Basic_Child GetInactiveChildOfType(ChildType type)
    {
        foreach (Basic_Child c in ChildPool)
        {
            if (!c.gameObject.activeInHierarchy && c.CType == type)
            {
                return c;
            }
        }
        return null;
    }
    private BoomChild_Child GetInactiveBoomChildOfType(BoomChildType type)
    {
        foreach (BoomChild_Child b in BoomChildPool)
        {
            if (!b.gameObject.activeInHierarchy && b.BType == type)
            {
                return b;
            }
        }
        return null;
    }

    private void BossTime()
    {
        SpawnInterval = 1;
        foreach (Basic_Child child in ChildPool)
        {
            
            child.OriginalSpeed = 1.5f; // OriginalSpeed를 1.5로 변경
            child.AttackInterval = 0.5f; // AttackInterval을 0.5로 변경
        }

    }
    private void DestroyOrDisableSpawner()
    {
        // BasicChild_Spawner를 비활성화 또는 파괴하는 코드를 추가합니다.
        gameObject.SetActive(false); // 비활성화
        SceneManager.LoadScene("GameClear");
    }

    }
