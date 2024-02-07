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
        

        // ��Ÿ�� �� �϶� Ŭ���� �ص� �ٽ� 3�ʷ� ���ư��� �ʴ��ڵ�
        if (currentCooldown <= 0)
        {
            // ��ư�� Ŭ�� �̺�Ʈ �߰�
            currentCooldown = CooldownTime;
            
        }
        if (currentCooldown > 0)
        {
            
            currentCooldown -= Time.deltaTime; // ��Ÿ�� ����
            CooldownImage.fillAmount = currentCooldown / CooldownTime; // ��Ÿ�� ������ ���� �̹��� Fill Amount ����
        }
        else
        {
            CooldownImage.fillAmount = 0; // ��Ÿ���� ������ �̹��� Fill Amount�� 0���� ����
        }        
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
            CooldownImage.fillAmount = 0; // ��Ÿ���� ������ �̹��� Fill Amount�� 0���� ����
        }
    }

}