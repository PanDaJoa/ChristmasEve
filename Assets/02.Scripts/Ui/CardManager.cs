using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // 목적: 카드를 관리하고 싶다.
    // 그런데.. 객체가 하나였으면 좋겠고..
    // 하나이니까 편리하게 접근하고 싶다.

    public static CardManager Instance { get; private set; }
    
    // 유닛이 드래그 중인지 아닌지를 확인하는 속성
    public bool IsDragging { get; private set; }

    public bool BuildMode = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        // 드래그 상태 확인 코드
        // 만약 유닛이 드래그 중이라면
        if (Input.GetMouseButtonDown(0))
        {
            // IsDragging 속성을 true로 설정
            IsDragging = true;
        }
        else
        {
            // 드래그 중이 아니라면 IsDragging 속성을 false로 설정
            IsDragging = false;
        }
    }
}
