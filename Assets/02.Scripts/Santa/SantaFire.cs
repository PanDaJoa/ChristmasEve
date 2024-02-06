using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SantaFire : MonoBehaviour
{
    [Header("화살 프리팹")]
    public GameObject ArrowPrefab;

    [Header("총구")]
    public GameObject Bow;

    [Header("발사 속도")]
    public float Timer = 0;
    public float COOL_TIME = 0.8f;

    public bool AutoMode = true;

    public int PoolSize = 24;           //내나이
    public List<Attack> _arrowPool;

    // ObjectDragDown 컴포넌트를 저장할 변수
    private ObjectDragDown objectDragDown;




    private void Awake()
    {
        _arrowPool = new List<Attack>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject arrow = Instantiate(ArrowPrefab);
            _arrowPool.Add(arrow.GetComponent<Attack>());
            arrow.SetActive(false);
        }
    }

    void Start()

    {
        // ObjectDragDown 컴포넌트를 가져와서 objectDragDown 변수에 저장
        objectDragDown = GetComponent<ObjectDragDown>();
        Timer = 0f;

    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (objectDragDown == null)
        {
            return;
        }
        // 드래그 중이 아닐 때만 AutoMode 활성화
        // 즉, AutoMode는 true이고, 동시에 드래그 중이 아닐 때만 ready가 true가 됨
        bool ready = AutoMode && !objectDragDown.IsDragging();

        // 만약 타이머가 0 이하이고, ready가 true라면 (즉, AutoMode가 활성화되고, 드래그 중이 아니라면)
        if (Timer <= 0 && ready)
        {
            // 타이머를 COOL_TIME으로 다시 설정하고, Fire 메서드를 실행
            Timer = COOL_TIME;
            Fire();
        }
    }

    private void Fire()
    {

        Attack arrow = null;

        foreach (Attack a in _arrowPool)
        {
            if (!a.gameObject.activeInHierarchy)
            {
                arrow = a;
                break;
            }
        }

        if (arrow != null)
        {
            arrow.transform.position = Bow.transform.position;
            arrow.gameObject.SetActive(true);
        }
        else
        {
            // 만약 풀에서 사용 가능한 화살이 없다면 새로운 화살을 생성하고 사용할 수 있도록 설정
            GameObject newArrow = Instantiate(ArrowPrefab);
            newArrow.transform.position = Bow.transform.position;
            _arrowPool.Add(newArrow.GetComponent<Attack>());
        }

        /* Attack arrow = null;
         foreach(Attack a in _arrowPool)
         {
             if(a.gameObject.activeInHierarchy == false && arrow)
             { 
                 arrow = a;
                 break; 
             }
         }

             GameObject Arrow = Instantiate(ArrowPrefab);
             Arrow.transform.position = Bow.transform.position;
         }*/
    }
}

