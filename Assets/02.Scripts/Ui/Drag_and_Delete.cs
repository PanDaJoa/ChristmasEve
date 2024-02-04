using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_and_Delete : MonoBehaviour
{
    private bool isDragging = false;

    void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        curPosition.z = 0;
        transform.position = curPosition;
    }

    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (isDragging && otherCollider.CompareTag("Target"))
        {
            Destroy(otherCollider.gameObject); // 충돌한 오브젝트 제거
        }
    }

}
