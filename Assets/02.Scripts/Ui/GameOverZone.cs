using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Child")
        {
            otherCollider.gameObject.SetActive(false);
            Debug.Log("���ӿ���");
            Debug.Log("���̵��� ������ ���� ���Ĺ��Ƚ��ϴ٤̤�");
        }
    }
}
