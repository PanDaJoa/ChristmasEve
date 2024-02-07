using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Button YourButton; // ��Ÿ���� ���۵� ��ư
    public Image CooldownImage; // ��Ÿ���� ǥ���� �̹���
    public float CooldownTime; // ��Ÿ���� ��ü �ð�

    private float currentCooldown; // ���� ���� ��Ÿ��

    public void OnClickCoolTime()
    {
        // ��ư�� Ŭ�� �̺�Ʈ �߰�
        YourButton.onClick.AddListener(StartCooldown);
        currentCooldown = 0;
    }

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime; // ��Ÿ�� ����
            CooldownImage.fillAmount = currentCooldown / CooldownTime; // ��Ÿ�� ������ ���� �̹��� Fill Amount ����
        }
        else
        {
            CooldownImage.fillAmount = 1; // ��Ÿ���� ������ �̹��� Fill Amount�� 0���� ����
        }
    }

    // ��Ÿ�� ���� �Լ�
    public void StartCooldown()
    {
        currentCooldown = CooldownTime;
    }
}