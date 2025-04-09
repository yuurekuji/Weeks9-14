using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class AddlistenersScript : MonoBehaviour
{
    UnityEvent MyEvent = new UnityEvent();
    UnityEvent MyEvent2 = new UnityEvent();

    public float Charge = 0;
    void Start()
    {
        
        MyEvent.AddListener(UseMagic);
        MyEvent2.AddListener(MyAction2);
    }

    void Update()
    {
        
        if (Input.GetKeyDown("q") && MyEvent != null)
        {
            Debug.Log("Charging");

            MyEvent.RemoveListener(UseMagic);

        }

      
        if (Input.GetKey("s") && MyEvent2 != null)
        {
            //Begin the action
            MyEvent2.Invoke();
      
        }

        if(Input.GetKeyDown("i") && MyEvent != null)
        {
            MyEvent.Invoke();

        }
    }

    void UseMagic()
    {
        
        Debug.Log("Charge:" + i);


    }

    void MyAction2()
    {
        i += 1;
    }
}