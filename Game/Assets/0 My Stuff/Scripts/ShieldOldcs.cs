//Project Landnite
//
//Created by Liam Hall on 15/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldD : MonoBehaviour
{

    //Public variables allow the variables to be accessed by other classes. If the public variable is not hidden in inspector, their values can be assigned within the Unity Inspector instead of the script. This allows different game objects to use the same script but have different variables, such as multiple weapons having different statistics but use the same script.
    //Headers allow variables to be seperated in the Unity Inspector and is only for aesthetic purposes.
    [Header("Descriptions")]
    public string name; //Creates a public string called 'name'.
    public string description; //Creates a public string called 'description'.
    public char rarity; //Creates a public char called 'rarity'. //c = common, u = uncommon, r = rare, e = epic, h = heroic, l = legendary, m = mythic

    [Header("Statistics")]
    public int level; //Creates a public int called 'level'
    public int baseCapacity; //Creates a public int called 'baseCapacity'.
    public int baseRechargeRate; //Creates a public int called 'baseRechargeRate'.
    public float rechargeDelay; //Creates a public float called 'rechargeDelay'.

    public int capacity; //Creates a public int called 'capacity'.
    public int currentCapacity; //Creates a public int called 'currentCapacity'.
    public bool isNotFullCapacity; //Creates a public bool called 'isNotFullCapacity'.
    public bool isRecharging; //Creates a public bool called 'isRecharging'.
    public bool isDelaying; //Creates a public bool called 'isDelaying'.
    public int rechargeRate; //Creates a public int called 'rechargeRate'.

    [Header("Value")]
    public int baseSellValue; //Creates a public int called 'baseSellValue'.
    [HideInInspector]
    public int sellValue; //Creates a public int called 'sellValue'.
    [HideInInspector]
    public int buyValue; //Creates a public int called 'buyValue'.

    IEnumerator coroutine;



    // Use this for initialization
    void Start() //This method is called before any other method (except Awake).
    {

        capacity = baseCapacity; //Sets the capacity value to the value stored within baseCapacity.
        rechargeRate = baseRechargeRate; //Sets the rechargeRate to the value stored within baseRechargeRate.

        sellValue = Mathf.RoundToInt((float)(baseSellValue * Mathf.Pow(1.1301f, level))); //Gets the integer stored within 'baseSellValue', multiplies it by 1.1301 to the power of the integer stored within 'level', then gets the value stored in 'level', multiplies it by 3 and takes it away from the previous answer. It then makes sellValue equal to the previous answer. 
        buyValue = sellValue * 2; //Multiplies the integer stored within 'sellValue' by 2 and stores it within 'buyValue'.

    }

    // Update is called once per frame
    void Update()
    {

        TakeDamage();

        CheckShieldParameters();
    
    }

    void CheckShieldParameters()
    {

        if (currentCapacity < capacity) //If the 'currentCapacity' of the shield is slower than its total 'capacity', then...
        {

            isNotFullCapacity = true; //Set the 'isNotFullCapacity' boolean to true.

        }

        else //Else...
        {

            isNotFullCapacity = false; //Set the 'isNotFullCapacity' boolean to false.

        }

        if (isNotFullCapacity && !isRecharging) //If the 'isNotFullCapacity' boolean is true (shield doesn't have full capacity) and the 'isRecharging' bool is false (shield isn't recharging), then...
        {

            StartCoroutine(ShieldRegeneration2(true)); //Start the coroutine called 'ShieldRegeneration2' and send the 'isDelaying' boolean to it as true.

        }

        if (isNotFullCapacity && isRecharging) //If the 'isNotFullCapacity' boolean is true (shield doesn't have full capacity) and the 'isRecharging' bool is true (shield is recharging), then...
        {

            StartCoroutine(ShieldRegeneration2(false)); //Start the coroutine called 'ShieldRegeneration2' and send the 'isDelaying' boolean to it as false.

        }

    }

    IEnumerator ShieldRegeneration() //Creates a method that allows tasks to be paused with time and it calls it 'ShieldRegeneration'. This method
    {

        isDelaying = true;

        if (isDelaying)
        {
            print("Shield Recharge Delay Started");

            yield return new WaitForSeconds(rechargeDelay);
            
            print("Shield Recharge Delay Ended");

            isDelaying = false;

        }

        if (!isDelaying)
        {
            
            print("Shield Recharging...");

            isRecharging = true;

            while (currentCapacity < capacity)
            {

              //  currentCapacity += (rechargeRate * Time.deltaTime);

            }

            if (currentCapacity >= capacity)
            {
                
                currentCapacity = capacity;
                isNotFullCapacity = false;
                isRecharging = false;

                print("Shield Fully Recharged");

            }

        }


    }



    IEnumerator ShieldRegeneration2(bool isDelaying) //Creates a method that allows tasks to be paused with time and it calls it 'ShieldRegeneration2'. This method
    {

        if (isDelaying) //If the 'isDelaying' boolean is equal to true (shield hasn't passed their recharge delay yet), then...
        {

            print("Shield Recharge Delay Started"); //Prints "Shield Recharge Delay Started" in the console.

            yield return new WaitForSeconds(rechargeDelay); //Tells the program to pause this task for the number of seconds stored within the 'rechargeDelay' float.

            print("Shield Recharge Delay Ended"); //Prints "Shield Recharge Delay Ended" in the console.

            isDelaying = false; //Sets the 'isDelaying' boolean to false. (Shield has past its recharge delay)


        }

        if (!isDelaying)  //If the 'isDelaying' boolean is equal to false (shield has passed their recharge delay), then..
        {


            if (isNotFullCapacity) //If the 'isNotFullCapactity' boolean is equal to true (the shield hasn't reached its maximum capacity), then...
            {

                Regeneration();

            }

            if (!isNotFullCapacity) //If the 'isNotFullCapactity' boolean is equal to false (the shield has reached its maximum capacity), then...
            {

                currentCapacity = capacity; //Set the value stored wihin 'currentCapacity' to the value stored within 'capacity'. (Set the shield's current capacity equal to its maximum capacity, this is because sometimes the shield's current capacity can go over its maximum capacity otherwise.

                isRecharging = false; //Set the 'isRecharging' boolean to false (let the script know the shield is not currently recharging).

                print("Shield Fully Recharged"); //Prints "Shield Fully Recharged" in the console.


            }
        }
    }

    void Regeneration()
    {


        isRecharging = true; //Set the 'isRecharging' boolean to true (let the script know the shield is currently recharging).

        print("Shield Recharging..."); //Prints "Shield Recharging..." in the console.

        currentCapacity = Mathf.RoundToInt((float)(currentCapacity + (rechargeRate * Time.deltaTime))); //Makes the value stored within 'currentCapacity' (makes the shield's current capacity) equal to 'currentCapacity' + (the value stored within 'rechargeRate' * Time.deltaTime).


    }

    public bool tookDamage;

    void TakeDamage()
    {

        if (tookDamage)
        {
            StopAllCoroutines();
            isRecharging = false;
            ShieldRegeneration2(true);
            tookDamage = false;

        }

    }
            
}
