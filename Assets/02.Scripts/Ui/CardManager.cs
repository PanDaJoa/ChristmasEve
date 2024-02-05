using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // 목적: 카드를 관리하고 싶다.
    // 그런데.. 객체가 하나였으면 좋겠고..
    // 하나이니까 편리하게 접근하고 싶다.

    public static CardManager Instance { get; private set; }

    public bool BuildMode = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
