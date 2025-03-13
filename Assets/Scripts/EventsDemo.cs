using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsDemo : MonoBehaviour
{
    public Transform size;

    public UnityEvent OnTimerHasFinished;

    public float timerlength = 3;
    public float timerNow;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MouseJustEnteredImage()
    {
        Debug.Log("the mouse has arrived");
        size.localScale = Vector3.one * 1.2f;
    }

    public void MouseJustLeftImage()
    {
        Debug.Log("the mouse has departed");
        size.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        timerNow += Time.deltaTime;
        if(timerNow > timerlength)
        {
            OnTimerHasFinished.Invoke();

            timerNow = 0;
        }
    }
}
