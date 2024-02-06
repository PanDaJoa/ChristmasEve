using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBoom_Runaway : MonoBehaviour
{
    public float MovementSpeed = 0.8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.right;
        transform.position += (Vector3)(dir * MovementSpeed) * Time.deltaTime;
        dir = dir.normalized;
    }
}
