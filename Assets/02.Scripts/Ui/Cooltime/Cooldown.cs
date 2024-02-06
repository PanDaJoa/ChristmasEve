using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image cooldownImage; // ��Ÿ���� ��Ÿ�� �̹���
    public float cooldownTime = 5f; // ��Ÿ�� �ð� (��)

    private float currentCooldown; // ���� ��Ÿ��

    private void Start()
    {
        // �ʱ� ���� ����
        currentCooldown = 0f;
        cooldownImage.fillAmount = 0f;
    }

    private void Update()
    {
        // ��Ÿ���� ������ �ʾҴٸ�
        if (currentCooldown > 0)
        {
            // ��Ÿ�� ����
            currentCooldown -= Time.deltaTime;

            // ��Ÿ�� �̹��� ������Ʈ
            cooldownImage.fillAmount = currentCooldown / cooldownTime;
        }
    }

    public void StartCooldown()
    {
        // ��Ÿ�� ����
        currentCooldown = cooldownTime;
    }
}
