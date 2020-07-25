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

public class PlayerManager : MonoBehaviour {

	Scene currentScene; //Creates a reference to a scene, scene will be assigned to it later.

	int previousSceneIndex; //Creates an integer that will be used in this script to store the scene index of a scene.

	void Awake() //This method is called when the script starts, but before the Start method.
	{
		DontDestroyOnLoad(this.gameObject); //Prevents the game object this script is attached to from being removed between scenes.
	}

	void Update() //This method is called once per frame.
	{
		CheckScene(); //Calls the CheckScene method.
	}

	void CheckScene() //This method gets the loaded scene and determines whether something needs to be done to the game object depending on the scene it is currenlty in.
	{
		currentScene = SceneManager.GetActiveScene(); //Gets the scene that is currently loaded and saves it in the currentScene scene I declared at the start of the script.

		if (currentScene.buildIndex != previousSceneIndex) //If the scene has changed since the last time the following code was executed, then go through this code again to determine if something needs to be done with this game object.
		{
			if (currentScene.buildIndex == 1) //If the player is in the main menu, then destroy the 'Player' game object.
			{
				Destroy(GameManager.instance.gameObject);
				Destroy(this.gameObject); //Destroys the game object this script is attached to (Player).
			}

			if (currentScene.buildIndex != 2) //If the player is currently in a playable scene, then enable components such as camera and movement.
			{
				EnableComponents(); //Calls the EnableComponents method.
			}

			previousSceneIndex = currentScene.buildIndex; //Gets the scene index number of the current scene and saves it as an intefer in the previousSceneIndex integer variable.
		}
	}

	void EnableComponents() //This method will enable the components on this game object that are required to play the game, this includes the camera, movement system, etc.
	{
		gameObject.GetComponent<MouseMovement>().enabled = true;
		gameObject.GetComponent<PlayerMovement>().enabled = true;
		gameObject.GetComponent<HUDPlayerData>().enabled = true;
		gameObject.GetComponent<DamagePlayer>().enabled = true;
		gameObject.GetComponentInChildren<Camera>().enabled = true;
	}
}
