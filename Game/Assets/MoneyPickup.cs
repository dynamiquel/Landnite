using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{
    public char moneyTier;
    public char moneyType;
    int money;

    void Start() //This method is called when the class is first launched and it calculates the value of the money.
    {
        if (moneyType == '1') //If the moneyType char is 1 (the money is cash), then...
        {
            if (moneyTier == '1') //If the moneyTier char is 1 (the money is of the lowest tier), then...
                money = Random.Range(1, 10); //Choose a random number between a certain range to be the money value.

            if (moneyTier == '2') //If the moneyTier char is 2 (the money is of the second lowest tier), then...
                money = Random.Range(10, 20); //Choose a random number between a certain range to be the money value.
        }

        if (moneyType == '2') //If the moneyType char is 2 (the money is rare valuables), then...
        {
            if (moneyTier == '1')  //If the moneyTier char is 1 (the money is of the lowest tier), then...
                money = 1; //Sets the money value to 1.
            if (moneyTier == '2') //If the moneyTier char is 2 (the money is of the second lowest tier), then...
                money = 4; //Sets the money value to 4.
        }
    }

    public void OnTriggerEnter(Collider collision) //This method is called when the game object tagged 'Player' is in contact with the money (this game object). It gives this money to the player and then destroys this game object so it cannot be picked up again.
	{
        if (collision.gameObject.tag == "Player") //If the gameobject that collided with this game object has a tag of 'Player (if the player collided with this game object), then
        {
            if(PlayerData.instance != null) //If there is a PlayerData instance present, then...
            {
                if (moneyType == '1') //If the moneyType of this script is 1 (cash), then...
                    PlayerData.instance.currentMainCurrency += money; //Add the value of the cash to the player's main currency.

                if (moneyType == '2') //If the moneyType of this script is 2 (rare valuables), then...
                    PlayerData.instance.currentRareCurrency += money; //Add the value of the rare valuables to the player's rare currency.

                Destroy(gameObject); //Destroys the game object this script is attached to.
            }
        }
    }
}
