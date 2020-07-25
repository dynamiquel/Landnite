//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using System;

public class TargetPractice : MonoBehaviour, IEnemy
{
    float health; //Creates a public float named health and sets a value for it.
    public float maxHealth = 50f;
    public int enemyLevel; //Creates a private integer called enemyLevel so the value within it can be used across different methods within this class. It will be used for the leveling up and health system.
    public int baseEXPValue; //Creates a public integer called baseEXPValue so the value within it can be used across different methods within and out of this class. It will be used for the leveling up system.
    int expValue; //Creates a private integer called expValue so the value within it can be used across different methods within this class. It will be used for the leveling up system.
    public int id {get; set;}

    public void TakeDamage(float amount)
    {
        health -= amount; //Sets health to health - amount.

        if (health <= 0f) //If health is equal or lower than 0, then...
        {
            Die(); //Calls the Die method.
        }
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        health = maxHealth;
        id = 0;
        GettingEXPValue(); //Starts the GettingEXPValue method so the EXP value of the target is set.
    }

    public void Die ()
    {
        AddingEXP(); //Starts the AddingEXP method.
        CombatEvents.EnemyKilled(this);
        Destroy(gameObject); //Destroys the gameObject.
        Debug.Log("Enemy Destroyed"); //Outputs in the console, the target has been destroyed.
    }

    void GettingEXPValue() //This method calculates the value of the EXP this target will give to the player when it is destroyed.
    {
        expValue = Mathf.RoundToInt((float)(baseEXPValue * enemyLevel * 0.7)); //This calculation statement calculates the value of the EXP this target will give to the player when it is destroyed.
    }

    public void AddingEXP() //This method finds the PlayerData script and adds the EXP gathered from this target to the player's current EXP.
    {
        PlayerData.instance.currentEXP += expValue; //Gets the currentEXP integer from the PlayerData script and adds the EXP from destroying this target on to it.

        print("Gained EXP: " + expValue + "."); //Ouputs the EXP gained from destroying this target into the console.
        print("Total EXP: " + PlayerData.instance.currentEXP + "."); //Ouputs the new total EXP of the player into the console.
    }
}
