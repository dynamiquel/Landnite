//Project Landnite
//
//Created by Liam Hall on 10/10/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public void Save() //This method is public so it can be called by an external source.
    {
        SavedPlayerData.instance.Save(); //Calls the Save method within the SavedPlayerData instance.
    }
}
