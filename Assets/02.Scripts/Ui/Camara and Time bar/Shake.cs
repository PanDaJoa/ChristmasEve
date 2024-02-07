using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    // 카메라의 Transform. 만약 null이면, 이 게임 오브젝트의 Transform을 가져옵니다.
    public Transform camTransform;

    // 오브젝트가 얼마 동안 흔들릴지 결정합니다.
    public float shakeDuration = 0.6f;

    // 쉐이크의 진폭. 값이 클수록 카메라를 더 강하게 흔듭니다.
    public float shakeAmount = 0.5f;
    public float decreaseFactor = 0.6f;

    Vector3 originalPos;  // 원래 위치를 저장하기 위한 변수

    void Awake()
    {
        // 만약 camTransform이 null이면, 이 게임 오브젝트의 Transform을 할당합니다.
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        // 원래 위치를 저장합니다.
        originalPos = camTransform.localPosition;
    }

    void Start()
    {
        // 3초 후에 ShakeCamera 메서드를 호출합니다.
        StartCoroutine(ShakeCameraAfterDelay(3));
        StartCoroutine(ShakeCameraAfterDelay(70));
    }

    IEnumerator ShakeCameraAfterDelay(float delay)
    {
        // 지정한 딜레이 시간만큼 대기합니다.
        yield return new WaitForSeconds(delay);

        // 딜레이가 끝나면 카메라를 흔드는 시간을 설정합니다.
        shakeDuration = 2f; // 원하는 흔들림 시간으로 변경 가능
    }

    void Update()
    {
        // 쉐이크 시간이 남아있는 경우
        if (shakeDuration > 0)
        {
            // 카메라 위치를 무작위로 변경하여 쉐이크 효과를 생성합니다.
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            // 쉐이크 시간을 줄입니다.
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            // 쉐이크 시간이 끝나면, 쉐이크 시간을 0으로 설정하고 카메라 위치를 원래 위치로 돌립니다.
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}
