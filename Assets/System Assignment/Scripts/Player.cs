using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator animator;
    public float attackstat;
    public float defensestat;
    public float Hp;
   
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
           
            animator.SetTrigger("Dead");
            Debug.Log("dead");
            return;
        }
    }
}
