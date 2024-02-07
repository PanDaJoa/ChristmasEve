using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBoom : MonoBehaviour
{
    public float Timer = 0f;
    public float CurrentTime = 1.3f;
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
        
        CurrentTime -= Time.deltaTime;
        Santa san = collision.GetComponent<Santa>();
        if (collision.tag == "Santa")
        {
            
            if (CurrentTime <= 0f)
            {

                BoomSound.Play();
                san.SantaHealth -= 30;
                CurrentTime = Timer;
            }

        }
    }


}

