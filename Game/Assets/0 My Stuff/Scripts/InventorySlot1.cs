using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventorySlot1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    public Equipment equipment;  // Current item in the slot

    public TMPro.TMP_Text backpackText;

    // Add item to the slot
    public void AddEquipment(Equipment newEquipment)
    {

        if (newEquipment != null) //If a new equipment item has added (if newEquipment is not null), then...
        {

            equipment = newEquipment; //Set the equipment attribute of this class equal to the one that was just added.

            backpackText.text = equipment.name; //Set the text field in the backpack slot equal to the name of the equipment (Set the text of backpackText to the string stored in the name attribute of the equipment scriptable object).

            if (!displayInfo) //If the displayInfo bool is false (the user is not currently hovering over the equipment item in the backpack UI), then...
            {

                SettingTextColour(); //Call the SettingTextColour method.

            }
        }

        else //Else,
        {

             backpackText.text = ""; //Clear the text stored in the backpackText label.
             backpackHoverImage.enabled = false; //Hides the backpackHoverImage.

        }

       

    }

    // Clear the slot
    public void ClearSlot()
    {

        equipment = null; //Set equipment to null.

    }

    public void Update() //This method is called once every frame.
    {

        RemoveSlot(); //Calls the RemoveSlot method.

        DeleteEquipment(); //Calls the DeleteEquipment method.

        RetrieveTrashEquipment(); //Calls the RetrieveTrashEquipment method.

    }

    void RemoveSlot() //This method finds out if there is an equipment item stored in this backpack slot, and if there is not, then it will destory the game object this script is a component of.
    {

        if (equipment == null) //If the equipment attribute is null (no equipment assigned to this slot), then...
        {

            Destroy(gameObject); //Destroy this game object.

        }

    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {

        Inventory.instance.RemoveEquipment(equipment); //Accesses the Inventory instance, and calls the RemoveEquipment method whiles parsing the equipment attribute of this script with it.

    }

    // Use the item
    public void UseItem()
    {

        if (equipment != null && equipment.level <= PlayerData.instance.currentLevel) //If equipment is not null (there is an equipment item in this slot), then...
        {

            equipment.Use(); //Calls the use method in the equipment script.

        }
        else
        {
            backpackText.text = "Your level is too low";
            StartCoroutine(Warning());
            backpackText.text = equipment.name;
        }

    }

    IEnumerator Warning()
    {
        yield return new WaitForSeconds(2f);
    }

    bool displayInfo;

    char rarityChar;

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

    Image backpackHoverImage;

    [Header("Description Rarity Colours")]

    [Tooltip("Link to the 7 'Description Rarity Colours'. 0 = Empty, 1 = Common, 2 = Uncommon, 3 = Rare, 4 = Heroic, 5 = Legendary, 6 = Mythic.")]
    Sprite[] descriptionRarityColours = new Sprite[7];

    [Tooltip("Link to the 7 'Hover Rarity Colours'. 0 = Empty, 1 = Common, 2 = Uncommon, 3 = Rare, 4 = Heroic, 5 = Legendary, 6 = Mythic.")]
    Sprite[] hoverRarityImage = new Sprite[7];

    public void Start() //This method is called when this script is first activated.
    {

        LinkingLabels(); //Calls the LinkingLabels method.

        LinkingImages(); //Calls the LinkingImages method.

       
    }

    void SettingTextColour() //This method finds the rarity of the weapon, and depending on the rarity, sets the colour of the text displayed in the UI.
    {

        Equipment equ = equipment;

        rarityChar = equ.rarity;

        backpackHoverImage.enabled = false;

        switch (rarityChar) //c = common, u = uncommon, r = rare, [e = epic], h = heroic, l = legendary, m = mythic
        {

            case 'c':
                backpackText.color = new Color32(134, 134, 134, 255);
                break;

            case 'u':
                backpackText.color = new Color32(100, 186, 84, 255);
                break;

            case 'r':
                backpackText.color = new Color32(90, 162, 237, 255);
                break;

            case 'h':
                backpackText.color = new Color32(154, 62, 234, 255);
                break;

            case 'l':
                backpackText.color = new Color32(230, 171, 77, 255);
                break;

            case 'm':
                backpackText.color = new Color32(218, 80, 74, 255);
                break;

            default:
                backpackText.color = new Color32(255, 255, 255, 255);
                break;

        }

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
        backpackHoverImage = GetComponentInChildren<Image>();


        //Loads sprites from the assets folder and assigns them to the array called descriptionRarityColours.
        descriptionRarityColours[1] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/CommonDescriptionBackground");
        descriptionRarityColours[2] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/UncommonDescriptionBackground");
        descriptionRarityColours[3] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/RareDescriptionBackground");
        descriptionRarityColours[4] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/HeroicDescriptionBackground");
        descriptionRarityColours[5] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/LegendaryDescriptionBackground");
        descriptionRarityColours[6] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/MythicDescriptionBackground");

        //Loads sprites from the assets folder and assigns them to the array called hoverRarityImage. These images will be enabled when the player is hovering over the inventory slot.
        hoverRarityImage[1] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/CommonBackpackHover");
        hoverRarityImage[2] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/UncommonBackpackHover");
        hoverRarityImage[3] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/RareBackpackHover");
        hoverRarityImage[4] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/HeroicBackpackHover");
        hoverRarityImage[5] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/LegendaryBackpackHover");
        hoverRarityImage[6] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/MythicBackpackHover");


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

        if (backpackText.text == "")
        {

            return;

        }

        else
        {

            print("Selected");
            displayInfo = true;

            backpackHoverImage.enabled = true;

            FindInfoToDisplay();

            //DeleteItem();

        }

    }

    Equipment inTrashEquipment; //Creates an Equipment reference called inTrashEquipment.

    bool trashFilled; //Creats a boolean called trashFilled. This will be used to determine if something has been added to the trash.

    public void DeleteEquipment() //This method deletes the equipment in the inventory from the inventory, whiles also adding the last deleted equipped item to the inTrashEquipment so it can be retreived later.
    {
        if (displayInfo) //If display info is true, then... (currently hovering over the item).
        {

            if (Input.GetButtonDown("Discard Item")) //If the buttons under Discard Item in the input manager is pressed, then...
            {

                trashFilled = true; //Set the trashFilled boolean to true (notifies the program that something is in the trash).

                inTrashEquipment = equipment; //Sets the current equipment into the inTrashEquipment equipment (sends the equipment to the trash).

                equipment.RemoveEquipmentFromInventory(); //Remove the equipment from the inventory. (Calls the RemoveEquipmentFromInventory method from the equipment class).

                print("Discarded: " + inTrashEquipment.name + " - Level " + inTrashEquipment.level);

            }
        }

    }


    void RetrieveTrashEquipment() //This method allows the user to retrieve the last equipment they added to the trash.
    {
        
        if (Input.GetButtonDown("Recover Item")) //If the buttons under Recover Item in the input manager is pressed, then...
        {

            if (trashFilled) //If trashFilled = true (an equipment is in the trash), then...
            {

                Inventory.instance.AddEquipment(inTrashEquipment); //Add the equipment back to the inventory.

                print("Recovered: " + inTrashEquipment.name + " - Level " + inTrashEquipment.level);

                trashFilled = false; //Set trash filled to false (notify the program, there's nothing in the trash).

            }

            else
            {

                print("No item in trash.");

            }

        }

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

        backpackHoverImage.enabled = false;

        FindInfoToDisplay();

    }

    public void FindInfoToDisplay() //This method finds what type of equipment the equipment is, and depending on that answer, will start another method that will display the according information.
    {

        if (displayInfo) //If the displayInfo boolean is true, then...
        {

            if (equipment.equipmentSlot == Equipment.EquipmentSlot.Shield) //If the equipment is a shield, then...
            {

                DisplayShieldInfo(); //Call the DisplayShieldInfo method.

            }
        
            if (equipment.equipmentSlot == Equipment.EquipmentSlot.Weapon) //If the equipment is a weapon, then...
            {

                DisplayGunInfo(); //Call the DisplayGunInfo method.

            }


        }

        else //If the displayInfo boolean is false, then...
        {

            RemoveInfo(); //Call the RemoveInfo method (remove the info from the description panel).

        }

    }


    string GettingRarityName() //This method finds the rarity of the equipment through its character, and then returns it as a string.
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


    int GettingRarityColour() //This method returns an integer, the integer is set depending on the character of the rarity of the equipment.
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

    void DisplayShieldInfo() //This method gets all of the information about the shield stored in this inventory slot and displays it to the user in images and text.
    {

        ShieldData shieldD = (ShieldData)equipment; //Creates a reference to a ShieldData script called equipment and assigns the equippedEquipment script to it (after parsing the equippedEquipment as a shield, so it can display shield specific data).


        string rarityName = GettingRarityName(); //Calls the GettingRarityName method whiles passing on the rarity of the equipment on to it, the value returned from the method is then saved as a string called rarityName, so it can put into a text label later.

        int rarity = GettingRarityColour();  //Calls the GettingRarityName method whiles passing on the rarity of the equipment on to it, the value returned from the method is then saved as an integer called rarityColour, so it can be displayed as an image later..

        backpackHoverImage.sprite = hoverRarityImage[rarity];

        backpackText.color = new Color32(255, 255, 255, 255);

        int capacity = shieldD.baseCapacity; //Sets the capacity value to the value stored within baseCapacity.
        int rechargeRate = shieldD.baseRechargeRate; //Sets the rechargeRate to the value stored within baseRechargeRate.

        int sellValue = Mathf.RoundToInt((float)(equipment.baseSellValue * Mathf.Pow(1.1301f, equipment.level))); //Gets the integer stored within 'baseSellValue', multiplies it by 1.1301 to the power of the integer stored within 'level', then gets the value stored in 'level', multiplies it by 3 and takes it away from the previous answer. It then makes sellValue equal to the previous answer. 
        int buyValue = equipment.baseSellValue * 2; //Multiplies the integer stored within 'sellValue' by 2 and stores it within 'buyValue'.

        //Gets the integer and string based information of the equipment and then assigns it to the descriptionLabels text labels. This is so the user can read the information of the equipment on screen.
        descriptionLabels[0].text = shieldD.name;
        descriptionLabels[1].text = shieldD.level.ToString();
        descriptionLabels[2].text = rarityName;
        descriptionLabels[3].text = capacity.ToString();
        descriptionLabels[4].text = rechargeRate.ToString();
        descriptionLabels[5].text = shieldD.rechargeDelay.ToString();
        descriptionLabels[8].text = shieldD.description;
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

/* 
        //Prints certain equipment information in the console.
        print(shieldD.name);
        print(shieldD.level);
        print(capacity);
        print(rechargeRate);
        print(shieldD.rechargeDelay);
        print(sellValue);
*/
    }


    void DisplayGunInfo()
    {

        GunData gunD = (GunData)equipment;

        rarityChar = gunD.rarity;

        string rarityName = GettingRarityName(); //Calls the GettingRarityName method and the string returned will be stored in a string variable called rarityName.

        int rarity = GettingRarityColour(); //Calls the GettingRarityColour method and the integer returned will be stored in an integer variable called rarity.

        backpackHoverImage.sprite = hoverRarityImage[rarity];

        backpackText.color = new Color32(255, 255, 255, 255);

        int damage = Mathf.RoundToInt((float)(gunD.baseDamage * Mathf.Pow(1.1301f, gunD.level))); //Calculates the damage of the weapon so it increases damage when the weapon level is increased.

        int sellValue = Mathf.RoundToInt((float)(gunD.baseSellValue * Mathf.Pow(1.1301f, gunD.level))); //Gets the integer stored within 'baseSellValue', multiplies it by 1.1301 to the power of the integer stored within 'level', then gets the value stored in 'level', multiplies it by 3 and takes it away from the previous answer. It then makes sellValue equal to the previous answer. 

        // Gets the integer and string based information of the equipment and then assigns it to the descriptionLabels text labels.This is so the user can read the information of the equipment on screen.
        descriptionLabels[0].text = gunD.name;
        descriptionLabels[1].text = gunD.level.ToString();
        descriptionLabels[2].text = rarityName;
        descriptionLabels[3].text = damage.ToString();
        //descriptionLabels[4].text = gunD.accuracy.ToString();
        descriptionLabels[5].text = gunD.reloadTime.ToString();
        descriptionLabels[6].text = gunD.maxMagAmmo.ToString();
        descriptionLabels[7].text = gunD.rateOfFire.ToString();
        descriptionLabels[8].text = gunD.description;
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

       /*  //Prints certain equipment information in the console.
        print(gunD.name);
        print(gunD.level);
        print(damage);
        //print(gunD.accuracy);
        print(gunD.reloadTime);
        print(gunD.maxMagAmmo);
        print(gunD.rateOfFire);
        print(sellValue);

*/
    }


    void RemoveInfo()//This method sets all of the text description text labels to nothing and disables all of the image components and text labels used by the equipment description panel. It also finds the rarity of the equipment and changes its text colour depending on the rarity.
    {

        //Disables the hover image.
        backpackHoverImage.enabled = false;

        switch (rarityChar) //c = common, u = uncommon, r = rare, [e = epic], h = heroic, l = legendary, m = mythic
        {

            case 'c': //If the character is a c, then...
                backpackText.color = new Color32(134, 134, 134, 255); //Changes the text colour of the backpackText to a grey colour.
                break; //Ends the switch statement.

            case 'u':
                backpackText.color = new Color32(100, 186, 84, 255);
                break;

            case 'r':
                backpackText.color = new Color32(90, 162, 237, 255);
                break;

            case 'h':
                backpackText.color = new Color32(154, 62, 234, 255);
                break;

            case 'l':
                backpackText.color = new Color32(230, 171, 77, 255);
                break;

            case 'm':
                backpackText.color = new Color32(218, 80, 74, 255);
                break;

            default:
                backpackText.color = new Color32(255, 255, 255, 255);
                break;

        }

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


}
