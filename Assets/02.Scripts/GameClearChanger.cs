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
            // Child 태그를 가진 오브젝트가 없는 경우
            if (childObjects.Length == 0)
            {
                SceneChangeTimer -= Time.deltaTime;
                if (SceneChangeTimer <= 0)
                {
                    SceneManager.LoadScene("GameClear"); // GameClear 씬을 로드합니다.
                }
                
            }
        }
        

        
    }
}

