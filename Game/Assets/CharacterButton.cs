//Project Landnite
//
//Created by Liam Hall on 28/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public int characterButtonIndex;

	public TMP_Text characterText;

	public bool isUsed;

	public GameObject deleteButton;

	Image[] hoverImage = new Image[2]; //An array of the Image type. I have used array due to the fact of two mages being located wihthin this game object's children.

	public AudioSource navigationAudiosource; //Creates a reference for an audio source called 'navgigationAudiosource'.
    public AudioClip hoverOverClip; //Creates a reference for an audio clip called 'hoverOverClip'.

	// Use this for initialization
	void Awake()
	{
		characterText = GetComponentInChildren<TextMeshProUGUI>(); //Finds the text label within this game object's children and assigns it to a variable.
		hoverImage = GetComponentsInChildren<Image>(); //Finds the image within this game object's children and assigns it to a variable.
    }

	void Update()
	{
		CheckForSave(); //Calls the CheckForSave method.
	}

	public void OnPointerEnter(PointerEventData ped) //If the mouse enters the proximity of this game object, then...
    {
		WhenHovered(); //Calls the WhenHovered method.
	}

	public void WhenHovered() //This method gives audio and visual feedback to the user so they know they have hovered over the button.
	{
		hoverImage[1].enabled = true; //Shows the hoverImage to the user so the button looks different to buttons that are not hovered.
		navigationAudiosource.PlayOneShot(hoverOverClip); //Plays the navigationAudiosource once with the hoverOverClip audio clip.
	}

	public void OnPointerExit(PointerEventData ped) //If the mouse enters the proximity of this game object, then...
    {
		WhenNotHovered(); //Calls the WhenNotHovered method.
	}

	public void WhenNotHovered() //This method hides the hoverImage so the button goes back to its original non-hovered aesthetic.
	{
		hoverImage[1].enabled = false; //Disables the hoverImage.
	}

	void CheckForSave() //This method checks if a save exists with a particular save ID. If the save does exists, it will call methods that will display the save's data, else, it will call methods that will allow the user to create a new save.
	{
		if (File.Exists(Application.persistentDataPath + "/save" + characterButtonIndex + ".data")) //If a file exists at Unity's persistentDataPath (which would be under the AppData/Roaming folder within Windows 10), and the file is called 'Save"+characterButtonIndex+".data', then...
		{

			print("Save exists at slot: " + characterButtonIndex); //Print in console that the save exists.
			ShowDeleteButton(); //Call the ShowDeleteButton method.
			LoadData(); //Call the LoadData delete method.
		}
		else
		{
			print("No save exists at slot: " + characterButtonIndex); //Print in console that the save does not exist.
			HideDeleteButton(); //Call the HideDeleteButton method.
			SetAsNew(); //Call the SetAsNew method.
		}
	}

	public void DeleteSave() //This method finds the file that should be saved within this save slot, and then deletes it.
	{
		if (File.Exists(Application.persistentDataPath + "/save" + characterButtonIndex + ".data")) //If the save file for this character slot exists, then...
		{
			File.Delete(Application.persistentDataPath + "/save" + characterButtonIndex + ".data"); //Delete it.
			print("Save " + characterButtonIndex + " deleted."); //Prints in console that the save for this character slot has been deleted.
		}
		else //Else, if no save file can be found...
		{
			print("No save detected at saveslot: " + characterButtonIndex + " to delete."); //Print in console that no save file could be found.
		}
	}

	void ShowDeleteButton() //This method enables the deleteButton gameobject so the user is able to delete their save game.
	{
		deleteButton.SetActive(true);
	}

	void HideDeleteButton() //This method disables the deleteButton gameobject, this would be called if there is no save file to delete.
	{
		deleteButton.SetActive(false);
	}

	public GameObject creatingCharacter;

	void CreateCharacter() //This method changes which menu is shown to the user.
	{
		creatingCharacter.SetActive(true);

		GameObject.Find("Character Selection").SetActive(false);
        CharacterCreation cc = GameObject.Find("Select Character Canvas").GetComponent<CharacterCreation>();
		cc.menuID = 1;
        cc.characterButtonIndex = characterButtonIndex;
		cc.ChangeNextButton();
	}
    public GameObject loadingScreen;

	public void ButtonClick() //This method will be called whenever the button is clicked and it bascially decides what should happen if it is clicked.
	{
		print("Character slot " + characterButtonIndex + " clicked");

		if (isUsed) //If a save game exists at this slot, then...
		{
			SetPlayerData.instance.saveSlot = characterButtonIndex; //Tells the program that this save slot is wanted to be loaded.
            loadingScreen.SetActive(true);
			SceneManager.LoadScene(2); //Loads the scene that will retrieve all of the save data from the file and make it into a playable character.
		}
		else
		{
			CreateCharacter(); //Call the CreateCharacter method.
		}
	}

	void SetAsNew() //This method configures the characterButton to tell the user and the rest of the program that this save slot has no save assigned to it and can be used to create a save game.
	{
		characterText.text = "+"; //Changes the text within the button to "+".
		characterText.fontSize = 150; //Sets the font size of the text within the button to 150.
		isUsed = false; //Tells the rest of this script that this save slot has no save game assigned to it.
	}

	int level;
	int maxEXP;

	void LoadData() //This method gets some of the important data that is located within the save game file and displays it to the user. This info includes the character's name and level so the player has a great understanding of which of their characters it is.
	{
		//characterText.enabled = false;

		BinaryFormatter binaryFormatter = new BinaryFormatter(); //Creates a new binary formatter.
            FileStream file = File.Open(Application.persistentDataPath + "/save" + characterButtonIndex + ".data", FileMode.Open); //Opens the save game of this slot and saves its data to a binary file attribute called 'file'.
            SavedData sd = (SavedData)binaryFormatter.Deserialize(file); //Deserialises the binary file by using the binary formatter with the 'SavedData' class as the binary file is an object of the 'SavedData' class. It then saves all of this data as another SavedData object called sd so we can call its attributes.
            file.Close(); //Closes the binary file as it is no longer needed since we have the deserialsed version of the file.
			
			int level = Mathf.FloorToInt(Mathf.Pow((sd.currentEXP/2f), 10f/29f) / Mathf.Pow(5f, 20/29f)); //Calculates the characters level by their exp.
			if (level == 0) //If the level is 0, then change it to 1 as level 1 is the lowest possible level the player can be.
			{
				level = 1;
			}

            //Values being retrieved from the file and being set in the game.
			characterText.text = sd.name + " - " + level; //Sets the text within the character button to the name of the character and its level that was just calculated.
			characterText.fontSize = 70; //Reduces the font size to 70 so the character's name and level can fit within the button.
			isUsed = true; //Tells the rest of the script that there is a save game within this save slot.
	}
}
