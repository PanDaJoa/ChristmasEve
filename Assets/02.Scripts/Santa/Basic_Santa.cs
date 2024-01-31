using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basic_Santa : MonoBehaviour
{
    public int SantaHealth = 10;

    void Start()
    {

    }
    void Update()
    {
       if (SantaHealth <= 0) 
        {
        Destroy(gameObject);
        }
    }

}

