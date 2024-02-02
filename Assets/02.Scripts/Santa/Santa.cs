using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Child")
        {
            Basic_Child child = collision.GetComponent<Basic_Child>();
            if(SType == SantaType.Sword)
            {
                child.ChildHealth -= 3;
            }/*else if(child.ChildHealth <= 0)
            {
                child.gameObject.SetActive(false);
            }*/
        }
    }

    }

