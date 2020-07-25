//Project Landnite
//
//Created by Liam Hall on 10/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    [Header("Name")]

    public string name;

    [Header("Experience Data")]

    public int currentEXP; //Creates a public integer called currentEXP so the value within it can be used across different methods within and out of this class. It will be used for the leveling up system.
    public int currentLevel; //Creates a public integer called currentLevel so the value within it can be used across different methods within and out of this class. It will be used for the leveling up system.

    public int EXPForNextLevel;

    public int maxEXP; //Creates a private integer called maxEXP so the value within it can be used across different methods within this class. It will be used for the leveling up system.

    [Header("Currency Data")]

    public int currentMainCurrency; //Creates a public integer called currentMainCurrency so the value within it can be used across different methods within and out of this class.
    public int currentRareCurrency; //Creates a public integer called currentRareCurrency so the value within it can be used across different methods within and out of this class.


    //1 = marksman, 2 = assualt, 3 = pistol, 4 = shotgun, 5 = sniper, 6 = laser, 7 = revolver

    //Creates public integers of current reserve ammo for all for all the ammo types so the value within it can be used across different methods within and out of this class.
    [Header("Current Ammo Data")]

    public int[] currentReserveAmmo = new int[7];


    //Creates public integers of maximum reserve ammo for all for all the ammo types so the value within it can be used across different methods within and out of this class.
   
    [Header("Maximum Ammo Data")]

        public int[] maxReserveAmmo = new int[7];


    [Header("Health Data")]

    public int currentMaxHealth; //Creates a public integer called currentMaxHealth so the value within it can be used across different methods within and out of this class. It will be used to assign a maximum value of health for the player.
    public int currentHealth; //Creates a public integer called currentHealth so the value within it can be used across different methods within and out of this class. It will be used so the game will know the current health the player has.


    [Header("Player Location Data")]

    public Vector3 currentLocation; //Creates a public 3-dimenstional vector called currentLocation so the value within it can be used across different methods within and out of this class.

    Vector3 lastCurrentLocation; //Creates a private 3-dimenstional vector called lastCurrentLocation so the value within it can be used across different methods within this class. It will be used to compare side by side with the currentLocation variable.

    [Header("Inventory")]

    public GameObject[] equippedItem = new GameObject[4]; //0 = Weapon 1, 1 = Weapon 2, 3 = Weapon 3, 4 = Shield.

    public static int backpackSpace;

    public GameObject[] backpackItem = new GameObject[backpackSpace];

    public static PlayerData instance;



    [Header("Links")]

    public AudioSource camAudioSource;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {

        maxEXP = Mathf.RoundToInt((float)(50 * Mathf.Pow(currentLevel + 1, 2.9f) - 50)); //Calculates the maximum EXP required to level up and rounds the answer to the closest integer.

        CalculatingPlayerLevel(); //Starts the CalculatingPlayerLevel method.

        CalculatingMaxHealth(); //Starts the CalculatingMaxHealth method.
       
        currentHealth = currentMaxHealth; //Sets the current health of the player as the maximum health the player can possibly recieve.

        GetPlayerLocation(); //Starts the GetPlayerLocation method.

		
	}
	
	// Update is called once per frame
	void Update () 
    {

        CalculatingPlayerLevel(); //Starts the CalculatingPlayerLevel method.

        GetPlayerLocation(); //Starts the GetPlayerLocation method.

        CappingAmmo();

	}

    void CappingAmmo() //This method makes it so if the user has more ammo than they're supposed to, then decrease the ammo (currentReserveAmmo) back to their legally highest number (maxReserveAmmo). 
    {

        for (int i = 0; i < 7; i++) //Creates a for loop that cycles between all the ammo types.
        {

            if (currentReserveAmmo[i] > maxReserveAmmo[i])
            {

                currentReserveAmmo[i] = maxReserveAmmo[i];

            }

        }

    }

    float previousLevel;
    public int expEarnedThisLevel;
    void CalculatingPlayerLevel()
    {
        currentLevel = Mathf.FloorToInt(Mathf.Pow((currentEXP/2f), 10f/29f) / Mathf.Pow(5f, 20/29f));
        expEarnedThisLevel = currentEXP - Mathf.FloorToInt(50 * Mathf.Pow((currentLevel), (29f / 10f)));

        if (currentLevel != previousLevel)
        {
            camAudioSource.Play();

            print("[PLAYER] Player leveled up."); //Ouputs that the player has leveled up in the console.
            print("[PLAYER] Player level: " + currentLevel + "."); //Outputs the current level of the player in the console.

            CalculatingMaxHealth(); //Starts the CalculatingMaxHealth method.

            currentHealth = currentMaxHealth; //Sets the current health of the player as the maximum health the player can possibly recieve.

            print("[PLAYER] Current health fully replenished."); //Outputs that the player's health is equal to the player's max health in the console.

            //maxEXP = Mathf.RoundToInt((float)(50 * Mathf.Pow(currentLevel, 2.9f) - 50)); //Calculates the maximum EXP required to level up and rounds the answer to the closest integer. 50 * the current level of the player + 1 to the power of 2.9 then - 50. This is to ensure the higher level the player becomes, the longer it takes to level up again.
            maxEXP = Mathf.FloorToInt(50 * Mathf.Pow((currentLevel + 1f), (29f / 10f)));
            EXPForNextLevel = (maxEXP + 1) - currentEXP;
       
            print("[PLAYER] EXP needed for next level: " + EXPForNextLevel + "."); //Ouputs the EXP the player now needs to level up again in the console.

            expEarnedThisLevel = 0;

            previousLevel = currentLevel;
        }
         
        //This if statement finds out if the player has receieved all the EXP needed for their current level so their level becomes increased. Whenever a player levels up, their current health will be restored to max health.
       /* if (currentEXP >= maxEXP) //If currentEXP is greater or equal than maxEXP, then...
        {

            //currentLevel++; //Increment currentLevel by one.

            camAudioSource.Play();

            EXPForNextLevel -= maxEXP;

            print("Player leveled up."); //Ouputs that the player has leveled up in the console.
            print("Player level: " + currentLevel + "."); //Outputs the current level of the player in the console.

            CalculatingMaxHealth(); //Starts the CalculatingMaxHealth method.

            currentHealth = currentMaxHealth; //Sets the current health of the player as the maximum health the player can possibly recieve.

            print("Current health fully replenished."); //Outputs that the player's health is equal to the player's max health in the console.

            maxEXP = Mathf.RoundToInt((float)(50 * Mathf.Pow(currentLevel + 1, 2.9f) - 50)); //Calculates the maximum EXP required to level up and rounds the answer to the closest integer. 50 * the current level of the player + 1 to the power of 2.9 then - 50. This is to ensure the higher level the player becomes, the longer it takes to level up again.

            print("EXP needed for next level: " + (maxEXP - EXPForNextLevel) + "."); //Ouputs the EXP the player now needs to level up again in the console.

        }*/

    }

    void CalculatingMaxHealth()
    {

        currentMaxHealth = Mathf.RoundToInt((float)(80 * (Mathf.Pow(1.1301f, currentLevel)))); //Calculates the max health of the player and rounds the answer to the closes integer. 80 x 1.301 to the power of the player's current level. This is to ensure the player's health increases as the player's level increases to scale the difficulty of the game.

        print("[PLAYER] Current max health: " + currentMaxHealth + "."); //Ouputs the current maxmimum health the player can achieve in the console.

    }

    void GetPlayerLocation()
    {
        
        currentLocation = transform.position; //Finds the player's current location and saves it as a 3-dimension vector called currentLocation.

        //This if statement is to prevent the script from spamming the player's currentLocation in the console and only update it in the console when it has been changed.
        if (currentLocation != lastCurrentLocation) //If currentLocation is not the same as the location previously saved under lastCurrentLocation, then...
        {

            lastCurrentLocation = currentLocation; //Set lastCurrentLocation as currentLocation.

        }

    }

    public void AmmoPickup()
    {
        GunReworked[] gunReworked = GetComponentsInChildren<GunReworked>();
        for (int i = 0; i < 4; i++)
        {
            gunReworked[i].FindAmmoType();
        }
        print("GunReworked Finished");
    }
}
