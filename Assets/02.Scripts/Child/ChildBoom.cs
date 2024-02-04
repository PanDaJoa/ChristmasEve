using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBoom : MonoBehaviour
{
    public float Timer = 0f;
    public float CurrentTime = 1.3f;

    void Start()
    {
        Destroy(gameObject, 1.5f);
    }


    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(" 실행되냐?");
        CurrentTime -= Time.deltaTime;
        if (collision.tag == "Santa")
        {
            Debug.Log("어린이 폭탄 폭파준비");
            if (CurrentTime <= 0f)
            {
                Debug.Log("어린이 폭탄 타이머 준비 끝");
                Santa san = collision.GetComponent<Santa>();
                san.SantaHealth -= 30;
                CurrentTime = Timer;
            }

        }
    }


}

