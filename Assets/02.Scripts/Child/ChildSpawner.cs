using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class ChildSpawner : MonoBehaviour
{
    public GameObject Basic_ChildPrefab;
   /* public GameObject Sword_ChildPrefab;
    public GameObject Hammer_ChildPrefab;
    public GameObject Bomb_ChildPrefab;*/

    public int PoolSize = 10;
    public List<Child> ChildPool;

    private void Awake()
    {
        ChildPool = new List<Child>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject basicObject = Instantiate(Basic_ChildPrefab);
            basicObject.SetActive(false);
            ChildPool.Add(basicObject.GetComponent<Child>());
        }
    }

    public float SpawnTime = 2f;
    public float CurrentTimer = 0f;

    public float MinTime = 0.5f;
    public float MaxTime = 1.5f;

    void Start()
    {
        SetRandomTime();
    }

    void Update()
    {
        CurrentTimer += Time.deltaTime;

        if(CurrentTimer >= SpawnTime) 
        {
            Child child = null;
            int randomNumber = Random.Range(0, 10);  
            if (randomNumber < 11)
            {
                foreach (Child c in ChildPool)
                {
                    if (!c.gameObject.activeInHierarchy && c.CType == ChildType.Basic)
                    {
                        child = c;
                        break;
                    }
                }
            }
            child.transform.position = this.transform.position;
            child.gameObject.SetActive(true);
            CurrentTimer = 0f;
            SetRandomTime();
        }
    }

    private void SetRandomTime()
    {
        SpawnTime = Random.Range(MinTime, MaxTime);

    }
}
