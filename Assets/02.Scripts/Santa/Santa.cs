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

    // 원래 색상을 저장할 변수
    private Color originalColor;

    // SpriteRenderer 컴포넌트를 저장할 변수
    private SpriteRenderer spriteRenderer;



    void Start()
    {
        // SpriteRenderer 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 원래 색상 저장
        originalColor = spriteRenderer.color;
    }
    void Update()
    {
        if (SantaHealth <= 0)           //산타죽음
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
                Debug.Log($"어린이체력:{child.ChildHealth}");
                // 피격 시 색상 변경
                StartCoroutine(FlashRed());
            }

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
}

