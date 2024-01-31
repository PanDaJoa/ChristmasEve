using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCard : MonoBehaviour
{
    public GameObject Object_Plant_Drag;

    // 카드를 클릭하면
    public void OnClickCard()
    {
        Debug.Log("Hello");

        GameObject.Instantiate(Object_Plant_Drag);
    }
}
