using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoomChildType
{
    Boom
}

public class BoomChild_Child : MonoBehaviour
{
    public BoomChildType BType;

    public GameObject ChildDeathPrefab;

    public GameObject ChildRunawayPrefab;

    public GameObject BoomPrefab;

    public int ChildHealth = 5;

    public float MovementSpeed = 0.4f;

    // 원래 색상을 저장할 변수
    private Color originalColor;

    // SpriteRenderer 컴포넌트를 저장할 변수
    private SpriteRenderer spriteRenderer;


    public void Init()
    {
        ChildHealth = 5;
    }
    void Start()
    {
        // SpriteRenderer 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 원래 색상 저장
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.left;
        transform.position += (Vector3)(dir * MovementSpeed) * Time.deltaTime;
        dir = dir.normalized;

        if (ChildHealth <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
        {
            Attack arrow = collision.GetComponent<Attack>();
            if (arrow.AType == AttackType.Arrow)
            {
                ChildHealth -= 1;
            }
            else if (arrow.AType == AttackType.Bullet)
            {
                ChildHealth -= 2;
            }
            arrow.gameObject.SetActive(false);
            // 피격 시 색상 변경
            StartCoroutine(FlashRed());
        }
        else if(collision.tag == "Santa")
        {
            Instantiate(ChildRunawayPrefab, transform.position, transform.rotation);
            Instantiate(BoomPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    private void Death()
    {
        GameObject BoomPrefab = Instantiate(ChildDeathPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);

    }

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
