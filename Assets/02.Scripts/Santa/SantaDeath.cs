using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaDeath : MonoBehaviour
{
    public float timer = 2f;
    public float destroyTime = 0f;
    void Start()
    {
        Destroy(gameObject, 1.5f);

    }

        // Update is called once per frame
    void Update()
    {
        /*Santa santa = GetComponentInParent<Santa>();

        if (santa != null && santa.SantaHealth <= 0)
        {
            timer -= Time.deltaTime;
            if (timer <= destroyTime)
            {
                Destroy(gameObject);
            }

        }*/

    }
}
