using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{   // Resource _Santa 자동 재화 생성
    // 코인 자동 생성
    // 코인 생성 확률
    // 코인 생성 쿨타임 설정

    // 코인 저장 -> 민성오빠


    void Start()
    {

    }
        void Update()
    {
        // 마우스 왼쪽 버튼이 눌렸는지 확인
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 포인터가 위치한 스크린 좌표를 Ray로 변환
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // 오브젝트가 클릭되었는지 확인
            if (hit.collider != null)
            {
                // 클릭된 오브젝트가 Coin 태그를 가지고 있는지 확인
                if (hit.collider.CompareTag("Coin"))
                {
                    // 클릭된 Coin 오브젝트의 동작 수행
                    Coin coin = hit.collider.GetComponent<Coin>();
                    if (coin != null)
                    {
                        coin.Collect(); // Coin 오브젝트에서 Collect() 메서드 호출
                    }
                }
            }
        }

        /*   CurrentTime += Time.deltaTime;
           if (CurrentTime >= 5f)
           {
               GameObject Coin = Instantiate(CoinPrefab);
               Coin.SetActive(true);
           }*/
    }

    /*   public void MakeItem()
       {
           GameObject Coin = Instantiate(CoinPrefab);

           Santa santa = GetComponent<Santa>();
           Coin.transform.position = santa.transform.position;
       }*/
    public void Collect()
    {
        Destroy(gameObject);
        CoinManager.instance.Coin += 50;
    }

}
