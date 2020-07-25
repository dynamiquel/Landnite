//Project Landnite
//
//Created by Liam Hall on 14/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject {

    //Public variables allow the variables to be accessed by other classes. If the public variable is not hidden in inspector, their values can be assigned within the Unity Inspector instead of the script. This allows different game objects to use the same script but have different variables, such as multiple weapons having different statistics but use the same script.
    //Headers allow variables to be seperated in the Unity Inspector and is only for aesthetic purposes.
    [Header("Descriptions")]
    public int id;
    public new string name;
    public string description;
    public char rarity;

    [Header("Value")]
    public int baseSellValue;
    public int rareBaseSellValue;

    [Header("Image")]
    public Sprite itemImage;

    [Header("Booleons")]
    public bool isQuestItem = false;
    public bool isStackable = false;
    public bool destroyOnUse = false;
    public bool showInInventory = true;


    public virtual void Use()
    {

        Debug.Log("Using " + name); //Prints in the console that the user is using a certain item, with the name of the item in the output.

    }

    public void RemoveFromInventory()
    {

        //Inventory.instance.RemoveEquipment(this);

    }

}
