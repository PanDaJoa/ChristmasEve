using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum SantaType
{
    Resource,
    Bow,                
    Gun,                
    Sword,
    PresentBomb
}

public class Santa : MonoBehaviour 
{
    public SantaType SType;
    public int SantaHealth = 10;
    public float AttackInterval = 1f;
    public float AttackTimer = 0f;

    public int AttackDamage;
    

    public GameObject SantaDeathPrefab;
   

    public void Init()
    {
        SantaHealth = 10;
        AttackInterval = 1f;
}

    void Start()
    {

    }
    void Update()
    {
        if (SantaHealth <= 0)           //산타죽음
        {
            gameObject.SetActive(false);
            Instantiate(SantaDeathPrefab, transform.position, transform.rotation);
        }
        if (SType == SantaType.Sword)
        {
            AttackDamage = 3;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        AttackTimer -= Time.deltaTime;
        
            if (collision.tag == "Child")
            {
                Basic_Child child = collision.GetComponent<Basic_Child>();
                
                    if (AttackTimer <= 0f)
                    {
                        AttackTimer = AttackInterval;
                        child.ChildHealth -= AttackDamage;
                        Debug.Log($"어린이체력:{child.ChildHealth}");
                    }
                
            }
       
    }

}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSanta : MonoBehaviour
{
    public GameObject BombPrefab;


    void Start()
    {
        Santa santa = GetComponent<Santa>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Basic_Child child = collision.GetComponent<Basic_Child>();
        if (collision.tag == "Child")
        {
            if ()
                Explosion();
        }
    }

    void Explosion()
    {
        gameObject.SetActive(false);
        Instantiate(BombPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
*/