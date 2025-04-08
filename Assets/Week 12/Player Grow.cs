using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.Animations;

public class PlayerGrow : MonoBehaviour
{
    public bool Growth;

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

    public void giant()
    {
        animator.Play("BlockFlash");

        Growth = !Growth;
        if (Growth == true)
        {
            Vector3 Giant = transform.localScale;
            Giant.x = 5;
            Giant.y = 5;
            transform.localScale = Giant;
        }

        else
        {
            Vector3 Giant = transform.localScale;
            Giant.x = 2;
            Giant.y = 2;
            transform.localScale = Giant;
        }
    
    }
}
