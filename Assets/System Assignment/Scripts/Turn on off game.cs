using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turnonoffgame : MonoBehaviour
{

    public GameObject canvas;

    public GameObject Game;

    public bool Fang = false;
    public bool Greatwolf = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //This chunk of code turns on a boolean which will effect the stats of the player depending on which they have chosen.

    // it sets the current canvas to false and immediately turns on the game canvas to allow the game to run.
    public void GreatwolfSword()
    {
        Greatwolf = true;

        canvas.SetActive(false);
        Game.SetActive(true);
    }

    public void FangBlade()
    {
        Fang = true;
        canvas.SetActive(false);
        Game.SetActive(true);
    }

}
