using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySprite : MonoBehaviour
{
    Animator animator;

    public float times;
    public float timething = 10;


    public UnityEvent OnAttackDeclare;

    Coroutine animations;
    IEnumerator anis;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
       animations = StartCoroutine(ani());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ani()
    {
        while (true)
        {
            anis = ShiftSpriteSize();
            yield return StartCoroutine(anis);
        }
    }

    private IEnumerator ShiftSpriteSize()
    {
        times = 0;
        while (times < timething)
        {
            times += Time.deltaTime;
            yield return null;
        }
        OnAttackDeclare.Invoke();

    }
}
