//Project Landnite
//
//Created by Liam Hall on 12/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HUDPlayerData : MonoBehaviour
{

    int[] incrementValue = new int[10];


    [Header("Links - Labels")]


    public TMPro.TMP_Text currentHealthUI; //Creates a public text variable, calls it 'currentHealthUI' and references it to a TMPro.TMP_Text game object.

    public TMPro.TMP_Text currentShieldUI; //Creates a public text variable, calls it 'currentShieldUI' and references it to a TMPro.TMP_Text game object.

    public TMPro.TMP_Text expIncrementUI; //Creates a public text variable, calls it 'expIncrementUI' and references it to a TMPro.TMP_Text game object.

    public TMPro.TMP_Text levelUI; //Creates a public text variable, calls it 'levelUI' and references it to a TMPro.TMP_Text game object.

    public TMPro.TMP_Text[] incrementUI = new TMPro.TMP_Text[10];


    [Header("Links - Sliders")]

    public Slider expFill; //Creates a public slider, calls it 'expFill' and references it to a slider.
    public Slider healthFill; //Creates a public slider, calls it 'healthFill' and references it to a slider.
    public Slider shieldFill; //Creates a public slider, calls it 'shieldFill' and references it to a slider.

    float expPercentage; //Creates a float called 'expPercentage'.
    float healthPercentage; //Creates a float called 'healthPercentage'.
    float shieldPercentage; //Creates a float called 'shieldPercentage'.

    int previousCurrentEXP; //Creates an integer called 'previousCurrentEXP'.

    int expGaining; //Creates an integer called 'expGaining'.
    int oldEXPGaining; //Creates an integer called 'oldEXPGaining'.

    public int[] previousIncrement = new int[10];
  

    public void OnEnable()
    {
        currentHealthUI = GameObject.Find("Current Health Text").GetComponent<TextMeshProUGUI>();
        currentShieldUI = GameObject.Find("Current Shield Text").GetComponent<TextMeshProUGUI>();
        expIncrementUI = GameObject.Find("EXP Increment Text").GetComponent<TextMeshProUGUI>();
        levelUI = GameObject.Find("Level Text").GetComponent<TextMeshProUGUI>();
        GameObject[] incrementUIObjects = GameObject.FindGameObjectsWithTag("AmmoIncrement");

        for (int i = 0; i < incrementUIObjects.Length; i++)
        {
            incrementUI[i] = incrementUIObjects[i].GetComponent<TextMeshProUGUI>();
        }

        expFill = GameObject.Find("EXP Slider").GetComponent<Slider>();
        healthFill = GameObject.Find("Health Slider").GetComponent<Slider>();
        shieldFill = GameObject.Find("Shield Slider").GetComponent<Slider>();
    }

    

    // Use this for initialization
    private void Start() //This method is called when the script is first initialised.
    {

        previousCurrentEXP = PlayerData.instance.currentEXP; //Sets the integer within 'previousCurrentEXP' equal to the varibale within the 'currentEXP' integer variable within the 'playerData' PlayerData.instance.

        int [] previousIncrement = {PlayerData.instance.currentReserveAmmo[0], PlayerData.instance.currentReserveAmmo[1], PlayerData.instance.currentReserveAmmo[2], PlayerData.instance.currentReserveAmmo[3], PlayerData.instance.currentReserveAmmo[4], PlayerData.instance.currentReserveAmmo[5]};
        /*
        previousIncrement[1] = playerData.aT1CRA; //Sets the integer within 'previousT1CRA' equal to the varibale within the 'aT1CRA' integer variable within the 'playerData' PlayerData.

        previousIncrement[2] = playerData.aT2CRA; //Sets the integer within 'previousT1CRA' equal to the varibale within the 'aT1CRA' integer variable within the 'playerData' PlayerData.

        previousIncrement[3] = playerData.aT3CRA; //Sets the integer within 'previousT1CRA' equal to the varibale within the 'aT1CRA' integer variable within the 'playerData' PlayerData.

        previousIncrement[4] = playerData.aT4CRA; //Sets the integer within 'previousT1CRA' equal to the varibale within the 'aT1CRA' integer variable within the 'playerData' PlayerData.

        previousIncrement[5] = playerData.aT5CRA; //Sets the integer within 'previousT1CRA' equal to the varibale within the 'aT1CRA' integer variable within the 'playerData' PlayerData.

        previousIncrement[6] = playerData.aT6CRA; //Sets the integer within 'previousT1CRA' equal to the varibale within the 'aT1CRA' integer variable within the 'playerData' PlayerData.
*/

      //  aT1IUI.text = ""; //Sets the text of the 'aT1CRAUI' label to null.

    }

    // Update is called once per frame
    void OnGUI()
    {


        ChangeEXP(); //Calls the 'ChangeEXP' method.
        ChangeHealth(); //Calls the 'ChangeHealth' method.
        EXPIncrement(); //Calls the 'EXPIncrement' method.
        ShowLevel(); //Calls the 'ShowLevel' method.
        ammoIncrement(); //Calls the 'ammoIncrement' method.
        ChangeShield(); //Calls the 'ChangeShield' method.

    }

    void ShowLevel() //This method is called 'ShowLevel'. This method finds the valued stored within the 'currentLevel' integer from the 'PlayerData' script from 'Player' and sets it in the 'levelUI' label. (It finds the current level of the player from another script and displays it on the screen so the user can see their level
    {
        levelUI.text = PlayerData.instance.currentLevel.ToString(); //Fetches the 'currentLevel' integer from the 'playerData' PlayerData script, converts it into a string and then displays is in the text value of 'levelUI'. (Fetches the player's current level from another script and displays it as text on the screen so the player knows what level they currently are)
    }

    void ChangeEXP() //This method is called 'ChangeEXP'. This method finds the valued stored within the 'currentEXP' and 'maxEXP' integers from the 'PlayerData' script from 'Player', calculates a percentage by dividing 'currentEXP' by 'maxEXP' and sets it in the 'expPercentage' float. It then applies the 'expPercentage' value to the value of the 'expFill' slider. (It finds the current exp and max exp of the player from another script, divides current exp by max exp to find a percentage of how far the player has progressed through their level.
    {

        expPercentage = ((float)PlayerData.instance.expEarnedThisLevel / (PlayerData.instance.EXPForNextLevel)); //Converts the integer of 'currentEXP' from 'playerData' to a float and divides it by the integer of 'maxEXP' from 'playerData'. The answer is then stored within 'expPercentage'.

        expFill.value = expPercentage; //Stores the stored number within 'expPercentage' into the number value of the 'expFill' slider.

    }

    void ChangeHealth() //This method is called 'ChangeHealth'. This method finds the valued stored within the 'currentHealth' and 'currentMaxHealth' integers from the 'PlayerData' script from 'Player', calculates a percentage by dividing 'currentHealth' by 'currentMaxHealth' and stores it in the 'healthPercentage' float. It then applies the 'healthPercentage' value to the value of the 'healthFill' slider. (It finds the current health and max health of the player from another script, divides current health by max health to find a percentage of how close the player's health is to max capacity. 
    {
        
        healthPercentage = ((float)PlayerData.instance.currentHealth / PlayerData.instance.currentMaxHealth); //Converts the integer of 'currentHealth' from 'playerData' to a float and divides it by the integer of 'currentMaxHealth' from 'playerData'. The answer is then stored within 'healthPercentage'.

        healthFill.value = healthPercentage; //Stores the stored number within 'healthPercentage' into the number value of the 'healthFill' slider.

        currentHealthUI.text = PlayerData.instance.currentHealth.ToString(); //Converts the integer 'currentHealth' into a string so it can be used as text. It then stores this string in the text value of the 'currentHealthUI' label. (This is so the player can see their exact value of health as a number and not just as a percenatge).

    }

    void ChangeShield() //This method is called 'ChangeHealth'. This method finds the valued stored within the 'currentCapacity' and 'capacity' integers from the 'ShieldData' script from 'Sheild', calculates a percentage by dividing 'currentCapacity' by 'capacity' and stores it in the 'shieldPercentage' float. It then applies the 'shieldPercentage' value to the value of the 'shieldFill' slider. (It finds the current health and max health of the player from another script, divides current shield capacity by shield capacity to find a percentage of how close the player's shield is to max capacity.
    {
        GameObject shield = GameObject.Find("Shield"); //Finds the game object called "Shield" so it can acces its scripts.

        Shield shieldData = shield.GetComponent<Shield>(); //Finds the script called "shieldData" so it can access its variables.

        shieldPercentage = ((float)shieldData.currentCapacity / shieldData.capacity); //Converts the integer of 'currentCapacity' from 'shieldData' to a float and divides it by the integer of 'capacity' from 'shieldData'. The answer is then stored within 'shieldPercentage'.

        shieldFill.value = shieldPercentage; //Stores the stored number within 'shieldPercentage' into the number value of the 'shieldFill' slider.

        currentShieldUI.text = shieldData.currentCapacity.ToString(); //Converts the integer 'currentCapacity' into a string so it can be used as text. It then stores this string in the text value of the 'currentCapacityUI' label. (This is so the player can see their exact value of their shield capacity as a number and not just as a percenatge).

    }

    void EXPIncrement()
    {

        if (PlayerData.instance.currentEXP != previousCurrentEXP)
        {

            EXPCombo();

        }

    }

    IEnumerator DisplayIncrementChange(char incrementType, int oldIV)
    {
        int sec = 3;

        if (incrementUI.Length == 0)
        {
            Debug.LogError("Increment Array not setup");
        }
        else
        {

        switch (incrementType)
        {
            
                case '1':
                    if(incrementUI[0] == null)
                        Debug.LogError("Increment UI 1 is not linked");
                    else
                    {
                            incrementValue[0] = (PlayerData.instance.currentReserveAmmo[0] - previousIncrement[0]) + oldIV;
                            incrementUI[0].text = "+ " + incrementValue[0].ToString();
                            previousIncrement[0] = PlayerData.instance.currentReserveAmmo[0];
                            yield return new WaitForSeconds(sec);
                            incrementValue[0] = 0;
                            incrementUI[0].text = "";
                    }
                    break;

                case '2':
                    if(incrementUI[1] == null)
                        Debug.LogError("Increment UI 2 is not linked");
                    else
                    {
                            incrementValue[1] = (PlayerData.instance.currentReserveAmmo[1] - previousIncrement[1]) + oldIV;
                            incrementUI[1].text = "+ " + incrementValue[1].ToString();
                            previousIncrement[1] = PlayerData.instance.currentReserveAmmo[1];
                            yield return new WaitForSeconds(sec);
                            incrementValue[1] = 0;
                            incrementUI[1].text = "";
                    }
                    break;

                case '3':
                if(incrementUI[2] == null)
                        Debug.LogError("Increment UI 3 is not linked");
                    else
                    {
                            incrementValue[2] = (PlayerData.instance.currentReserveAmmo[2] - previousIncrement[2]) + oldIV;
                            incrementUI[2].text = "+ " + incrementValue[2].ToString();
                            previousIncrement[2] = PlayerData.instance.currentReserveAmmo[2];
                            yield return new WaitForSeconds(sec);
                            incrementValue[2] = 0;
                            incrementUI[2].text = "";
                    }
                    break;

                case '4':
                    if(incrementUI[3] == null)
                        Debug.LogError("Increment UI 4 is not linked");
                    else
                    {
                            incrementValue[3] = (PlayerData.instance.currentReserveAmmo[3] - previousIncrement[3]) + oldIV;
                            incrementUI[3].text = "+ " + incrementValue[3].ToString();
                            previousIncrement[3] = PlayerData.instance.currentReserveAmmo[3];
                            yield return new WaitForSeconds(sec);
                            incrementValue[3] = 0;
                            incrementUI[3].text = "";
                    }
                    break;

                case '5':
                    if(incrementUI[4] == null)
                        Debug.LogError("Increment UI 5 is not linked");
                    else
                    {
                            incrementValue[4] = (PlayerData.instance.currentReserveAmmo[4] - previousIncrement[4]) + oldIV;
                            incrementUI[4].text = "+ " + incrementValue[4].ToString();
                            previousIncrement[4] = PlayerData.instance.currentReserveAmmo[4];
                            yield return new WaitForSeconds(sec);
                            incrementValue[4] = 0;
                            incrementUI[4].text = "";
                    }
                    break;

                case '6':
                    if(incrementUI[5] == null)
                        Debug.LogError("Increment UI 6 is not linked");
                    else
                    {
                            incrementValue[5] = (PlayerData.instance.currentReserveAmmo[5] - previousIncrement[5]) + oldIV;
                            incrementUI[5].text = "+ " + incrementValue[5].ToString();
                            previousIncrement[5] = PlayerData.instance.currentReserveAmmo[5];
                            yield return new WaitForSeconds(sec);
                            incrementValue[5] = 0;
                            incrementUI[5].text = "";
                    }
                    break;

                case '7':
                    if (incrementUI[6] == null)
                        Debug.LogError("Increment UI 7 is not linked");
                    else
                    {
                        incrementValue[6] = PlayerData.instance.currentMainCurrency;
                        incrementUI[6].text = "$" + incrementValue[6].ToString();
                        previousIncrement[6] = PlayerData.instance.currentMainCurrency;
                        yield return new WaitForSeconds(sec);
                        incrementValue[6] = 0;
                        incrementUI[6].text = "";
                    }
                    break;

                case '8':
                    if (incrementUI[7] == null)
                        Debug.LogError("Increment UI 8 is not linked");
                    else
                    {
                        incrementValue[7] = PlayerData.instance.currentRareCurrency;
                        incrementUI[7].text = "$$$" + incrementValue[7].ToString();
                        previousIncrement[7] = PlayerData.instance.currentRareCurrency;
                        yield return new WaitForSeconds(sec);
                        incrementValue[7] = 0;
                        incrementUI[7].text = "";
                    }
                    break;

            }
    }

    }



        IEnumerator UIWaitt()
        {

           yield return new WaitForSeconds(3);

        }

    void EXPCombo()
    {
        expGaining += (PlayerData.instance.currentEXP - previousCurrentEXP);

        oldEXPGaining = expGaining;

        expIncrementUI.enabled = true;


        expIncrementUI.text = "+" + (expGaining).ToString();


        StartCoroutine(UIWaitt());


        if (oldEXPGaining == expGaining)
        {

            expGaining = 0;

            expIncrementUI.enabled = false;

            previousCurrentEXP = PlayerData.instance.currentEXP;

        }
        else
        {

            EXPCombo();

        }




    }


    void ammoIncrement()
    {
        if (previousIncrement[0] < PlayerData.instance.currentReserveAmmo[0])
        {

            StopCoroutine(DisplayIncrementChange('1', incrementValue[0]));   
            StartCoroutine(DisplayIncrementChange('1', incrementValue[0]));

        }

        if (previousIncrement[1] < PlayerData.instance.currentReserveAmmo[1])
        {
            StopCoroutine(DisplayIncrementChange('2', incrementValue[1]));
            StartCoroutine(DisplayIncrementChange('2', incrementValue[1]));

        }

        if (previousIncrement[2] < PlayerData.instance.currentReserveAmmo[2])
        {
            StopCoroutine(DisplayIncrementChange('3', incrementValue[2]));
            StartCoroutine(DisplayIncrementChange('3', incrementValue[2]));

        }

        if (previousIncrement[3] < PlayerData.instance.currentReserveAmmo[3])
        {
            StopCoroutine(DisplayIncrementChange('4', incrementValue[3]));
            StartCoroutine(DisplayIncrementChange('4', incrementValue[3]));

        }

        if (previousIncrement[4] < PlayerData.instance.currentReserveAmmo[4])
        {
            StopCoroutine(DisplayIncrementChange('5', incrementValue[4]));
            StartCoroutine(DisplayIncrementChange('5', incrementValue[4]));

        }

        if (previousIncrement[5] < PlayerData.instance.currentReserveAmmo[5])
        {
            StopCoroutine(DisplayIncrementChange('6', incrementValue[5]));
            StartCoroutine(DisplayIncrementChange('6', incrementValue[5]));

        }

        if (previousIncrement[6] < PlayerData.instance.currentMainCurrency)
        {
            StopCoroutine(DisplayIncrementChange('7', 0));
            StartCoroutine(DisplayIncrementChange('7', 0));

        }

        if (previousIncrement[7] < PlayerData.instance.currentRareCurrency)
        {
            StopCoroutine(DisplayIncrementChange('8', 0));
            StartCoroutine(DisplayIncrementChange('8', 0));

        }

        if (previousIncrement[0] > PlayerData.instance.currentReserveAmmo[0])
        {

            previousIncrement[0] = PlayerData.instance.currentReserveAmmo[0];

        }

        if (previousIncrement[1] > PlayerData.instance.currentReserveAmmo[1])
        {

            previousIncrement[1] = PlayerData.instance.currentReserveAmmo[1];

        }

        if (previousIncrement[2] > PlayerData.instance.currentReserveAmmo[2])
        {

            previousIncrement[2] = PlayerData.instance.currentReserveAmmo[2];

        }

        if (previousIncrement[3] > PlayerData.instance.currentReserveAmmo[3])
        {

            previousIncrement[3] = PlayerData.instance.currentReserveAmmo[3];

        }

        if (previousIncrement[4] > PlayerData.instance.currentReserveAmmo[4])
        {

            previousIncrement[4] = PlayerData.instance.currentReserveAmmo[4];

        }

        if (previousIncrement[5] > PlayerData.instance.currentReserveAmmo[5])
        {

            previousIncrement[5] = PlayerData.instance.currentReserveAmmo[5];

        }

    }


}

