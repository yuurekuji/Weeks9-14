using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void attack()
    {
        animator.Play("HeroKnight_Attack1");
    }

    public void dodge()
    {
        animator.Play("HeroKnight_Block");
    }
}