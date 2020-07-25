using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCache : MonoBehaviour
{
    public char moneyCacheTier;
    char moneyType;
    int money;

    void Start() //This method is called when the script is first started.
    {
        RNG(); //Calls the RNG method.
    }

    void RNG() //This method calculates what money type and how much of it will be stored in the money cache by the use of random number generators.
    {
        if (moneyCacheTier == '1') //If the money cache is a tier 1 cache (cash only cache), then...
        {
            moneyType = '1'; //Sets the moneyType to 1 (cash).

            //1 in 20 chance.
            int type1MoneyChance = Random.Range(1, 20); //Creates a new int that will store a random number between 1 and 2.

            if (type1MoneyChance > 1) //If the moneChance is more than 1 (If user was unlucky), then...
            {
                money = Random.Range(1, 10); //Make the value of the money a random number between 1 and 20.
            }
            if (type1MoneyChance == 1) //If the moneyChance is 0 (the user was lucky), then...
            {
                money = Random.Range(10, 20); //Make the value of the money a random number between 10 and 20.
            }
        }
        if (moneyCacheTier == '2') //If the moeny cache is a tier 2 cache 
        {
            //1 in 50 chance.
            int type2MoneyChance = Random.Range(1, 50);

            if (type2MoneyChance > 1) //If the user was unlucky, then...
            {
               moneyType = '1'; //Sets the moneyType to 1 (cash).

                //1 in 20 chance.
                int type1MoneyChance = Random.Range(1, 20); //Creates a new int that will store a random number between 1 and 2.

                if (type1MoneyChance > 1) //If the moneChance is more than 1 (If user was unlucky), then...
                {
                    money = Random.Range(1, 10); //Make the value of the money a random number between 1 and 20.
                }
                if (type1MoneyChance == 1) //If the moneyChance is 0 (the user was lucky), then...
                {
                    money = Random.Range(10, 20); //Make the value of the money a random number between 10 and 20.
                }
            }

            if (type2MoneyChance == 1) //If the user was lucky, then...
            {
                moneyType = '2'; //Sets the moneyType char to 2 (rare currency).
                money = 1; //The money value is set to 1.
            }
        }
    }

    public void OpenCache() //This public method is called through the Player.
    {
        if(PlayerData.instance != null) //If there is an instance of PlayerData, then...
        {
            if (moneyType == '1') //If money type is 1 (cash), then...
                PlayerData.instance.currentMainCurrency += money; //Adds the value of the money to the player's main currency.

            if (moneyType == '2') //If money type is 2 (rare currency), then...
                PlayerData.instance.currentRareCurrency += money; //Adds the value of the money to the player's rare currency.

            Destroy(gameObject); //Destroys the game object this script is attached to.
        }
    }
}
