using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class AddlistenersScript : MonoBehaviour
{
    UnityEvent MyEvent = new UnityEvent();
    UnityEvent MyEvent2 = new UnityEvent();
    public float i = 0;
    void Start()
    {
        
        MyEvent.AddListener(MyAction);
        MyEvent2.AddListener(MyAction2);
    }

    void Update()
    {
        
        if (Input.GetKeyDown("q") && MyEvent != null)
        {
            Debug.Log("Charging");

            MyEvent.RemoveListener(MyAction);

        }

      
        if (Input.GetKeyDown("k") && MyEvent2 != null)
        {
            //Begin the action
            MyEvent2.Invoke();
            i += 1;
        }

        if(Input.GetKeyDown("i") && MyEvent != null)
        {
            MyEvent.Invoke();

        }
    }

    void MyAction()
    {
        
        Debug.Log("Do Stuff");
    }

    void MyAction2()
    {
        Debug.Log("Life is good");
    }
}