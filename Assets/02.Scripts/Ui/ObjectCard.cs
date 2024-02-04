using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCard : MonoBehaviour
{
    public GameObject Object_Plant_Drag;

    public float cooldown = 3f; // 쿨타임을 3초로 설정

    private float lastSummonTime; // 마지막으로 소환한 시간을 저장
   
    private bool isOnCooldown = false; // 쿨타임 상태를 저장하는 플래그
    
    // 드래그 유닛 이미지 바꾸는 코드
    /*  public Sprite mySprite;
        public Container[] containers;*/


    // 카드를 클릭하면
    public void OnClickCard()
    {
        // 쿨타임이 아니면
        if (!isOnCooldown) 
        {
            Debug.Log("유닛소환");
            // 유닛을 소환하고
            Instantiate(Object_Plant_Drag);
            
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


