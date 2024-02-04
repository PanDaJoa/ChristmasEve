using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
        if(otherCollider.tag == "Child")
        {
            //TextContrl textcontrl = GetComponent<TextContrl>();
            otherCollider.gameObject.SetActive(false);
            //GameManager.instance.ShowGameOver();
            Debug.Log("게임오버");
            Debug.Log("아이들이 선물을 전부 훔쳐버렸습니다ㅜㅜ");
        }
    }
}
