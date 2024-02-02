using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackType
{
    Bullet,
    Arrow
}

public class Attack : MonoBehaviour
{
    public float Speed = 3f;
    public AttackType AType;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 dir = Vector2.right;
        transform.position += (Vector3)(dir * Speed) * Time.deltaTime;
    }
}
