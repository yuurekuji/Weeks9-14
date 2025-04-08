using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLogic : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    public float times;
    public float Maxtime = 6; // max amount of time it will take after each attack to go off cooldown and attack again.

    public GameObject Enemystats;
    public UnityEvent OnAttackDeclare;

    Coroutine animations;
    IEnumerator anis;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>(); // get animator component
        animations = StartCoroutine(ani()); // starts the animation couroutine for smooth timed attacks.
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemystats.GetComponent<EnemyAttack>().EnemyHP <= 0) // this stops all coroutines when enemy is dead to make sure no extra animations are playing.
        {
            StopAllCoroutines(); //function to stop all coroutines, this is just to be safer as I can not use the reload scene function for this project yet. 
        }
    }

    private IEnumerator ani()
    {
        while (true) // checks while true and runs code, this will not stop running.
        {
            anis = Attack();
            yield return StartCoroutine(anis);
        }
    }


    // this block checks while times is below the time limit of 10 to continue to increase time,
    // Once the time has reached past then invoke the animation for attack. Then set the times back to 0.
    // This ensures a smooth transition between values and animations, otherwise with making a timer
    // normally with just time.deltatime it will be a bit laggy.

    private IEnumerator Attack() 
    {
        times = 0;
        while (times < Maxtime) // a loop to check while times is not at the max time yet.
        {
            times += Time.deltaTime; // increasing time by time.delta time
            yield return null;
        }
        OnAttackDeclare.Invoke();

    }
}