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
    public GameObject ContainerPrefab;

    // ���� ������ ������ ����
    private Color originalColor;

    // SpriteRenderer ������Ʈ�� ������ ����
    private SpriteRenderer spriteRenderer;



    void Start()
    {
        // SpriteRenderer ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ���� ���� ����
        originalColor = spriteRenderer.color;
    }
    void Update()
    {
        if (SantaHealth <= 0)           //��Ÿ����
        {
            Kill();
        }
        if (SType == SantaType.Sword)
        {
            AttackDamage = 3;
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        Instantiate(SantaDeathPrefab, transform.position, transform.rotation);
        Instantiate(ContainerPrefab, transform.position, transform.rotation);
    }

    public void Kill2()
    {
        gameObject.SetActive(false);
        //Instantiate(SantaDeathPrefab, transform.position, transform.rotation);
        Instantiate(ContainerPrefab, transform.position, transform.rotation);
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
                Debug.Log($"���ü��:{child.ChildHealth}");
                // �ǰ� �� ���� ����
                StartCoroutine(FlashRed());
            }

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
}

