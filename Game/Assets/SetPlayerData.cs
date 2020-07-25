//Project Landnite
//
//Created by Liam Hall on 28/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPlayerData : MonoBehaviour {

	public int saveSlot;

	public Scene currentScene;

	public static SetPlayerData instance;

	void Awake() //This method is called when the script is started.
	{
		if (instance == null) //If there is not an instance present, then...
		{
			print("No instance detected, setting this as instance");
			DontDestroyOnLoad(this.gameObject); //Makes sure this game object does not get destoyed when a new scene is loaded.

			instance = this; //Sets the instance to this.
		}
		else //Else (if an instance of this class already exists), then...
		{
			print("Instance detected, destroying");
			Destroy(gameObject); //Destroys this instance to make sure there is only one.
		}
	}

	void Update() //This method is called once every frame.
	{
		currentScene = SceneManager.GetActiveScene(); //Finds the current scene that is loaded and saves it as an attribute.

		if (currentScene.buildIndex == 2 && SavedPlayerData.instance != null) //If the buildIndex of the currentScene is 2 (the user is currently in the scene which loads character data from a partiuclar save slot), then...
		{
			print("Start");
			SavedPlayerData.instance.Load(saveSlot); //Calls the Load method in the SavedPlayerData script (loads the saved data).
			print("Finished Loading Saved Data");
		}

		if (currentScene.buildIndex > 2) //If the buildIndex of the current scene is greater than 2 (the user has finished loading their data), then...
		{
			Destroy(gameObject); //Destroys the game object this script is attached to.
		}
	}
	
}
