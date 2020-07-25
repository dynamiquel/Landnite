//Project Landnite
//
//Created by Liam Hall on 17/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class BackpackScrollList : MonoBehaviour {

    public Transform contentPanel;
    public BackpackObjectPool backpackObjectPool;


    // Use this for initialization, this is called when the class starts.
    void Start () 
    {
        
        RefreshScrollList (); //Calls the RefreshScrollList method.

    }

    public void RefreshScrollList() //This method calls other methods.
    {
        
        DeleteInventorySlot (); //Calls the DeleteInventorySlot method.
        AddInventorySlot (); //Calls the AddInventorySlot method.

    }
    /*
    private void Update()
    {
        DeleteInventorySlot();
    }*/

    private void DeleteInventorySlot()
    {
        
      /*  while (contentPanel.childCount > 0) 
        {
            
            GameObject toDelete = transform.GetChild(0).gameObject;
            backpackObjectPool.ReturnObject(toDelete);

        }

        if (contentPanel.childCount > Inventory.instance.equipments.Count)
        {

            Transform child = contentPanel.GetChild(Inventory.instance.equipments.Count + 1);

            Destroy(child);

        }*/

    }

    private void AddInventorySlot() //This method adds inventory slots depending on the number of equipment (the size of the equipments array in the inventory instance) the player has in their inventory.
    {
        
        for (int i = 0; i < Inventory.instance.equipments.Count; i++) //Keep repeating until the number of repeats is equal or more than the size of the equipments array in the Inventory instance. For every repeat, i is increased by one. (Repeat this loop for as many equipment the player has in their inventory).
        {
            
            //Equipment equipment = inventory.equipments[i];
            GameObject newButton = backpackObjectPool.GetObject(); //Creates a game object reference called newButton and assigns the object (prefab) in the backpackObjectPool to this game object. (Creates a copy of a prefab).
            newButton.transform.SetParent(contentPanel, false); //Moves the transform of the newButton game object to be the child of the transform in contentPanel. (Puts the prefab clone in the scroll view/inventory list).

        }

    }

}