using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum StoreType
{
    Resource,
    Bow,
    Gun,
    Sword,
    PresentBomb

}

public class ObjectCard : MonoBehaviour
{
    public StoreType storeType;

    public GameObject Object_Plant_Drag;

    public float cooldown = 3f; // 쿨타임을 3초로 설정

    private float lastSummonTime; // 마지막으로 소환한 시간을 저장
   
    private bool isOnCooldown = false; // 쿨타임 상태를 저장하는 플래그

    public CoinManager coinManager; // CoinManager 클래스를 참조할 변수 추가


    // 카드를 클릭하면

    // 드래그 유닛 이미지 바꾸는 코드
    /*  public Sprite mySprite;
        public Container[] containers;*/


    private void Start()
    {
        coinManager = CoinManager.instance;
    }

    // 카드를 클릭하면
    public void OnClickCard()
    {
        if (CardManager.Instance.BuildMode)
        {
            return;
        }

        // 쿨타임이 아니면
        if (!isOnCooldown && coinManager.Coin >= GetCost(storeType))
        {

            Debug.Log("유닛소환");

            // 유닛을 소환하고
            Instantiate(Object_Plant_Drag);
            coinManager.Coin -= GetCost(storeType);

            CardManager.Instance.BuildMode = true;

            // 마지막 소환 시간을 현재 시간으로 업데이트
            lastSummonTime = Time.deltaTime;

            StartCoroutine(Cooldown()); // 쿨타임 코루틴을 시작            


        }

    }

    IEnumerator Cooldown()
    {
        isOnCooldown = true; // 쿨타임 시작
        yield return new WaitForSeconds(cooldown); // 쿨타임 동안 대기
        isOnCooldown = false; // 쿨타임 종료
    }
    private int GetCost(StoreType type)
    {
        switch (type)
        {
            case StoreType.Resource:
                return 50; // 예시: 리소스 유형의 코인 소모량은 10
            case StoreType.Bow:
                return 100; // 예시: 활 유형의 코인 소모량은 20
            case StoreType.Gun:
                return 200; // 예시: 총 유형의 코인 소모량은 30
            case StoreType.Sword:
                return 250; // 예시: 검 유형의 코인 소모량은 40
            case StoreType.PresentBomb:
                return 600; // 예시: 선물 폭탄 유형의 코인 소모량은 50
            default:
                return 0; // 기본값은 0으로 설정
        }
    }
}



