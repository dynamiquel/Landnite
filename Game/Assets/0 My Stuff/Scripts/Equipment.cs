//Project Landnite
//
//Created by Liam Hall on 14/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment/Equipment")]
public class Equipment : Item {


	public int level; //Creates a public int called 'level'

	public override void Use() //Overrides the Use method used in the inherrited class.
    {

        base.Use(); //Executes everything in the Use method in the inherrited class.

        EquipmentManager.instance.EquipEquipment(this); //Sends the current equipment to the EquipEquipment method in the current instance of the EquipmentManager script.

       // RemoveEquipmentFromInventory();

	}

    public void RemoveEquipmentFromInventory() //This method removes the current equipment from the player's inventory by sending the current equipment to the Inventory instance.
    {
        Debug.LogError("////////////////////////////////ONE//////////////");
        Inventory.instance.RemoveEquipment(this); //Sends this current equipment to the RemoveEquipment method in the current instance of the Inventory class.

    }

    public enum EquipmentSlot { Weapon, Shield } //Creates an enumeration called EquipmentSlot and gives it two constants.

    public EquipmentSlot equipmentSlot; //Creates a public EquipmentSlot instance called equipmentSlot.

}



