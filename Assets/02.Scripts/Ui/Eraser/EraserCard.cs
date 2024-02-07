using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraserCard : MonoBehaviour
{
    /*private bool isDragging = false;*/
    /*public AudioSource DeleteSound;*/

    public GameObject DeletePrefab;

    public void OnClickEraser()
    {
        Debug.Log("눌림");
        GameObject.Instantiate(DeletePrefab);
    }
}
