using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationLogs : MonoBehaviour
{
    public Animator playeranimations;
    public Boolean run = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playerattack()
    {
        playeranimations.SetTrigger("Attack1");
    }

    public void playerrun()
    {

        run =  !run;

        if (run == true)
        {
            playeranimations.SetFloat("speed", 1);
        }
        else
        {
            playeranimations.SetFloat("speed", 0);

        }

    }
    

}
