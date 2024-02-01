using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{   // Resource _Santa 자동 재화 생성
    // 코인 자동 생성
    // 코인 생성 확률
    // 코인 생성 쿨타임 설정

    // 코인 저장 -> 민성오빠


    public float CurrentTime = 0f;
    public GameObject CoinPrefab;

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
        if (CurrentTime >= 5f)
        {
            GameObject Coin = Instantiate(CoinPrefab);
            Coin.SetActive(true);
        }
       
    }

 /*   public void MakeItem()
    {
        GameObject Coin = Instantiate(CoinPrefab);

        Santa santa = GetComponent<Santa>();
        Coin.transform.position = santa.transform.position;
    }*/
}
