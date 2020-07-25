//Project Landnite
//
//Created by Liam Hall on 28/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake() //This method is called when the script starts.
	{
        if (instance == null)
        {
            instance = this; //Sets the current instance to this.

            DontDestroyOnLoad(this.gameObject); //Prevents the game object this script is attached to from being removed between scenes.
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
