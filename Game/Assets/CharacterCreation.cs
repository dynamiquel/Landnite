//Project Landnite
//
//Created by Liam Hall on 1/9/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreation : MonoBehaviour {

	public static CharacterCreation instance;
	public int menuID = 0;

	public GameObject characterClass;
	public GameObject creatingCharacter;
	public GameObject mainMenu;
	public GameObject characterSelection;
	public GameObject characterButtons;
	public GameObject nextButton;
	public InputField characterNameField;
	public int characterButtonIndex;
	public GameObject loadingScreen;

	void Awake() //This method is called when the script is enabled.
	{
		instance = this;
	}

	void Start() //This method is called when the script is enabled, but after Awake.
	{
		ChangeNextButton(); //Calls the ChangeNextButton method.
	}

    public void ChangeNextButton() //This method determines whether the next button on the UI should be shown depending on what stage the menu is on.
	{
		if (menuID == 0) //If the menuID integer is 0 (the user is on the character selection menu), then...
		{
			nextButton.SetActive(false); //Hides the nextButton button game object so the user cannot interact with it.
		}
		else //Else, (if the user is deeper in the menus), then...
		{
			nextButton.SetActive(true); //Shows the nextButton button so the user can interact with it.
		}
	}

	public void Next() //This public method is called when the next button is clicked by the user. It sets up the next menu by figuring out what menu it is currently on and rearraning the menu's gameobjects to make it suitable for the next menu.
	{
		if (menuID == 0) //If the user is still on the character selection screen and the next button is pressed, then...
		{
			characterSelection.SetActive(false); //Hides the character selection screen.
			creatingCharacter.SetActive(true); //Shows the creating character screen.

			menuID = 1; //changes the menuID integer to one so the rest of the class knows it is on a different menu.

			ChangeNextButton(); //Calls the ChangeNextButton method.
		}
		if (menuID == 1) //If the character is on the creating character screen and clicks the next button, then...
		{
			loadingScreen.SetActive(true); //Shows the loading screen.

			creatingCharacter.SetActive(false); //Hides the creating character menu.

			string characterName = characterNameField.text;

			if(characterName == "") //IF the user did not enter a name for their character, then...
			{
				characterName = "New Character"; //Set it to the default name of NewCharacter.
			}

			NewGame ng = new NewGame(); //Creates a new object of the class, NewGame and calls is ng.
			ng.name = characterName; //Changes the public string called name in the ng object to the string stored in characterName.
			ng.Save(characterButtonIndex); //Calls the Save method in the ng object whiles parsing the value stored in characterButtonIndex over so the ng object knows what save slot the character should use.
			
			//characterClass.SetActive(true);
			//menuID = 2;
		}
/* 
		if (menuID == 2)
		{
			//Create the new save and load
		}*/
	}

	public void Back() //This public method is called when the Back button game object is clicked by the user. It determines which menu the game should transition to if the button is clicked.
	{
		if (menuID == 0) //If the user is currently on the character selection menu and clicks Back, then the user is returned to the main menu.
		{
			mainMenu.SetActive(true); //Shows the main menu.
			characterButtons.SetActive(false); //Hides the Next and Back button.
			characterSelection.SetActive(false); //Hides the character selection menu.
            creatingCharacter.SetActive(false);
		}

		if (menuID == 1) //If the user is on the creating character menu and clicks back, then the user is returned to the character selection menu.
		{
			characterSelection.SetActive(true); //Shows the character selection menu.
			creatingCharacter.SetActive(false); //Hides the creating character menu.

			menuID = 0; //Sets menuID integer to 0 so the rest of the class knows what menu the user is currently on.

			ChangeNextButton(); //Calls the ChangeNextButton method.
		}
/*
		if (menuID == 2)
		{
			characterClass.SetActive(false);
			creatingCharacter.SetActive(true);
			
			menuID = 1;
		}*/
	}
	
}
