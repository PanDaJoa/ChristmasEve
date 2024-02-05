using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Child"))
        {
            // 필요한 조건에 따라 이벤트 발생
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }
    }

    // ...
}