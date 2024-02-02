using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class ObjectDragDown : MonoBehaviour
{
    public bool _batched = false;

    public GameObject unitPrefab;

    
    // 오브젝트의 SpriteRenderer 컴포넌트
    private SpriteRenderer _spriteRenderer;

    // 오브젝트의 Collider2D 컴포넌트
    private Collider2D _collider;  


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
            // 1. 마우스를 따라댕기다가
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = mousePosition;


        

        }
    }
}
