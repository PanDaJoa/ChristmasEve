using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class ObjectDragDown : MonoBehaviour
{
    // 배치가 처음에 안되어 있어서 (false)
    public bool _batched = false;

    // 유닛이 컨테이너에 닿았을 때 보여줄 스프라이트
    public Sprite ContainerImage;

    // 오브젝트의 SpriteRenderer 컴포넌트
    private SpriteRenderer _spriteRenderer; 

    private void Start()
    {
        // SpriteRenderer 컴포넌트를 가져옵니다.
        _spriteRenderer = GetComponent<SpriteRenderer>();


 

    }
    private void Update()
    {

        // 만약 배치가 안됐다면...
        if (!_batched)
        {

            // 드래그 중이므로 'Unrecognized' 레이어로 변경합니다.
            gameObject.layer = LayerMask.NameToLayer("Unrecognized");

            // 1. 마우스를 따라댕기다가
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = mousePosition;
        }
        else
        {
            // 배치가 완료되었으므로 'Unit' 레이어로 다시 변경합니다.
            gameObject.layer = LayerMask.NameToLayer("Santa");
        }
       
    }
    void Attack()
    {
        ObjectDragDown dragDown = GetComponent<ObjectDragDown>();
        if (dragDown != null && dragDown.IsDragging())
        {
            // 유닛이 드래그 중이므로 공격하지 않습니다.
            return;
        }

        // 유닛 공격 로직
    }
    public bool IsDragging()
    {
        return !_batched;
    }
    
}
