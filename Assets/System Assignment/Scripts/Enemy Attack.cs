using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{

    Animator animator;

    public float EnemyHP;
    public float EnemyAttackstat;
    public float EnemyDefensestat;

    public GameObject MagicCharge;

    public GameObject playeranimations;
    public GameObject player;
    public GameObject Buffedup;
    public GameObject Bloody;


    public bool isattacking = false;

    public GameObject audi;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHP = 1500;
        EnemyDefensestat = 30;
        EnemyAttackstat = 30;

        animator = GetComponent<Animator>(); // calls the component of the animator attached.
       
    }

    // Update is called once per frame
    void Update()
    {


        /////////////////////////////////////////////////////////////
        ///////////     enemy health interactions        ///////////
        /////////////////////////////////////////////////////////////
        

        if(EnemyHP <= 0)
        {
            Debug.Log("won"); // just debugging things
            animator.SetTrigger("Death"); // this sets the death trigger to play which will trigger the death animation.
            
        }

        // this is a enragemechanic where the bos gets harder to beat as you whittle him down.
        if(EnemyHP <= 750)
        {
            EnemyDefensestat = 10;
            EnemyAttackstat = 60;
            audi.SetActive(true);
        }



        /////////////////////////////////////////////////////////////
      //////////////////    playter health interactions   ////////////////
      ////////////////////////////////////////////////////////////////////

        //if statment to check wether player has dodged correctly to nullify dmg 
        // if half blocked then only take half dmg if fully blocked take zero damage. 
        if (isattacking == true && playeranimations.GetComponent<PlayerAnimations>().ivframes == false)
        {
            player.GetComponent<Player>().Hp -= (EnemyAttackstat*2 - player.GetComponent<Player>().defensestat); // subtracts hp when it happens
        }

        else if (isattacking == true && playeranimations.GetComponent<PlayerAnimations>().ivframes == true) 
        {
            // During the time you perfect block increase the charge of a special ability.
            // when the charge is max it will stop increasing even if player dodges perfectly.
            if (MagicCharge.GetComponent<AddlistenersScript>().Charge <= 40)
            {
                MagicCharge.GetComponent<AddlistenersScript>().Charge += 1;
            }
        }
        else
        {

            //else nothing happens and hp is fine. If you perfectly parry it the player will nullify damage taken. 

           
        }
    }

    public void attack1()
    {
        animator.SetTrigger("Attack"); // plays the attack animation.

    }


    //plays the animation for a power up when the player makes the hp below 50 percent or 750.
    // this script will be added as a listenr in the addlistenerscript.
    // it will be called in there.
    public void Power()
    {
        Buffedup.SetActive(true);

        Debug.Log("nice");

    }
    //plays the animation for a Smoke when the player makes the hp below 50 percent or 750.
    // this script will be added as a listenr in the addlistenerscript.
    // it will be called in there.
    public void Splatter()
    {
        Bloody.SetActive(true);
    }

    /// <summary>
    /// The following 2 functions are going to be slotteted between animation event. 
    /// Triggers when attaacking which will turn on and off a boolean. if the boolean is on and player iv frames are not true, then dmg will go through
    /// if the attack happens and iv frames are true then attack = 0;
    /// </summary>
    /// 
    public void startattacking() // turn on boolean
    {
        isattacking = true;
    }
    public void doneattacking() // turn off boolean
    {
        isattacking = false;
    }


}
