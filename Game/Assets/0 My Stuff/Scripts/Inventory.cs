//Project Landnite
//
//Created by Liam Hall on 16/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Inventory : MonoBehaviour {


    public static Inventory instance;

    void Awake () //This method is called when the script is initialised but before the Start method.
    {
        
        instance = this; //Sets the instance of Inventory to this instance.

    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;  //Creates a public int called space, and this would be the number of inventory space of the player.

    
    public List<Equipment> equipments = new List<Equipment>(); //Creates a public Equipment list called equipments and it contains a list of the equipments in the inventory.

    public void AddEquipment (Equipment equipment) //This method adds a piece of equipment to the inventory if there's enough room.
    {
        
        if (equipment.showInInventory) //If the equipment has the showInInventory boolean set to true (is allowed to be shown in inventory), then...
        {
            
            if (equipments.Count >= space) //If the number of equipment is equal to or more than space (inventory is full), then notify its full and do nothing else.
            {
                
                print("Inventory full.");
                return; //Go back to the start of the previous if statement, this is so the code under this if statement isn't called once this if statement is complete.

            }

            equipments.Add(equipment); //Adds the equipment to the equipments list (inventory).

            if (onItemChangedCallback != null)
            {

                onItemChangedCallback.Invoke();

            }

        }

    }

    public void RemoveEquipment (Equipment equipment) //This method removes the equipment sent to it from the inventory.
    {
        
        equipments.Remove(equipment); //Removes the equipment from the equipments list (inventory).
        Debug.LogError("////////////////////////////////////////////////////////TWO////////////////////////////////");


       /* if (onItemChangedCallback != null)
        {

            onItemChangedCallback.Invoke();

        }*/
        
    }

}
