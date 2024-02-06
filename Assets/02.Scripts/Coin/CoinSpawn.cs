using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject CoinPrefab;
    public float CurrentTime = 0f;

    // Coin Ç® »ý¼º
    public int PoolSize = 10;
    public List<Coin> CoinPool;

    private void Awake()
    {
        CoinPool = new List<Coin>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject Coin = Instantiate(CoinPrefab);
            Coin.SetActive(false);
            CoinPool.Add(Coin.GetComponent<Coin>());
        }
    }
        void Start()
        {

        }
        void Update()
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= 12f)
            {
                GameObject Coin = Instantiate(CoinPrefab);
                Coin.SetActive(true);
                Coin.transform.position = this.transform.position;
                CurrentTime = 0;
            }
        }
    }


