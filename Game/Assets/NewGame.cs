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
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{

	public string name = "New Character";
	int currentEXP = 50;
	int currentMainCurrency = 0;
	int currentRareCurrency = 0;
	int[] currentReserveAmmo = new int[7];
	int[] maxReserveAmmo = new int[] {180, 340, 78, 142, 260, 46};
	int space = 10;

    public GameObject loadingScreen;

	public void Save(int saveSlot) //Saves the player's important data in a file in the app's folder. This method is called when the script starts but after the Awake method.
    {

        print("Saving data...");

        BinaryFormatter binaryFormatter = new BinaryFormatter(); //Creates a binary formatter.
        FileStream file = File.Create(Application.persistentDataPath + "/save" + saveSlot + ".data");

        SavedData sd = new SavedData(); //Creates a new object of the SavedData class and calls it sd.

        //Values being saved.
        sd.currentEXP = currentEXP;
        sd.name = name;
        sd.currentMainCurrency = currentMainCurrency;
        sd.currentRareCurrency = currentRareCurrency;
        sd.currentReserveAmmo = currentReserveAmmo;
        sd.maxReserveAmmo = maxReserveAmmo;
        //sd.equippedEquipment = equippedEquipment;
        sd.space = space;
        //sd.equipments = equipments;

        binaryFormatter.Serialize(file, sd); //Serializes the values and saves it in the app's folder.
        file.Close(); //Closes the file.

        print("Saving complete");

        SetPlayerData.instance.saveSlot = saveSlot;
        //loadingScreen.SetActive(true);
		SceneManager.LoadScene(2);

    }
}