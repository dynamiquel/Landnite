//Project Landnite
//
//Created by Liam Hall on 16/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class ItemPickup : Interactable {

    public Equipment equipment;   // Item to put in the inventory if picked up

    // When the player interacts with the item
    public override void Interact()
    {
        
        base.Interact();

        PickUp();

    }

    // Pick up the item
    void PickUp ()
    {
        
        Debug.Log("Picking up " + equipment.name);
        Inventory.instance.AddEquipment(equipment);   // Add to inventory

        Destroy(gameObject);    // Destroy item from scene

    }

}
