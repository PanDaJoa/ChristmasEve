using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider slider; // Slider 컴포넌트 참조
    public float totalTime = 10f; // 총 시간 설정

    private float currentTime; // 현재 시간 저장 변수

    void Start()
    {
        currentTime = totalTime; // 현재 시간을 총 시간으로 초기화
        slider.maxValue = totalTime; // Slider의 최대 값을 총 시간으로 설정
        slider.value = totalTime; // Slider의 현재 값을 총 시간으로 설정
    }

    void Update()
    {
        // 시간이 남아 있을 때
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // 현재 시간을 감소
            slider.value = currentTime; // Slider의 값을 현재 시간으로 업데이트
        }
        else
        {
            // 시간이 다 되면, 원하는 작업 수행
            // 예: 게임 종료, 재시작 등
        }
    }
}
