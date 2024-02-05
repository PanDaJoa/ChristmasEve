using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject cardPrefab; // ī�忡 ����ִ� ������
    private GameObject currentCard; // ���� Ŭ���� ī�忡 ����ִ� ������

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // ī�带 Ŭ������ ��
                if (hit.collider.CompareTag("Santa"))
                {
                    // ī�忡 �ִ� ������ �����Ͽ� ���콺 ��ġ�� ��ġ
                    currentCard = Instantiate(cardPrefab, hit.transform.position, Quaternion.identity);
                }
                // ����ִ� Ÿ���� Ŭ������ ��
                else if (hit.collider.CompareTag("EmptyTile"))
                {
                    // Ÿ���� �߾ӿ� ��ġ
                    if (currentCard != null)
                    {
                        currentCard.transform.position = hit.transform.position;
                        currentCard = null; // ��ġ �� ���� ī�� ����
                    }
                }
            }
        }
    }
}
