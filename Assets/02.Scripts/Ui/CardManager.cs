using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // ����: ī�带 �����ϰ� �ʹ�.
    // �׷���.. ��ü�� �ϳ������� ���ڰ�..
    // �ϳ��̴ϱ� ���ϰ� �����ϰ� �ʹ�.

    public static CardManager Instance { get; private set; }
    
    // ������ �巡�� ������ �ƴ����� Ȯ���ϴ� �Ӽ�
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
        // �巡�� ���� Ȯ�� �ڵ�
        // ���� ������ �巡�� ���̶��
        if (Input.GetMouseButtonDown(0))
        {
            // IsDragging �Ӽ��� true�� ����
            IsDragging = true;
        }
        else
        {
            // �巡�� ���� �ƴ϶�� IsDragging �Ӽ��� false�� ����
            IsDragging = false;
        }
    }
}
