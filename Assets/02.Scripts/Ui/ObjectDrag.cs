using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectDrag : MonoBehaviour
{
    public bool Batched = false;

    private void Update()
    {
        // 만약 배치가 안됐다면...
        if (!Batched)
        {
            // 1. 마우스를 따라댕기다가
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = mousePosition;


            // 2. 만약에 마우스 커서를 한번 더 누르면
            if (Input.GetMouseButtonDown(0))
            {
                // 3. 배치가된다.
                Batched = true;
            }

        }

    }
}
