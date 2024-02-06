using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Delete : MonoBehaviour
{
    private bool isDragging = false;

   public void OnClickCard()
    {
        // 1. 마우스를 따라댕기다가
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = mousePosition;
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (isDragging && otherCollider.CompareTag("Santa"))
        {
            Destroy(otherCollider.gameObject); // 충돌한 오브젝트 제거
        }
    }

}
