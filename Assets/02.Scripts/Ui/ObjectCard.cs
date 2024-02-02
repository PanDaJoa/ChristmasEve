using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectCard : MonoBehaviour
{
    public GameObject Object_Plant_Drag;

    public float Timer = 2;
    public float Cool_Timer = 0;


    private bool Test = false;

    // 드래그 유닛 이미지 바꾸는 코드
    /*  public Sprite mySprite;
        public Container[] containers;*/


    // 카드를 클릭하면
    public void OnClickCard()
    {
        if (Test)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Test = true;
            }
        }
      

        Debug.Log("유닛소환");

        GameObject.Instantiate(Object_Plant_Drag);
        
        /* for (int i = 0; i < containers.Length; i++) 
         {
          containers[i].GetComponent<SpriteRenderer>().sprite = mySprite;
         }*/



    }

}
