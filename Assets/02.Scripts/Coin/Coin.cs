using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float Speed = 7f;
    private GameObject _target;
    public AudioSource CoinSound;

    private bool _isFlying = false; // 날아가는 중인지 여부를 나타내는 플래그

    void Start()
    {
        _target = GameObject.Find("Wallet");
    }

    void Update()
    {
        if (_isFlying) // 날아가는 중일 때에만 이동
        {
            Vector2 dir = _target.transform.position - transform.position;
            dir.Normalize();
            transform.position += (Vector3)(dir * Speed) * Time.deltaTime;

            // 만약 Coin이 Wallet에 닿았다면
            if (Vector2.Distance(transform.position, _target.transform.position) < 0.1f)
            {
                Collect();
            }
        }
    }

    private void OnMouseDown() // 마우스 클릭 시 호출되는 메서드
    {
        if (!_isFlying) // 날아가는 중이 아닐 때에만 동작
        {
            _isFlying = true; // 날아가는 상태로 변경
        }
    }

    // Coin이 Wallet에 닿았을 때 호출될 메서드
    private void Collect()
    {
        CoinManager.instance.Coin += 50; // 점수를 50 증가시킴
        Destroy(gameObject); // 코인 오브젝트 파괴
    }

}
