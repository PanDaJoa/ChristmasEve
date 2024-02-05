using UnityEngine.SceneManagement;
using UnityEngine;


public class StartSceneManager : MonoBehaviour
{
  
    void Update()
    {
        // 스페이스바를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 다음 씬으로 이동
                SceneManager.LoadScene("StartScene02");
            SceneManager.LoadScene("StartScene03");
        }
        else
        {
            // 마지막 씬이후에 SYScene으로 되돌아가도록 설정
            SceneManager.LoadScene("SYScene");
        }
    }
}
