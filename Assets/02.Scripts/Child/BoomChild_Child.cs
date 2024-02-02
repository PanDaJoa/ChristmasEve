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
    public void Init()
    {
        ChildHealth = 5;
    }
    void Start()
    {
        
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
            Debug.Log(ChildHealth);
            arrow.gameObject.SetActive(false);
        }
        else if(collision.tag == "Santa")
        {
            gameObject.SetActive(false);
            Instantiate(ChildRunawayPrefab, transform.position, transform.rotation);
            Instantiate(BoomPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
        Instantiate(ChildDeathPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

}
