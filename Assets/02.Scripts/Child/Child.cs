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
    public GameObject ChildDeathPrefab;
    private bool isSantaPresent = false; // Santa가 있는지 여부를 저장하는 변수 추가

    public int ChildHealth = 15;                                 
    public int AttackDamage = 1;
    public float MovementSpeed = 0.4f;
    private float OriginalSpeed = 0.4f; // OriginalSpeed 지정

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
            //Death();
            gameObject.SetActive(false);
            Instantiate(ChildDeathPrefab, transform.position, transform.rotation);
        }
        // Santa가 없을 때 MovementSpeed를 복구
        if (!isSantaPresent)
        {
            MovementSpeed = OriginalSpeed; //  MovementSpeed를 OriginalSpeed로 복구
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Santa")
        {
            Santa santa = collision.GetComponent<Santa>();
            MovementSpeed = 0;
            santa.SantaHealth -= 1;
            isSantaPresent = true; // Santa가 있음을 표시
        }
       else if (collision.tag == "Arrow")
       {
            Attack arrow = collision.GetComponent<Attack>();
            ChildHealth -= 1;
            Debug.Log(ChildHealth);
            arrow.gameObject.SetActive(false);
       }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AttackTimer -= Time.deltaTime;
        if (collision.tag == "Santa")
        {
            Santa santa = collision.GetComponent<Santa>();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Santa")
        {
            isSantaPresent = false; // Santa가 없음을 표시.  -> 산타랑 싸움 끝남
        }
    }

    /*public void Death()
    {
        gameObject.SetActive(false);
        Instantiate(ChildDeathPrefab, transform.position, transform.rotation);
    }*/

}


//연동확인용_24.01.31/18:46-고승연