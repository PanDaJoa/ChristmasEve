using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Timer = 0f;
    public float CurrentTime=1.3f;

    public AudioSource BoomSound;

    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }

        CurrentTime -= Time.deltaTime;

        if (collision.tag == "Child")
        {
            Debug.Log("폭파준비");
            if (CurrentTime <= 0f)
            {
                Debug.Log("타이머 준비 끝");
                Basic_Child child = collision.GetComponent<Basic_Child>();
                if (child != null)
                {
                    child.ChildHealth -= 30;
                }

                BoomChild_Child boomchild = collision.GetComponent<BoomChild_Child>();
                if (boomchild != null)
                {
                    boomchild.ChildHealth -= 30;
                    BoomSound.Play();
                }
                CurrentTime = Timer;
               
            }
        }
    }


}
