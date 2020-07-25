//Project Landnite
//
//Created by Liam Hall on 1/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    bool displayInfo; //Creates a boolean called displayInfo.

    [HideInInspector]
    public Equipment equippedEquipment; //Creates a public reference of an Equipment class and calls its equippedEquipment

    [Tooltip("What type of equipment would this slot be used for? S = Shield, G = Gun")]
    public char equipmentType; //s = Shield, g - Gun


    [Header("Links")]

    [Tooltip("Link to the Hover Image game object.")]
    GameObject hoverImage;


    [Header("Description Variable Labels")]
    [Tooltip("Link to the 10 'Description Variable Labels'. 0 = Name, 1 = Level, 2 = Rarity, 3 = Damage/Capacity, 4 = Accuracy/Recharge Rate, 5 = Reload Speed/Recharge Delay, 6 = Magazine Size, 7 = Fire Rate, 8 = Description, 9 = Value.")]
    TMPro.TMP_Text[] descriptionLabels = new TMPro.TMP_Text[10]; //0 = Name, 1 = Level, 2 = Rarity, 3 = Damage/Capacity, 4 = Accuracy/Recharge Rate, 5 = Reload Speed/Recharge Delay, 6 = Magazine Size, 7 = Fire Rate, 8 = Description, 9 = Value


    [Header("Description Text Labels")]
    [Tooltip("Link to the 6 'Description Labels' that contain only text. 0 = Level, 1 = Damage/Capacity, 2 = Accuracy/Recharge Rate, 3 = Reload Speed/Recharge Delay, 4 = Magazine Size, 5 = Fire Rate.")]
    TMPro.TMP_Text[] descriptionLabelsNoEdit = new TMPro.TMP_Text[6]; //0 = Level, 1 = Damage/Capacity, 2 = Accuracy/Recharge Rate, 3 = Reload Speed/Recharge Delay, 4 = Magazine Size, 5 = Fire Rate


    [Tooltip("Link to the 'Description Rarity Image' game object.")]
    Image descriptionRarityBackground;


    [Tooltip("Link to the 'Description Background' game object.")]
    Image descriptionBackground;


    [Header("Description Rarity Colours")]

    [Tooltip("Link to the 7 'Description Rarity Colours'. 0 = Empty, 1 = Common, 2 = Uncommon, 3 = Rare, 4 = Heroic, 5 = Legendary, 6 = Mythic.")]
    Sprite[] descriptionRarityColours = new Sprite[7];


    public void Start() //This method is called when the class is initialised.
    {

        LinkingLabels(); //Calls the LinkingLabels method.

        LinkingImages(); //Calls the LinkingImages method.

    }


    void LinkingLabels() //This method assigns GUI text labels to the text label arrays of descriptionLabels and descriptionLabelsNoEdit.
    {
        //This array has all of the text that changes depending on their equipment.
        descriptionLabels[0] = GameObject.Find("DEquipment Name Text").GetComponent<TextMeshProUGUI>();
        descriptionLabels[1] = GameObject.Find("DEquipment Level Number Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[2] = GameObject.Find("DEquipment Rarity Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[3] = GameObject.Find("DEquipment Damage Number Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[4] = GameObject.Find("DEquipment Accuracy Number Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[5] = GameObject.Find("DEquipment Reload Speed Number Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[6] = GameObject.Find("DEquipment Mag Size Number Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[7] = GameObject.Find("DEquipment Fire Rate Number Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[8] = GameObject.Find("DEquipment Description Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabels[9] = GameObject.Find("DEquipment Value Text").GetComponent<TextMeshProUGUI>(); 

        //This array has all of the text that only really changes on the equipment type (shield or gun).
        descriptionLabelsNoEdit[0] = GameObject.Find("DEquipment Level Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabelsNoEdit[1] = GameObject.Find("DEquipment Damage Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabelsNoEdit[2] = GameObject.Find("DEquipment Accuracy Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabelsNoEdit[3] = GameObject.Find("DEquipment Reload Speed Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabelsNoEdit[4] = GameObject.Find("DEquipment Mag Size Text").GetComponent<TextMeshProUGUI>(); 
        descriptionLabelsNoEdit[5] = GameObject.Find("DEquipment Fire Rate Text").GetComponent<TextMeshProUGUI>(); 
     
    }


    void LinkingImages() //This method finds the wanted images from the asset folder, and assigns them to certain sprites. It also finds certain game objects on the scene that can display these sprites.
    {

        //Finds the Image components of the game objects and saves them in an image variable.
        descriptionRarityBackground = GameObject.Find("DEquipment Rarity Background").GetComponent<Image>();

        descriptionBackground = GameObject.Find("DEquipment Main Background").GetComponent<Image>();


        //Finds the game object in the current transform's children.
        hoverImage = this.transform.Find("Equipped Button Hover").gameObject;


        //Loads sprites from the assets folder and assigns them to the array called descriptionRarityColours.
        descriptionRarityColours[1] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/CommonDescriptionBackground");
        descriptionRarityColours[2] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/UncommonDescriptionBackground");
        descriptionRarityColours[3] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/RareDescriptionBackground");
        descriptionRarityColours[4] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/HeroicDescriptionBackground");
        descriptionRarityColours[5] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/LegendaryDescriptionBackground");
        descriptionRarityColours[6] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/MythicDescriptionBackground");


    }


    bool isMouse = true; ///Put in settings config later AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

    public void OnPointerEnter(PointerEventData ped) //If the mouse enters the proximity of this game object, then...
    {

        if (isMouse) //If the isMouse boolean is true (the user has chosen to use mouse support over keyboard support), then...
        {

            print("Pointer Enter");

            WhenSelected(); //Calls the WhenSelected method.

        }

    }

    public void OnSelect() //This method is called when the user hovers over the game object using arrow keys.
    {

        if (!isMouse) //If the isMouse boolean is false (the user has chosen not to use mouse support over keyboard support), then...
        {

            WhenSelected(); //Calls the WhenSelected method.

        }

        else
        {

            return;

        }

    }

    public void WhenSelected() //This method starts to display certain information on screen, including equipment stats and shows the user that this current game object is being selected.
    {

        print("Selected");
        displayInfo = true; //Sets the displayInfo boolean to true.

        hoverImage.SetActive(true); //Activates the hoverImage image component so the user knows they are hovering over this game object.

        FindInfoToDisplay(); //Calls the FindInfoToDisplay method.

    }

    public void OnPointerExit(PointerEventData ped) //If the mouse pointer has left the proximity of the game object, then...
    {

        if (isMouse) //If the isMouse boolean is true (the user has chosen to use mouse support over keyboard support), then...
        {

            print("Pointer Exit");

            WhenNotSelected(); //Calls the WhenNotSelected method.

        }

    }

    public void OnDeselect() //This method is called when the user deselects the game object using arrow keys.
    {

        if (!isMouse) //If the isMouse boolean is false (the user has chosen not to use mouse support over keyboard support), then...
        {

            WhenNotSelected(); //Calls the WhenNotSelected method.

        }

    }

    public void WhenNotSelected() //This method hides all the information that was shown when the game object was selected (hides weapon statistics, disables the hover image, etc).
    {

        print("Deselected");

        displayInfo = false;

        hoverImage.SetActive(false);

        FindInfoToDisplay();

    }

    void DisplayShieldInfo() //This method gets all of the information about the shield stored in this inventory slot and displays it to the user in images and text.
    {

   

        ShieldData equipment = (ShieldData)equippedEquipment; //Creates a reference to a ShieldData script called equipment and assigns the equippedEquipment script to it (after parsing the equippedEquipment as a shield, so it can display shield specific data).

        string rarityName = GettingRarityName(equippedEquipment.rarity); //Calls the GettingRarityName method whiles passing on the rarity of the equipment on to it, the value returned from the method is then saved as a string called rarityName, so it can put into a text label later.

        int rarity = GettingRarityColour(equippedEquipment.rarity); //Calls the GettingRarityName method whiles passing on the rarity of the equipment on to it, the value returned from the method is then saved as an integer called rarityColour, so it can be displayed as an image later..

        int capacity = equipment.baseCapacity; //Sets the capacity value to the value stored within baseCapacity.
        int rechargeRate = equipment.baseRechargeRate; //Sets the rechargeRate to the value stored within baseRechargeRate.

        int sellValue = Mathf.RoundToInt((float)(equipment.baseSellValue * Mathf.Pow(1.1301f, equipment.level))); //Gets the integer stored within 'baseSellValue', multiplies it by 1.1301 to the power of the integer stored within 'level', then gets the value stored in 'level', multiplies it by 3 and takes it away from the previous answer. It then makes sellValue equal to the previous answer. 
        int buyValue = equipment.baseSellValue * 2; //Multiplies the integer stored within 'sellValue' by 2 and stores it within 'buyValue'.

        //Gets the integer and string based information of the equipment and then assigns it to the descriptionLabels text labels. This is so the user can read the information of the equipment on screen.
        descriptionLabels[0].text = equipment.name;
        descriptionLabels[1].text = equipment.level.ToString();
        descriptionLabels[2].text = rarityName;
        descriptionLabels[3].text = capacity.ToString();
        descriptionLabels[4].text = rechargeRate.ToString();
        descriptionLabels[5].text = equipment.rechargeDelay.ToString();
        descriptionLabels[8].text = equipment.description;
        descriptionLabels[9].text = "$ " + sellValue.ToString();

        //Sets the sprite of the image component in descriptionRarityBackground to the rarity image of the weapon that was calculated earlier.
        descriptionRarityBackground.sprite = descriptionRarityColours[rarity];

        //Enables the image components of the equipment description panel.
        descriptionRarityBackground.enabled = true;
        descriptionBackground.enabled = true;


        //Sets the text of the descriptionLabelsNoEdit to the name of the variables the equipment will be using so the player knows what each value is for.
        descriptionLabelsNoEdit[0].text = "Requires Level";
        descriptionLabelsNoEdit[1].text = "Capacity";
        descriptionLabelsNoEdit[2].text = "Recharge Rate";
        descriptionLabelsNoEdit[3].text = "Recharge Delay";


        //Enables the descriptionLabelsNoEdit needed by the equipment.
        descriptionLabelsNoEdit[0].enabled = true;
        descriptionLabelsNoEdit[1].enabled = true;
        descriptionLabelsNoEdit[2].enabled = true;
        descriptionLabelsNoEdit[3].enabled = true;


        //Prints certain equipment information in the console.
        print(equippedEquipment.name);
        print(equippedEquipment.level);
        print(capacity);
        print(rechargeRate);
        print(equipment.rechargeDelay);
        print(sellValue);

    }


    void DisplayGunInfo()
    {

 

        GunData equipment = (GunData)equippedEquipment;

        string rarityName = GettingRarityName(equipment.rarity); //Calls the GettingRarityName method whiles passing on the rarity of the equipment on to it, the value returned from the method is then saved as a string called rarityName, so it can put into a text label later.

        int rarity = GettingRarityColour(equipment.rarity); //Calls the GettingRarityName method whiles passing on the rarity of the equipment on to it, the value returned from the method is then saved as an integer called rarityColour, so it can be displayed as an image later..

        int damage = Mathf.RoundToInt((float)(equipment.baseDamage * Mathf.Pow(1.1301f, equipment.level))); //Calculates the damage of the weapon so it increases damage when the weapon level is increased.

        int sellValue = Mathf.RoundToInt((float)(equipment.baseSellValue * Mathf.Pow(1.1301f, equipment.level))); //Gets the integer stored within 'baseSellValue', multiplies it by 1.1301 to the power of the integer stored within 'level', then gets the value stored in 'level', multiplies it by 3 and takes it away from the previous answer. It then makes sellValue equal to the previous answer. 

        // Gets the integer and string based information of the equipment and then assigns it to the descriptionLabels text labels.This is so the user can read the information of the equipment on screen.
        descriptionLabels[0].text = equipment.name;
        descriptionLabels[1].text = equipment.level.ToString();
        descriptionLabels[2].text = rarityName;
        descriptionLabels[3].text = damage.ToString();
        //descriptionLabels[4].text = gunD.accuracy.ToString();
        descriptionLabels[5].text = equipment.reloadTime.ToString();
        descriptionLabels[6].text = equipment.maxMagAmmo.ToString();
        descriptionLabels[7].text = equipment.rateOfFire.ToString();
        descriptionLabels[8].text = equipment.description;
        descriptionLabels[9].text = "$ " + sellValue.ToString();

        //Sets the sprite of the image component in descriptionRarityBackground to the rarity image of the weapon that was calculated earlier.
        descriptionRarityBackground.sprite = descriptionRarityColours[rarity];

        //Enables the image components of the equipment description panel.
        descriptionRarityBackground.enabled = true;
        descriptionBackground.enabled = true;


        //Sets the text of the descriptionLabelsNoEdit to the name of the variables the equipment will be using so the player knows what each value is for.
        descriptionLabelsNoEdit[0].text = "Requires Level";
        descriptionLabelsNoEdit[1].text = "Damage";
        descriptionLabelsNoEdit[2].text = "Accuracy";
        descriptionLabelsNoEdit[3].text = "Reload Speed";
        descriptionLabelsNoEdit[4].text = "Magazine Size";
        descriptionLabelsNoEdit[5].text = "Fire Rate";

        //Enables the descriptionLabelsNoEdit needed by the equipment.
        descriptionLabelsNoEdit[0].enabled = true;
        descriptionLabelsNoEdit[1].enabled = true;
        descriptionLabelsNoEdit[2].enabled = true;
        descriptionLabelsNoEdit[3].enabled = true;
        descriptionLabelsNoEdit[4].enabled = true;
        descriptionLabelsNoEdit[5].enabled = true;
        descriptionLabelsNoEdit[6].enabled = true;


        //Prints certain equipment information in the console.
        print(equipment.name);
        print(equipment.level);
        print(damage);
        //print(equipment.accuracy);
        print(equipment.reloadTime);
        print(equipment.maxMagAmmo);
        print(equipment.rateOfFire);
        print(sellValue);


    }


    void RemoveInfo() //This method sets all of the text description text labels to nothing and disables all of the image components and text labels used by the equipment description panel.
    {

        //Disables the hover image.
        hoverImage.SetActive(false);

        //Sets all of the descriptionLabels to null.
        descriptionLabels[0].text = "";
        descriptionLabels[1].text = "";
        descriptionLabels[2].text = "";
        descriptionLabels[3].text = "";
        descriptionLabels[4].text = "";
        descriptionLabels[5].text = "";
        descriptionLabels[6].text = "";
        descriptionLabels[7].text = "";
        descriptionLabels[8].text = "";
        descriptionLabels[9].text = "";

        //Disables the images that are used for the description panel.
        descriptionRarityBackground.enabled = false;
        descriptionBackground.enabled = false;

        //Sets all of the descriptionLabelsNoEdit to null.
        descriptionLabelsNoEdit[0].enabled = false;
        descriptionLabelsNoEdit[1].enabled = false;
        descriptionLabelsNoEdit[2].enabled = false;
        descriptionLabelsNoEdit[3].enabled = false;
        descriptionLabelsNoEdit[4].enabled = false;
        descriptionLabelsNoEdit[5].enabled = false;
        descriptionLabelsNoEdit[6].enabled = false;

    }


    public void FindInfoToDisplay() //This method finds the type of equipment slot this is, depending on the answer, it will call a method that will display the information of the equipment.
    {

        if (displayInfo) //If the displayInfo boolean is true, then...
        {

            if (equipmentType == 's') //If the equipment is a shield, then...
            {

                DisplayShieldInfo(); //Call the DisplayShieldInfo method.

            }

            if (equipmentType == 'g') //If the equipment is a weapon, then...
            {

                DisplayGunInfo(); //Call the DisplayGunInfo method.

            }


        }

        else //If the displayInfo boolean is false, then...
        {

            RemoveInfo(); //Call the RemoveInfo method (remove the info from the description panel).

        }

    }


    string GettingRarityName(char rarityChar) //This method finds the rarity of the equipment through its character, and then returns it as a string.
    {

        string rarityName; //Creates a string called rarityName.

        //Establishes a switch statement that will return the rarity name of the equipment depending on its character.
        switch (rarityChar) //c = common, u = uncommon, r = rare, [e = epic], h = heroic, l = legendary, m = mythic
        {

            case 'c': //If the char is a c, then...
                rarityName = "Common"; //Set the rarityName string to Common.
                print("common");
                break; //Stop the case.

            case 'u':
                rarityName = "Uncommon";
                print("uncommon");
                break;

            case 'r':
                rarityName = "Rare";
                print("rare");
                break;

            case 'h':
                rarityName = "Heroic";
                print("heroic");
                break;

            case 'l':
                rarityName = "Legendary";
                print("legendary");
                break;

            case 'm':
                rarityName = "Mythic";
                print("mythic");
                break;

            default:
                rarityName = "";
                print("no-equipped");
                break;

        }

 

        return rarityName; //Returns the rarityName as a string to the string that called this method.

    }


    int GettingRarityColour(char rarityChar) //This method returns an integer, the integer is set depending on the character of the rarity of the equipment.
    {

  


        int rarityInt; //Creates an integer called rarityInt.

        //Establishes a switch statement that will return the rarity integer of the equipment depending on its character.
        switch (rarityChar) //c = common, u = uncommon, r = rare, [e = epic], h = heroic, l = legendary, m = mythic
        {

            case 'c': //If the char is a c, then...
                rarityInt = 1; //Set the rarityInt integer to 1.
                print("common");
                break;

            case 'u':
                rarityInt = 2;
                print("uncommon");
                break;

            case 'r':
                rarityInt = 3;
                print("rare");
                break;

            case 'h':
                rarityInt = 4;
                print("heroic");
                break;

            case 'l':
                rarityInt = 5;
                print("legendary");
                break;

            case 'm':
                rarityInt = 6;
                print("mythic");
                break;

            default:
                rarityInt = 0;
                print("no-equipped");
                break;

        }



        return rarityInt; //Returns the rarityInt as an integer to the integer that called this method.

    }

}
