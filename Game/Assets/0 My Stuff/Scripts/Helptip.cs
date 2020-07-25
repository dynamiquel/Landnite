using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Helptip : MonoBehaviour {


    TMPro.TMP_Text helptipUI; //Creates a TMP_Text reference called helptipUI.

    public int switchTime = 15; //Creates a public integer called switchTime and assigns a value of 15 to it.

	string[] helptip = new string[11]; //Creates a string array with a size of 11 and calls it helptip.


    private void Start() //This method is called when the class is started.
    {

        Helptips(); //Calls the Helptips method.

    }

    void Helptips() //This method assigns the helptip array with a list of strings.
    {

        helptip[0] = "Want something to do? How about, kill all the cats.";
        helptip[1] = "You can equip up to three weapons.";
        helptip[2] = "Want to harm yourself? Press L";
        helptip[3] = "Accidently discarded the wrong item? Press L whiles in Inventory to retrieve it";
        helptip[4] = "Access the Character Hub by pressing TAB";
        helptip[5] = "Don't get too close to a cat. They hurt!";
        helptip[6] = "Ran out of backback space? Why don't you discard the items you no longer want";
        helptip[7] = "The higher the gear rarity, the harder they are to find, however, the gear tends to be better";
        helptip[8] = "Gear rarities in order from the most common goes: Common, Uncommon, Rare, Heroic, Legendary and Mythic";
        helptip[9] = "The higher level the weapon, the more damage it will output";
        helptip[10] = "The higher level the shield, the more capacity it will hold and the faster the recharge rate";


        StartCoroutine(DisplayingHelptips()); //Calls the method, DisplayingHelptips.

	}

    IEnumerator DisplayingHelptips() //This method chooses a random number between 0 and the length of the array, saves the random number in an integer called helptipToDisplay, and displays that helptip in a label on screen. This method is then refreshed every certain amount of time so a new helptip is displayed on screen.
    {

        int helptipToDisplay = Random.Range(0, helptip.Length); //Chooses a random number between 0 and the length of the helptip array, saves this number in a new helptipToDisplay integer.

        helptipUI = gameObject.GetComponent<TextMeshProUGUI>(); //Gets the text component of the current game object and assigns it to the helptipUI text label.

        helptipUI.text = helptip[helptipToDisplay]; //Sets the text in the helptipUI label equal to the random helptip.

        yield return new WaitForSeconds(switchTime); //Pauses the method for a certain number of seconds.

        StartCoroutine(DisplayingHelptips()); //Calls this method again so another random helptip is displayed.

    }


}
