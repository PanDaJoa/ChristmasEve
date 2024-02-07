using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectEraser : MonoBehaviour
{
    public bool Batched;
    public bool IsDragging;
    public AudioSource DeleteSound;
    

    private Collider2D containerCollider;

    private void Start()
    {
        // scene에 있는 사운드소스가 있는 오브젝트
        GameObject SoundController = GameObject.Find("SoundController_Delete");
        // 그 오브젝트에서 audiosource component를 가져오기
        DeleteSound = SoundController.GetComponent<AudioSource>();
    }
    public void Update()
    {
        
        if (!Batched)
        {
            // 1. 마우스를 따라댕기다가
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = mousePosition;

        }
        // 왼쪽 마우스 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            IsDragging = true;
        }

       // 왼쪽 마우스 버튼을 뗐을 때
        if (Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
            Destroy(gameObject);
            
        }
    }
    void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (IsDragging && otherCollider.CompareTag("Santa"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Batched = true;
                
            }
            Santa santa = otherCollider.GetComponent<Santa>();
            if (santa != null)
            {
                
                // Destroy(otherCollider.gameObject);
                santa.Kill2(); // 산타의 체력을 0으로 만들어 산타를 죽입니다.
                                       // 이렇게 하면 산타가 죽을 때의 코드가 실행되어 SantaDeathPrefab과 ContainerPrefab이 생성됩니다.
            }
            DeleteSound.Play();
            Destroy(this.gameObject);
            
        }
    }
}
