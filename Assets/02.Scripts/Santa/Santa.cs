using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Santa : MonoBehaviour
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
                Instantiate(SantaDeathPrefab, transform.position, transform.rotation);
            }
        }
    
}

