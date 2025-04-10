using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Animator animator;
    public float attackstat = 40;
    public float defensestat = 30;
    public float Hp = 2000;
    public Button Attack;
    public Button weave;

    public GameObject Relics;


    // Start is called before the first frame update
    void Start()
    {
        Hp = 2000;
        attackstat = 40;
        defensestat = 30;

        animator = GetComponent<Animator>(); // calling the animator componenet so I can use it.
        
        if(Relics.GetComponent<Turnonoffgame>().Greatwolf == true) // if statments checking if the variable is true. If it is then that means it was chosen at the start of the game.
        {
            Wolfsword();
        }
        else if (Relics.GetComponent<Turnonoffgame>().Fang == true)
        {
            Fangblade();
        }
    }

    private void Update()
    {
        if (Hp <= 0)
        {

            /// this turns off all the buttons and playes the death animation when the players hp reaches below 0. 
            /// turning off the buttons ensures that the players can not interact with them anymore which stops random animations from triggering while dead.
            

            Attack.interactable = false;
            weave.interactable = false;
            animator.SetTrigger("Dead");
            Debug.Log("dead");

            return;

         
        }
    }

    public void Wolfsword() // this chunk of code is just to organize the statchanges that occur when you click a relic at the start of the game.
    {
        attackstat += 10;
        Hp += 200;
        defensestat += 5;
    }

    public void Fangblade() 
    {
        attackstat += 30;
        defensestat -= 5;
    }
}
