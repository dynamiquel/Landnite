using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public bool isPercentage;

    public float value;

    public void OnTriggerEnter(Collider collision) //This method is called when the game object tagged 'Player' is in contact with the money (this game object). It gives this money to the player and then destroys this game object so it cannot be picked up again.
    {
        if (collision.gameObject.tag == "Player") //If the gameobject that collided with this game object has a tag of 'Player (if the player collided with this game object), then
        {
            if (PlayerData.instance != null) //If there is a PlayerData instance present, then...
            {
                if (!isPercentage) //If the moneyType of this script is 1 (cash), then...
                    PlayerData.instance.currentHealth += (int)value;

                else
                {
                    int newValue = Mathf.RoundToInt(PlayerData.instance.currentMaxHealth * value);
                    PlayerData.instance.currentHealth += newValue;
                }

                if (PlayerData.instance.currentHealth > PlayerData.instance.currentMaxHealth)
                    PlayerData.instance.currentHealth = PlayerData.instance.currentMaxHealth;

                Destroy(gameObject); //Destroys the game object this script is attached to.
            }
        }
    }
}
