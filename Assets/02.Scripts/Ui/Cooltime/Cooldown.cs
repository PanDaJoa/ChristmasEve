using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Button YourButton; // 쿨타임이 시작될 버튼
    public Image CooldownImage; // 쿨타임을 표시할 이미지
    public float CooldownTime; // 쿨타임의 전체 시간

    private float currentCooldown; // 현재 남은 쿨타임

    public void OnClickCoolTime()
    {
        // 버튼에 클릭 이벤트 추가
        YourButton.onClick.AddListener(StartCooldown);
        currentCooldown = 0;
    }

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime; // 쿨타임 감소
            CooldownImage.fillAmount = currentCooldown / CooldownTime; // 쿨타임 비율에 따라 이미지 Fill Amount 조정
        }
        else
        {
            CooldownImage.fillAmount = 1; // 쿨타임이 끝나면 이미지 Fill Amount를 0으로 설정
        }
    }

    // 쿨타임 시작 함수
    public void StartCooldown()
    {
        currentCooldown = CooldownTime;
    }
}