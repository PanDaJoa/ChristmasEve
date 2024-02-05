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
        // GameOver �̺�Ʈ�� �߻��ϸ� Scene ��ȯ
        SceneManager.LoadScene("GameOverScene");
    }

    // ��ũ��Ʈ�� �ı��� �� ��ϵ� �̺�Ʈ �ڵ鷯 ����
    private void OnDestroy()
    {
        GameOverZone.OnGameOver -= HandleGameOver;
    }
}
