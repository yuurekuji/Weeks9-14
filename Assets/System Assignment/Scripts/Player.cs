using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Animator animator;
    public float attackstat;
    public float defensestat;
    public float Hp;
    public Button Attack;
    public Button weave;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 2000;
        attackstat = 40;
        defensestat = 30;

        animator = GetComponent<Animator>(); // calling the animator componenet so I can use it.
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
}
