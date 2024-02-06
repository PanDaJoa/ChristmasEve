using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image cooldownImage; // 쿨타임을 나타낼 이미지
    public float cooldownTime = 5f; // 쿨타임 시간 (초)

    private float currentCooldown; // 현재 쿨타임

    private void Start()
    {
        // 초기 상태 설정
        currentCooldown = 0f;
        cooldownImage.fillAmount = 0f;
    }

    private void Update()
    {
        // 쿨타임이 끝나지 않았다면
        if (currentCooldown > 0)
        {
            // 쿨타임 감소
            currentCooldown -= Time.deltaTime;

            // 쿨타임 이미지 업데이트
            cooldownImage.fillAmount = currentCooldown / cooldownTime;
        }
    }

    public void StartCooldown()
    {
        // 쿨타임 시작
        currentCooldown = cooldownTime;
    }
}
