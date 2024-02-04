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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CurrentTime -= Time.deltaTime;
        if (collision.tag == "Santa")
        {
            if (CurrentTime <= 0f)
            {

                Santa santa = collision.GetComponent<Santa>();
                santa.SantaHealth -= 30;
                CurrentTime = Timer;
            }

        }
    }
}
