using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaDeath : MonoBehaviour
{
    public float Timer = 2f;
    public float DestroyTime = 0f;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Santa santa = GetComponentInParent<Santa>();

        if (santa != null && santa.SantaHealth <= 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= DestroyTime)
            {
                Destroy(gameObject);
            }

        }

    }
}
