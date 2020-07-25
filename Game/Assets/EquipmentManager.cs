//Project Landnite
//
//Created by Liam Hall on 14/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EquipmentManager : MonoBehaviour {

    public static EquipmentManager instance; //Creates an instance of the EquipmentManager class and calls it instance.

    public GameObject[] equipmentSlot = new GameObject[4]; //0 = Weapon 1, 1 = Weapon 2, 2 = Weapon 3, 3 = Shield.

    public Sprite[] equippedImage = new Sprite[7]; //0 = No-equipped, 1 = Common, 2 = Uncommon, 3 = Rare, 4 = Heroic, 5 = Legendary, 6 = Mythic.

    bool displayInfo; //Creates a boolean called displayInfo.

    void OnEnable()
    {
        equipmentSlot[0] = GameObject.Find("Weapon Slot 1");
        equipmentSlot[1] = GameObject.Find("Weapon Slot 2");
        equipmentSlot[2] = GameObject.Find("Weapon Slot 3");
        equipmentSlot[3] = GameObject.Find("Gear Slot 1");
    }

    private void Awake() //This method is called when the class starts, but before the Start method.
    {

        instance = this; //Sets the EquipmentManager instance to this current instance.

    }

    Inventory inventory; //Creates an instance of Inventory called inventory.

    public Equipment[] equippedEquipment;


    private void Start() //This method is called when the class starts.
    {

        inventory = Inventory.instance; //Makes the Inventory instance created in this class called inventory equal to the current instance within the Inventory class.

        int equipmentSlots = 4; //Creates an integer variable called equipmentSlots and makes it equal to four.

        //equippedEquipment = new Equipment[equipmentSlots]; //Sets the equippedEquipment array slot equal to a new Equipment class array with a size of the equipmentSlots (four).


       // LinkingSlots();
        LinkingImages(); //Calls the LinkingImages method.
        GettingEquippedItems(); //Calls the GettingEquippedItems method.

    }

    private void Update() //This method is called once per frame.
    {

        if(equipmentSlot[0] == null)
        {
            OnEnable();
        }

        GettingEquippedItems(); //Calls the GettingEquippedItems method.

    }

    public GameObject shieldd;

    public void EquipEquipment (Equipment newEquipment) //This method equips the equipment the user has chosen to equip by detecting the equipment slot of the equipment and then give it a certain slot depending on the equipment slot.
    {
        
        int slotIndex = (int)newEquipment.equipmentSlot; //Creates an integer called slotIndex and makes it equal to an integer converted version of the equipmentSlot enum in the Equipment class that was sent into the method from the Equipment class.

        Equipment oldEquippedEquipment; //Creates an Equipment class called oldEquippedEquipment.

       

        if (slotIndex == 1) //If slotIndex = 1 (the equipment slot of the equipment is a shield), then...
        {

            if (equippedEquipment[3] != null) //If equippedEquipment[3] is not null (there's a shield already equipped by the player), then...
            {

                oldEquippedEquipment = equippedEquipment[3]; //Make the oldEquippedEquipment equal to the Equipment class stored in equippedEquipment[3] (the equipped shield).

                inventory.AddEquipment(oldEquippedEquipment); //Add the previously equipped shield back to the inventory (call the AddEquipment method in the inventory instance of the Inventory class, with the oldEquippedEquipment as a parameter).
          
            }

            equippedEquipment[3] = newEquipment; //Sets the Equipment class in equippedEquipment[3] to the Equipment class in newEquipment. (Puts the shield the player used, in the shield equippable slot).

            equippedEquipment[3].RemoveEquipmentFromInventory(); //Calls the RemoveEquipmentFromInventory method in the class instance in equippedEquipment[3].

            shieldd.SetActive(false);
            shieldd.SetActive(true);
           
            Shield.instance.ResettingShield(); //Finds the Shield class, retrieves its instance and calls the ResettingShield method (this is so when the shield is switched, current capacity and other variables get reset).
            Shield.instance.GettingShieldData(); //Finds the Shield class, retrieves its instance and calls the ResettingShield method

        }

        if (slotIndex == 0) //If slotIndex = 0 (the equipment slot of the equipment is a weapon), then...
        {

            for (int i = 0; i < 3;) //Creates a for loop, that creates an integer, sets the integer to zero and keeps repeating until i is over 3.
            {
                

                if (equippedEquipment[i] == null) //If the equipmentSlot of [i] is null (empty), then...
                {

                    equippedEquipment[i] = newEquipment; //Gets the Equipment instance in newEquipment and sets it into the equippedEquipmen[i].
                    equippedEquipment[i].RemoveEquipmentFromInventory(); //Calls the RemoveEquipmentFromInventory method in the equippedEquipment[i] instance.

                    GameObject gun = GameObject.Find("Gun " + (i + 1)); //Creates a game object called gun, finds the game object called Gun i+1, and assigns it to the game object. + 1 is used because the array is between 0-2 but the game object is named from 1 - 3.

                    GunReworked gunData = gun.GetComponent<GunReworked>(); //Gets the Gun script component in the gun game object and assigns it to a variable called gunData.

                    gunData.OnEnable(); //Calls the GettingGunData method in the gunData script.
                        
                    return; //Ends the for loop.

                }

                else //Else, if the equippedEquipment[i] is not null (a weapon is equipped in the slot), then...
                {

                    i++; //Increment i by one. (moves onto the next equippedEquipment slot.

                }

            }

            //if (equippedEquipment[slotIndex] != null)
            //{

            if (equippedEquipment[0] != null && equippedEquipment[1] != null && equippedEquipment[2] != null) //If all weapon equipment slots currently have equipment assigned to them (equippedEquipment 0, 1 and 2 are not null), then...
                {

                    return;

                }

               // oldEquippedEquipment = equippedEquipment[slotIndex];

               // inventory.AddEquipment(oldEquippedEquipment);

           // }



        }

    }

    void LinkingSlots()
    {

      //  equipmentSlot[0] = GameObject.Find("Weapon Slot 1");
      //  equipmentSlot[1] = GameObject.Find("Weapon Slot 2");
       // equipmentSlot[2] = GameObject.Find("Weapon Slot 3");
       // equipmentSlot[3] = GameObject.Find("Gear Slot 1");

    }

    void LinkingImages() //This method finds the sprites that will be used for the equipped images and sets them accordingly to the equippedImage array.
    {

        equippedImage[0] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Equipped/Small/EmptyEquippedSmallButton");
        equippedImage[1] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Equipped/Small/CommonEquippedSmallButton");
        equippedImage[2] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Equipped/Small/UncommonEquippedSmallButton");
        equippedImage[3] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Equipped/Small/RareEquippedSmallButton");
        equippedImage[4] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Equipped/Small/HeroicEquippedSmallButton");
        equippedImage[5] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Equipped/Small/LegendaryEquippedSmallButton");
        equippedImage[6] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Equipped/Small/MythicEquippedSmallButton");


    }


    void GettingEquippedItems()
    {
   
        ShowingRarity(); //Calls the ShowingRarity method.

    }

    void ShowingRarity() //This method finds which sprite to use for the equipment and then calls the SendDataToInvSlot method.
    {
        
        Image[] equipmentSlotImage = new Image[4]; //Creates an array of images with the size of 4 and calls it equipmentSlotImage.


        for (int i = 0; i < equipmentSlotImage.Length; i++) //Creates a for loop with an int of 0. Each time the loop is completed, i is increased by one. Until i is larger than the length of the equipmentSlotImage array.
        {

            print("Equipment: " + i);

            equipmentSlotImage[i] = equipmentSlot[i].GetComponentInChildren<Image>(); //Gets the Image component in a child object of equipmentSlot[i] and assigns it equipmentSlotImage[i].

            print("Found image " + equipmentSlotImage);


            int rarity = GettingRarity(i); //Creates an integer called rarity which is equal to the value returned from the GettingRarity method. The i integer is sent through the method as a parameter.

            equipmentSlotImage[i].sprite = equippedImage[rarity]; //Sets the sprite in the equipmentSlotImage Image component equal to the sprite in equippedImage[rarity].

            print("Set" + i + "image to: " + rarity);

        }

        SendDataToInvSlot(); //Calls the SendDataToInvSlot method.

    }


    int GettingRarity(int i) //This method calls the GettingEquipmentRarity if there is equipment assigned to equippedEquipment[i] and passes the i integer value given to this method to the GettingEquipmentRarity method and recieves a value returned from it and names it rarity. If there is no equipment in the current slot, set the rarity int to zero. After, the value within rarity is then returned to where this method was called.
    {
    //    Equipment equipment = equippedEquipment[i];

        int rarity; //Creates an integer called rarity.

        if (equippedEquipment[i] != null)
        {

            print("Equipment Present");

            rarity = GettingEquipmentRarity(i); //Calls GettingEquipmentRarity with the value stored in the i integer, the data returned from this method is then assigned to the rarity integer. 

        }

        else //Else, then...
        {
            
            print("Equipment not present");

            rarity = 0; //Set rarity to zero.

        }


        return rarity; //Returns the value stored in rarity to integer that called this method.

    }




    int GettingEquipmentRarity(int i)
    {

        int rarity; //Creates an integer called rarity.

      //  Equipment equipment = equippedEquipment[i];

        //Creates a switch statement based of the rarity variable of equippedEquipment[i].
        switch (equippedEquipment[i].rarity) //c = common, u = uncommon, r = rare, [e = epic], h = heroic, l = legendary, m = mythic
        {

            case 'c': //If the rarity char is equal to 'c', then set rarity to 1 and end the case.
                rarity = 1;
                print("common");
                break;

            case 'u':
                rarity = 2;
                print("uncommon");
                break;

            case 'r':
                rarity = 3;
                print("rare");
                break;

            case 'h':
                rarity = 4;
                print("heroic");
                break;

            case 'l':
                rarity = 5;
                print("legendary");
                break;

            case 'm':
                rarity = 6;
                print("mythic");
                break;

            default:
                rarity = 0;
                print("no-equipped");
                break;

        }

        print("Equipment: " + rarity);

        return rarity; //Returns the rarity integer to integer that called this method.

    }


    public void SendDataToInvSlot() //Creates references to game objects called equipmenSlots and makes them equal to the weapon slots in the scene. It then gets the InventorySlot component of those slots and then sets the equippedEquipment instance equal to one of the equippedEquipments in the array.
    {
        InventorySlot[] inventorySlot = new InventorySlot[4];

        for (int i = 0; i < 4; i++)
        {
            inventorySlot[i] = equipmentSlot[i].GetComponent<InventorySlot>();

            inventorySlot[i].equippedEquipment = equippedEquipment[i];
        }

    }
   
}
