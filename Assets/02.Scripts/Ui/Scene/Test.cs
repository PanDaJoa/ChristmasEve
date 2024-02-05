using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject Scene3;

    private bool isScene1Active = true;
    private bool isScene2Active = false;
    private bool isScene3Active = false;

    void Start()
    {
        Scene1.SetActive(isScene1Active);
        Scene2.SetActive(isScene2Active);
        Scene3.SetActive(isScene3Active);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isScene1Active)
            {
                isScene1Active = false;
                isScene2Active = true;
                Scene1.SetActive(false);
                Scene2.SetActive(true);
            }
            else if (isScene2Active)
            {
                isScene2Active = false;
                isScene3Active = true;
                Scene2.SetActive(false);
                Scene3.SetActive(true);
            }
            else if(isScene3Active)
            {
                SceneManager.LoadScene("SYScene");
            }
        }
    }
}