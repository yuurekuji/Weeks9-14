using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;

    public Animator enemy;


    public float playerattack;

    public bool ivframes = false;

    public GameObject Enemystats;

    public GameObject Playerstats;

    public Button Attack;
    public Button weave;


    // this is a boolean to track the cool down of the button so players don't instantly spam it. 
    // the floats are the actual timer itself, having a max time and a current time.

    public bool oncooldown = false; 
    public float time = 0f;
    public float maxtime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // grabbing the component from the animator.
    }

    // Update is called once per frame
    void Update()
    {

        
        if (oncooldown == true)
        {
            time += Time.deltaTime;
            Attack.interactable = false;

        }

        if (time >= maxtime)
        {
            oncooldown = false;
            Attack.interactable = true;
            time = 0f;


        }
    }

    public void attack()
    {
        animator.SetTrigger("Attack"); // this plays the animation for the attack by activating the trigger
        enemy.SetTrigger("Damage"); // this plays the animation for enemies getting hit.
        Enemystats.GetComponent<EnemyAttack>().EnemyHP -= (Playerstats.GetComponent<Player>().attackstat*2 - Enemystats.GetComponent<EnemyAttack>().EnemyDefensestat);

        // this is the damage formula derived by enemy hp -= player attack*2 - enemy def.

        oncooldown = true;
        
    }

    public void Dodge()
    {
        animator.SetTrigger("Dodge"); // this plays the animation for the perfect dodge / parry by activating the trigger.
    }



    /// <summary>
    /// The following 2 functions are going to be slotteted between animation event. 
    /// If the enemy attacks and you click the dodge button at the right time, the damage will be nullified. 
    /// there will also be 2 functions inside the enemy logic doing the same thing however a shorter time frame and called isattacking instead.
    /// </summary>
    /// 
    public void turnIVFramesOn() // function that can be called to turn on the boolean for IV frames
    {
        ivframes = true;
    }
    public void turnIVFramesOff() // function that can be called to turn off the boolean for IV frames
    {
        ivframes = false;
    }
}
