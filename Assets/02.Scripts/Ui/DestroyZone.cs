using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Arrow" || otherCollider.tag == "Child" )
        {
            otherCollider.gameObject.SetActive(false);
        }
        else
        {
            Destroy(otherCollider.gameObject);
        }
    }
}
