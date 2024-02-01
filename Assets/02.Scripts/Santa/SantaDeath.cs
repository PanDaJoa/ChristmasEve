using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaDeath : MonoBehaviour
{
    private bool _isTimerStarted = false;

    public float _timer = 2f;
    public float DestryTime = 0f;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Santa santa = GetComponent<Santa>();

        if (santa.SantaHealth <= 0)
        {
            _isTimerStarted = true;
            if (_isTimerStarted)
            {
                _timer -= Time.deltaTime;
                if (_timer <= DestryTime)
                {
                    Destroy(this.gameObject);

                }
            }
            
        }
        
    }
}
