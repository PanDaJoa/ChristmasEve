using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChildType
{
    Basic,
    Sword,
    Hammer,
    
}
public class Basic_Child : MonoBehaviour
{
    public GameObject ChildDeathPrefab;

    public ChildType CType;

    private bool isSantaPresent = false;

    public int ChildHealth = 15;
    public int AttackDamage;
    public float MovementSpeed = 0.4f;
    public float OriginalSpeed = 0.4f;

    public const float AttackInterval = 0.4f;
    public float AttackTimer = 0;

    public bool AttackAutoMode = false;

    // 원래 색상을 저장할 변수
    private Color originalColor;

    // SpriteRenderer 컴포넌트를 저장할 변수
    private SpriteRenderer spriteRenderer;

    public void Init()
    {
        ChildHealth = 15;
        AttackTimer = AttackInterval;
        

    }

    void Start()
    {
        

        // SpriteRenderer 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 원래 색상 저장
        originalColor = spriteRenderer.color;
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
        
        if (CType == ChildType.Basic || CType == ChildType.Hammer)
        {
            AttackDamage = 1;
        }
        else if (CType == ChildType.Sword)
        {
            AttackDamage = 2;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Arrow")
        {
            Attack arrow = collision.GetComponent<Attack>();
            if(arrow.AType == AttackType.Arrow)
            {
                ChildHealth -= 1;
            }
            else if(arrow.AType == AttackType.Bullet)
            {
                ChildHealth -= 2;
            }
            arrow.gameObject.SetActive(false);

            // 피격 시 색상 변경
            StartCoroutine(FlashRed());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AttackTimer -= Time.deltaTime;
        if (collision.tag == "Santa")
        {
            MovementSpeed -= 0.1f;
            Santa santa = collision.GetComponent<Santa>();
            isSantaPresent = true;
            if (AttackTimer <= 0f)
            {
                AttackTimer = AttackInterval;
                santa.SantaHealth -= AttackDamage;
                Debug.Log($"산타체력:{santa.SantaHealth}");
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
        spriteRenderer.color = originalColor;
        Instantiate(ChildDeathPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    // 붉은색으로 깜빡이는 Coroutine
    IEnumerator FlashRed()
    {
        // 붉은색으로 변경
        spriteRenderer.color = Color.red;
        // 0.2초 대기
        yield return new WaitForSeconds(0.2f);
        // 원래 색상으로 복원
        spriteRenderer.color = originalColor;
    }

}
