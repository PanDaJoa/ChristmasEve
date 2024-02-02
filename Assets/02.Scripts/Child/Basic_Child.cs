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
public class Basic_Child : MonoBehaviour
{
    public GameObject ChildDeathPrefab;
    private GameObject childDeathPrefabInstance;

    public ChildType CType;

    private bool isSantaPresent = false;

    public int ChildHealth = 15;
    public int AttackDamage = 1;
    public float MovementSpeed = 0.4f;
    private float OriginalSpeed = 0.4f;

    public const float AttackInterval = 0.2f;
    public float AttackTimer = 0;

    public bool AttackAutoMode = false;

    

    void Start()
    {

    }

    void Update()
    {
        Vector2 dir = Vector2.left;
        transform.position += (Vector3)(dir * MovementSpeed) * Time.deltaTime;
        dir = dir.normalized;

        if (ChildHealth <= 0)
        {
            Death();
        }

        if (!isSantaPresent)
        {
            MovementSpeed = OriginalSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Santa")
        {
            Santa santa = collision.GetComponent<Santa>();
            MovementSpeed = 0;
            santa.SantaHealth -= 1;
            isSantaPresent = true;
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
                if (AttackTimer <= 0f)
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
            isSantaPresent = false;
        }
    }

    private void Death()
    {
        if (childDeathPrefabInstance == null)
        {
            childDeathPrefabInstance = Instantiate(ChildDeathPrefab, transform.position, transform.rotation);
            // 1.5초 후에 childDeathPrefabInstance를 파괴합니다
            Destroy(childDeathPrefabInstance, 1.5f);
        }

        // ChildHealth가 0이 되면 gameObject를 비활성화합니다
        gameObject.SetActive(false);
        //gameObject.SetActive(false);
        //Instantiate(ChildDeathPrefab, transform.position, transform.rotation);
        //Destroy(gameObject);
    }
}
