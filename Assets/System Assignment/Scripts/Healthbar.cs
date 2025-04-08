using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider healthBar;
    public GameObject Player;

   
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = Player.GetComponent<Player>().Hp; // this is casting the max value of the slider to be the max hp of the character
     
    }

    // Update is called once per frame
    void Update()
    {

        setsliderhealth(Player.GetComponent<Player>().Hp); // calling the function to change slider hp accordingly
    }

    public void setsliderhealth(float value)
    {
        healthBar.value = Player.GetComponent<Player>().Hp; //changes slider hp based off player hp
    }
}
