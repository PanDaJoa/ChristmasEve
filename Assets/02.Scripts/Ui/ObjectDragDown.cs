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


            // 2. 만약에 마우스 커서를 한번 더 누르면
            if (Input.GetMouseButtonUp(0))
            {
                // 3. 배치가된다.
                _batched = true;

                // 오브젝트의 렌더링 순서를 변경합니다.
                _spriteRenderer.sortingLayerName = "Unit";

                // 컨테이너 콜라이더 내에 유닛 오브젝트를 생성합니다.
                Instantiate(unitPrefab, mousePosition, Quaternion.identity);
            }

        }
    }
}
