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
    public float AttackInterval = 1f;
    public float AttackTimer = 0f;

    public int AttackDamage;
    

    public GameObject SantaDeathPrefab;

    void Start()
    {

    }
    void Update()
    {
            if (SantaHealth <= 0)           //��Ÿ����
            {
                gameObject.SetActive(false);
                Instantiate(SantaDeathPrefab, transform.position, transform.rotation);
            }
            if(SType == SantaType.Sword)
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
                for(int i = 0; i< child.ChildHealth; i++) 
                {
                    if (AttackTimer <= 0f)
                    {
                        AttackTimer = AttackInterval;
                        child.ChildHealth -= AttackDamage;
                        Debug.Log($"���ü��:{child.ChildHealth}");
                    }
                }    
        }
       
    }

 }

