using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Container : MonoBehaviour
{
    // 드래그 중인 오브젝트를 참조하는 변수
    private ObjectDragDown _dragDown;

    // 오브젝트가 이미 생성되었는지를 나타내는 플래그
    private bool _full = false;



   

    // 다른 오브젝트의 콜라이더가 이 오브젝트의 콜라이더와 충돌한 경우 호출되는 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 만약 _full이 true라면, 즉 이미 오브젝트가 생성되었다면 더 이상의 처리를 하지 않고 함수를 종료합니다.
        if (_full)
        {
            return;
        }
        // 충돌을 했을 때 other.GetComponent로 오브젝트다운을 불러오고 _dragDown에다가 저장한다.
        _dragDown = other.GetComponent<ObjectDragDown>();
        Debug.Log("충돌");
    
    }
    // 다른 오브젝트의 콜라이더가 이 오브젝트의 콜라이더와의 충돌에서 벗어난 경우 호출되는 함수
    private void OnTriggerExit2D(Collider2D other)
    {
        // 만약 _full이 true라면, 즉 이미 오브젝트가 생성되었다면 더 이상의 처리를 하지 않고 함수를 종료합니다.
        if (_full) 
        {
            return;
        }
        Debug.Log("벗어남");

        // 충돌에서 벗어났으므로 _dragDown 변수를 null로 설정합니다. (충돌이 일어난 자리마다 생성이 안되게 만들어줌)
        _dragDown = null;


    }


    private void Update()
    {
        // 만약 _full이 false이고, _dragDown이 null이 아니라면, 즉 오브젝트가 아직 생성되지 않았고 드래그 중인 오브젝트가 있다면
        if (!_full && _dragDown != null && Input.GetMouseButtonDown(0))
        {
            // 유닛의 프리팹을 저장
            GameObject unitdown = _dragDown.gameObject;

            // 드래그된 유닛을 제거
            Destroy(_dragDown.gameObject);

            Debug.Log(0);
            // 유닛을 타일의 위치에 생성
            Instantiate(unitdown, this.transform.position, Quaternion.identity);

            // 오브젝트 생성 플래그를 true로 설정 (미리 깔아져 있는 곳에 안깔리게 한다.)
            _full = true;
        }

    }
}


