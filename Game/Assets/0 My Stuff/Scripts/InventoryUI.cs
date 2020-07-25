//Project Landnite
//
//Created by Liam Hall on 16/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using TMPro;



public class InventoryUI : MonoBehaviour {
    
	public GameObject inventoryUI;  // The entire UI
    public Transform itemsParent;   // The parent object of all the items

    Inventory inventory;    // Our current inventory


    void Start () //This method is called when the class is started.
    {
        
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

    }

    void Update () //This method is called once per frame.
    {
        
            UpdateUI(); //Calls the UpdateUI method.

    }

  
    public void UpdateUI () //This method creates an array of inventory slots depending on the number of InventorySlots in the backpack. For every slot, the equipment item is sent to a visual inventory slot, so the user can see it on screen.
    {
        
        InventorySlot1[] slots = GetComponentsInChildren<InventorySlot1>(); //Creates an array of InventorySlot1s called slots. All of the InventorySlot1 components in the current transform is then assigned to the array.

        for (int i = 0; i < slots.Length; i++) //For every inventory slot...
        {
            
            if (i < inventory.equipments.Count) //If there is less slots than equipment in inventory, then...
            {
                
                slots[i].AddEquipment(inventory.equipments[i]); //Add the equipment to the slot (Calls the AddEquipment method in the current slot with the current equipment from inventory being sent over).

            } 

            else //If there are more slots than needed, then clear the slot.
            {
                
                slots[i].ClearSlot();  

            }

        }

        DisplayBackbackSpace(); //Calls the DisplayBackpackSpace method.
        DisplayCurrency(); //Calls the DisplayCurrency method.
        DisplayAmmo(); //Calls the DisplayAmmo method.

    }

    void DisplayBackbackSpace() //This method calculates the number of equipment the player has in their inventory and outputs it onto the screen, alongside the total inventory space the player has.
    {

        TMPro.TMP_Text backpackSpaceLabel = GameObject.Find("Used Space Text").GetComponent<TextMeshProUGUI>();

        int spaceUsed = inventory.equipments.Count;

        int spaceCapacity = inventory.space;

        backpackSpaceLabel.text = spaceUsed + "/" + spaceCapacity;

    }

    void DisplayCurrency() //This method finds the current currency the player has, and displays it in labels so the user can see.
    {

        TMPro.TMP_Text mainCurrencyLabel = GameObject.Find("Main Currency Text").GetComponent<TextMeshProUGUI>();

        TMPro.TMP_Text RareCurrencyLabel = GameObject.Find("Rare Currency Text").GetComponent<TextMeshProUGUI>();

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        PlayerData playerData = player.GetComponent<PlayerData>(); //Finds the script called "PlayerData" so it can access its variables.

        mainCurrencyLabel.text = playerData.currentMainCurrency + "";

        RareCurrencyLabel.text = playerData.currentRareCurrency + "";

    }

    void DisplayAmmo() //This method finds the current reserve ammo the player is holding, and displays all of it on screen.
    {

        TMPro.TMP_Text[] ammoTypeLabels = new TMP_Text[12]; //Creates an array of TMP_Text references.

        //Sets the following references to text components of the found game objects (text labels).
        //Current reserve ammo
        ammoTypeLabels[0] = GameObject.Find("Pistol Ammo Type Current Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[1] = GameObject.Find("SMG Ammo Type Current Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[2] = GameObject.Find("Shotgun Ammo Type Current Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[3] = GameObject.Find("Battle Rifle Ammo Type Current Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[4] = GameObject.Find("Assault Rifle Ammo Type Current Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[5] = GameObject.Find("Sniper Rifle Ammo Type Current Ammo").GetComponent<TextMeshProUGUI>();
       
        //Max reserve ammo.
        ammoTypeLabels[6] = GameObject.Find("Pistol Ammo Type Max Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[7] = GameObject.Find("SMG Ammo Type Max Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[8] = GameObject.Find("Shotgun Ammo Type Max Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[9] = GameObject.Find("Battle Rifle Ammo Type Max Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[10] = GameObject.Find("Assault Rifle Ammo Type Max Ammo").GetComponent<TextMeshProUGUI>();
        ammoTypeLabels[11] = GameObject.Find("Sniper Rifle Ammo Type Max Ammo").GetComponent<TextMeshProUGUI>();

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        PlayerData playerData = player.GetComponent<PlayerData>(); //Finds the script called "PlayerData" so it can access its variables.

        for (int i = 0; i < 6; i++) //For every current reserve ammo label, set it to the ammo the player currently has.
        {
             
            ammoTypeLabels[i].text = playerData.currentReserveAmmo[i] + "";

        }

        for (int i = 6; i < 12; i++) //For every max reserver ammo label, set it to the max possible ammo the player can have for each type.
        {

            ammoTypeLabels[i].text = playerData.maxReserveAmmo[i - 6] + "";

        }


    }

}
