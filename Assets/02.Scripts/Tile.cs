using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject cardPrefab; // 카드에 들어있는 프리팹
    private GameObject currentCard; // 현재 클릭된 카드에 들어있는 프리팹

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // 카드를 클릭했을 때
                if (hit.collider.CompareTag("Santa"))
                {
                    // 카드에 있는 프리팹 복제하여 마우스 위치에 배치
                    currentCard = Instantiate(cardPrefab, hit.transform.position, Quaternion.identity);
                }
                // 비어있는 타일을 클릭했을 때
                else if (hit.collider.CompareTag("EmptyTile"))
                {
                    // 타일의 중앙에 배치
                    if (currentCard != null)
                    {
                        currentCard.transform.position = hit.transform.position;
                        currentCard = null; // 배치 후 현재 카드 비우기
                    }
                }
            }
        }
    }
}
