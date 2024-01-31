using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChildType
{
    Basic,
    Sword,
    Hammer,
    Bomb
}

public class Child : MonoBehaviour
{



    public int ChildHealth = 15;                                 
    public int AttackDamage = 1;
    public float MovementSpeed = 0.04f;

    public const float AttackInterval = 0.2f;           //공격딜레이
    public float AttackTimer = 0;                           //

    public bool AttackAutoMode = false;


    public ChildType CType;



    void Start()
    {
       
    }

    void Update()
    {

        Vector2 dir = Vector2.left;
        transform.position += (Vector3)(dir * MovementSpeed) * Time.deltaTime;
        dir = dir.normalized;
        
        if(ChildHealth <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Arrow")
        {
            Attack arrow = collision.collider.GetComponent<Attack>();
            ChildHealth-=1;
            Debug.Log(ChildHealth);
        }
        Destroy(collision.collider.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Santa")
        {
            Basic_Santa santa = collision.GetComponent<Basic_Santa>();
            MovementSpeed = 0;
            santa.SantaHealth -= 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AttackTimer -= Time.deltaTime;
        if (collision.tag == "Santa")
        {
            Basic_Santa santa = collision.GetComponent<Basic_Santa>();
            for (int i = 0; i < santa.SantaHealth; i++) 
            {
                if(AttackTimer <= 0f)
                {
                    AttackTimer = AttackInterval;
                    santa.SantaHealth -= 1;
                    Debug.Log($"산타:{santa.SantaHealth}");
                }
            }
        }
    }


    public void Death()
    {
        gameObject.SetActive(false);
    }

}


//연동확인용_24.01.31/18:46-고승연