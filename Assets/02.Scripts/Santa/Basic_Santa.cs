using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basic_Santa : MonoBehaviour
{
    public int SantaHealth = 10;
    public GameObject SantaDeathPrefab;

    void Start()
    {

    }
    void Update()
    {
       if (SantaHealth <= 0) 
        {
            gameObject.SetActive(false);
            SantaDeathPrefab.transform.position = this.transform.position;
        }
    }

}

