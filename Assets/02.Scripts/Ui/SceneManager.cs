using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YourCustomSceneManager : MonoBehaviour
{
    void Start()
    {
        GameOverZone.OnGameOver += HandleGameOver;
    }

    void Update()
    {
    }
    void HandleGameOver()
    {
        // GameOver 이벤트가 발생하면 Scene 전환
        SceneManager.LoadScene("GameOverScene");
    }

    // 스크립트가 파괴될 때 등록된 이벤트 핸들러 제거
    private void OnDestroy()
    {
        GameOverZone.OnGameOver -= HandleGameOver;
    }
}
