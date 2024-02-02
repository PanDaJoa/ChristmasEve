using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum SantaType
{
    Bow,                
    Gun,                
    Sword,
    PresentBomb
}

public class Santa : MonoBehaviour 
{
    public SantaType SType;
    public int SantaHealth = 10;
    public GameObject SantaDeathPrefab;

    void Start()
    {

    }
    void Update()
    {
            if (SantaHealth <= 0)           //»êÅ¸Á×À½
            {
                gameObject.SetActive(false);
                Instantiate(SantaDeathPrefab, transform.position, transform.rotation);
            }

        }
    
}

