using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Timer = 0f;
    public float CurrentTime=1.3f;

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
        if (collision.tag == "Child")
        {
            if (CurrentTime <= 0f)
            {
                
                Basic_Child child = collision.GetComponent<Basic_Child>();
                child.ChildHealth -= 30;
                CurrentTime = Timer;
            }
            
        }
    }


}
