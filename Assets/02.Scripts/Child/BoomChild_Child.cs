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

    // ���� ������ ������ ����
    private Color originalColor;

    // SpriteRenderer ������Ʈ�� ������ ����
    private SpriteRenderer spriteRenderer;


    public void Init()
    {
        ChildHealth = 5;
    }
    void Start()
    {
        // SpriteRenderer ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ���� ���� ����
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
            // �ǰ� �� ���� ����
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
        // ���������� ����
        spriteRenderer.color = Color.red;
        // 0.2�� ���
        yield return new WaitForSeconds(0.2f);
        // ���� �������� ����
        spriteRenderer.color = originalColor;
    }
    
}
