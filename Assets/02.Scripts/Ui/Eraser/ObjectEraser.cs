using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectEraser : MonoBehaviour
{
    public bool Batched;

    public bool IsDragging;

    private Collider2D containerCollider;

    public void Update()
    {
        if (!Batched)
        {
            // 1. ���콺�� ������ٰ�
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = mousePosition;

        }
        // ���� ���콺 ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            IsDragging = true;
        }

       // ���� ���콺 ��ư�� ���� ��
        if (Input.GetMouseButtonUp(0))
        {
            IsDragging = false;

            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (IsDragging && otherCollider.CompareTag("Santa"))
        {
            if (Input.GetMouseButtonDown(0))
            {

                Batched = true;

                
            }
            Santa santa = otherCollider.GetComponent<Santa>();
            if (santa != null)
            {
              // Destroy(otherCollider.gameObject);
               santa.Kill2(); // ��Ÿ�� ü���� 0���� ����� ��Ÿ�� ���Դϴ�.
                                       // �̷��� �ϸ� ��Ÿ�� ���� ���� �ڵ尡 ����Ǿ� SantaDeathPrefab�� ContainerPrefab�� �����˴ϴ�.
            }
            
            Destroy(this.gameObject);
        }
    }
}
