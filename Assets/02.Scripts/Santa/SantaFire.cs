using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaFire : MonoBehaviour
{
    [Header("화살 프리팹")]
    public GameObject ArrowPrefab;

    [Header("총구")]
    public GameObject Bow;

    [Header("발사 속도")]
    public float Timer = 0;
    public float COOL_TIME = 0.8f;

    public bool AutoMode = true;

    public int PoolSize = 24;           //내나이
    public List<Attack> _arrowPool;

    private void Awake()
    {
        _arrowPool = new List<Attack>();
        for(int i = 0; i < PoolSize; i++)
        {
            GameObject arrow = Instantiate(ArrowPrefab);
            _arrowPool.Add(arrow.GetComponent<Attack>());
            arrow.SetActive(false);
        }
    }

    void Start()

    {
        Timer = 0f;
        AutoMode = true;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        bool ready = AutoMode;
        if (Timer <= 0 && ready)
        {
            Timer = COOL_TIME;
            Fire();
        }
    }

    private void Fire()
    {
        Attack arrow = null;
        foreach(Attack a in _arrowPool)
        {
            if(a.gameObject.activeInHierarchy == false && arrow)
            { 
                arrow = a;
                break; 
            }
        }
            
            GameObject Arrow = Instantiate(ArrowPrefab);
            Arrow.transform.position = Bow.transform.position;
        }
    }

