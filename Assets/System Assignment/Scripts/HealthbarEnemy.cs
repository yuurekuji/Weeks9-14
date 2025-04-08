using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarEnemy : MonoBehaviour
{
    public Slider Health;
    public GameObject Enemy;

  

    // Start is called before the first frame update
    void Start() 
    {
        Health.maxValue = 1500; // this is casting the max value of the slider to be the 1500


    }

    // Update is called once per frame
    void Update()
    {
        setsliderhealth(Enemy.GetComponent<EnemyAttack>().EnemyHP);// calling the function to change slider hp accordingly
    }

    public void setsliderhealth(float value)
    {
        Health.value = Enemy.GetComponent<EnemyAttack>().EnemyHP;//changes slider hp based off enemy hp
    }
}
