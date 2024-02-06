using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Store
{
    Resource,                //자원 50
    Bow,                        //화살 100
    Gun,                        //총 200
    Sword,                    //검 250
    PresentBomb ,       //선물폭탄  600
}

public class ObjectCard : MonoBehaviour
{
    public GameObject Object_Plant_Drag;

    public float cooldown = 3f; // 쿨타임을 3초로 설정

    private float lastSummonTime; // 마지막으로 소환한 시간을 저장
   
    private bool isOnCooldown = false; // 쿨타임 상태를 저장하는 플래그

    // 카드를 클릭하면
    // 드래그 유닛 이미지 바꾸는 코드
    /*  public Sprite mySprite;
        public Container[] containers;*/
    // 카드를 클릭하면
    public void OnClickCard()
    {
        if (CardManager.Instance.BuildMode)
        {
            return;
        }

        // 쿨타임이 아니면
        if (!isOnCooldown)
        {
            Debug.Log("유닛소환");

            // 유닛을 소환하고
            Instantiate(Object_Plant_Drag);

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
}


