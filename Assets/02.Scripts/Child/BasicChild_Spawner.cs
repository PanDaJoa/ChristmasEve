using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicChild_Spawner : MonoBehaviour
{
    public GameObject Basic_ChildPrefab;
    public GameObject Sword_ChildPrefab;
    public GameObject Hammer_ChildPrefab;

    public GameObject Boom_ChildPrefab;

    public float MinSpawnInterval = 4f;
    public float MaxSpawnInterval = 8f;
    public float SpawnTimer = 0f;
    public float SpawnInterval = 0f;

    public int PoolSize = 20;
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
        SpawnTimer -= Time.deltaTime;

        if (SpawnTimer <= 0f)
        {
            SpawnChild();
            SpawnTimer = SpawnInterval;
        }
        /* SetRandomSpawnInterval();
         if (SpawnTimer <= 0f)
         {
             Basic_Child child = null;
             BoomChild_Child boomchild = null;
             int randomNumber = Random.Range(0, 4);
             if(randomNumber == 0)
             {
                 foreach(Basic_Child c in ChildPool)
                 {
                     if ( !c.gameObject.activeInHierarchy && c.CType == ChildType.Basic)
                     {
                         child = c; 
                         break;
                     }
                 }
             }
             else if (randomNumber == 1)
             {
                 foreach (Basic_Child c in ChildPool)
                 {
                     if (!c.gameObject.activeInHierarchy && c.CType == ChildType.Sword)
                     {
                         child = c; 
                         break;
                     }
                 }
             }
             if (randomNumber == 2)
             {
                 foreach (Basic_Child c in ChildPool)
                 {
                     if (!c.gameObject.activeInHierarchy && c.CType == ChildType.Hammer)
                     {
                         child = c; 
                         break;
                     }
                 }
             }
             else if (randomNumber == 3)
             {
                 foreach (BoomChild_Child b in BoomChildPool)
                 {
                     if (!b.gameObject.activeInHierarchy && b.BType == BoomChildType.Boom)
                     {
                         boomchild = b; 
                         break;
                     }
                 }
             }

             //SpawnChild();
             child.transform.position = this.transform.position;
             boomchild.transform.position = transform.position;

             child.gameObject.SetActive(true);
             boomchild.gameObject.SetActive(true);

             SpawnTimer = SpawnInterval;
         }*/
    }

    /*private void SpawnChild()
    {
        Instantiate(ChildPrefab, transform.position, transform.rotation);
    }*/
    private void SetRandomSpawnInterval()
    {
        SpawnInterval = Random.Range(MinSpawnInterval, MaxSpawnInterval);
    }
    private void SpawnChild()
    {
        int randomNumber = Random.Range(0, 4);
        Basic_Child child = null;
        BoomChild_Child boomchild = null;

        switch (randomNumber)
        {
            case 0:
                child = GetInactiveChildOfType(ChildType.Basic);
                break;
            case 1:
                child = GetInactiveChildOfType(ChildType.Sword);
                break;
            case 2:
                child = GetInactiveChildOfType(ChildType.Hammer);
                break;
            case 3:
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


}
