using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearChanger : MonoBehaviour
{
    public float GameEndTimer = 90f;
    public float SceneChangeTimer = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameEndTimer -= Time.deltaTime;
        GameObject[] childObjects = GameObject.FindGameObjectsWithTag("Child");
        if (GameEndTimer <= 0)
        {
            // Child �±׸� ���� ������Ʈ�� ���� ���
            if (childObjects.Length == 0)
            {
                SceneChangeTimer -= Time.deltaTime;
                if (SceneChangeTimer <= 0)
                {
                    SceneManager.LoadScene("GameClear"); // GameClear ���� �ε��մϴ�.
                }
                
            }
        }
        

        
    }
}

