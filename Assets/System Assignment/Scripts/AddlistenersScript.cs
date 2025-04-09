using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AddlistenersScript : MonoBehaviour
{
    UnityEvent MagicReveal = new UnityEvent();
    UnityEvent DestroyButton = new UnityEvent();
    UnityEvent PoweredUP = new UnityEvent();

    public float Charge = 0;

    public Button Magicbutton;

    public GameObject ChargeImage1;
    public GameObject ChargeImage2;
    public GameObject ChargeImage3;
    public GameObject ChargeImage4;

    public GameObject Aura;

    public GameObject MAGICBOOM;

    public bool usedMagic = false;

    
    public GameObject Enemy;

    void Start()
    {
        
        // calls the function from the other script.
        // this allows us to use as a listener.

        EnemyAttack enemyPOWER = Enemy.GetComponent<EnemyAttack>();

        PoweredUP.AddListener(enemyPOWER.Power);
        PoweredUP.AddListener(enemyPOWER.Splatter);

        MagicReveal.AddListener(UseMagic);
        DestroyButton.AddListener(Destroybutton);

    }

    void Update()
    {

        // checks if enemy hp is below half and then plays the powered up animation when it is.

        if(Enemy.GetComponent<EnemyAttack>().EnemyHP <= 750)
        {
            PoweredUP.Invoke();

        }
        //if the used magic is true after they press the button then turn off the button and remove the listener of the magic function.

        if(usedMagic == true) 
        {


            DestroyButton.Invoke();

            MagicReveal.RemoveListener(UseMagic);

            Aura.SetActive(false);
        }


        // this conditional checks if the charge is greator or less than the desired value
        // this also checks if the used magic is false, if it is then it can run, if it isnt then it will not run.. 
        // if the value returns as true then I will turn on the function to display the magic button function.

        if (Charge >=40 && MagicReveal != null && usedMagic == false) 
        {
            Debug.Log("Charged");

            MagicReveal.Invoke();


            //displays the full charge if the player misses some dodges or half dodges in the end.
            displayCharge1();
            displayCharge2();
            displayCharge3();
            displayCharge4();

            // this ensures that even if the player miss times the dodge and doesnt get the full ammount despite having everything showing, to display another signifier to ensure player understands when theya re fully charged.
            Aura.SetActive(true);


        }

      
        // these are all checks to display the mana ammount if the player perfect dodges 
        // if they are then start the function to display the mana ammount.

        if (Charge >= 7 && Charge <= 11)
        {
            //Begin the action
            displayCharge1();
        }

        if(Charge >= 17 && Charge <= 21)
        {
            displayCharge2();
        }
        if (Charge >= 27 && Charge <= 31)
        {
            displayCharge3();
        }
        if (Charge >= 37 && Charge <= 40)
        {
            displayCharge4();
        }
    }

    // function to display the magic button as interactable. 
    // we leave the button as interacctable false first and not game object.setactive false so that the player understands that there is a magic and that they need to figure out how to reach it.
    void UseMagic() 
    {
        
        Debug.Log("Charge:" + Charge);
        Magicbutton.interactable = true; 

    }


    //function to fire off magic
    // this will be utilized inside the button that is why it is a public void instead of a private.
    // turns the usedmagic variable to be true which disables the button up top
    public void FireOffMagic()
    {

        usedMagic = true;
        Enemy.GetComponent<EnemyAttack>().EnemyHP *= 0.5f ;

        //does the magic explosions animation
        MAGICBOOM.SetActive(true);
    }


    //removes the symbols as well as the interactability of the buttons.
    // this makes the magic a one time use thing.
    void Destroybutton()
    {
        Magicbutton.interactable = false;

        ChargeImage1.SetActive(false);
        ChargeImage2.SetActive(false);
        ChargeImage3.SetActive(false);
        ChargeImage4.SetActive(false);


    }


    // all of these functions just displays the image for the mana.
    // they are called when the condition is true above.
    void displayCharge1()
    {
        ChargeImage1.SetActive(true);
    }
    void displayCharge2()
    {
        ChargeImage2.SetActive(true);
    }
    void displayCharge3()
    {
        ChargeImage3.SetActive(true);
    }
    void displayCharge4()
    {
        ChargeImage4.SetActive(true);
    }
}