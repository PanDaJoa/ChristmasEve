using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // ����: ī�带 �����ϰ� �ʹ�.
    // �׷���.. ��ü�� �ϳ������� ���ڰ�..
    // �ϳ��̴ϱ� ���ϰ� �����ϰ� �ʹ�.

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
