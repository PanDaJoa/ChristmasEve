using UnityEngine.SceneManagement;
using UnityEngine;


public class StartSceneManager : MonoBehaviour
{
  
    void Update()
    {
        // �����̽��ٸ� ������ ��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���� ������ �̵�
                SceneManager.LoadScene("StartScene02");
            SceneManager.LoadScene("StartScene03");
        }
        else
        {
            // ������ �����Ŀ� SYScene���� �ǵ��ư����� ����
            SceneManager.LoadScene("SYScene");
        }
    }
}
