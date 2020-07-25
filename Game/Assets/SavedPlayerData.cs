//Project Landnite
//
//Created by Liam Hall on 28/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using System.IO;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SavedPlayerData : MonoBehaviour {

    public static SavedPlayerData instance;

    public int currentSaveSlot;
    public DateTime time;

    public void Awake() //This method is called when the class starts.
    {
        instance = this; //Sets the instance of this class to this class so it can be easily accessed by other classes.
    }

    public void Save() //Saves the player's important data in a file in the app's folder. This method is called when the script starts but after the Awake method.
    {

        print("Saving data...");

        BinaryFormatter binaryFormatter = new BinaryFormatter(); //Creates a binary formatter.
        FileStream file = File.Create(Application.persistentDataPath + "/save" + currentSaveSlot + ".data");

        SavedData sd = new SavedData();

        //Values being saved.
        sd.currentEXP = PlayerData.instance.currentEXP;
        sd.name = PlayerData.instance.name;
        sd.currentMainCurrency = PlayerData.instance.currentMainCurrency;
        sd.currentRareCurrency = PlayerData.instance.currentRareCurrency;
        sd.currentReserveAmmo = PlayerData.instance.currentReserveAmmo;
        sd.maxReserveAmmo = PlayerData.instance.maxReserveAmmo;
        //sd.equippedEquipment = EquipmentManager.instance.equippedEquipment;
        sd.space = Inventory.instance.space;
        sd.time = DateTime.UtcNow;
        

        binaryFormatter.Serialize(file, sd); //Serializes the values and saves it in the app's folder.
        file.Close();

        print("Saving complete");

    }

    public void Load(int saveSlot) //Loads the saved data located in the app's folder.
    {

        print("Loading saved data...");
        //If the saved data file exists, then open it and assign the values stored within the file into the game.
        if (File.Exists(Application.persistentDataPath + "/save" + saveSlot + ".data"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save" + saveSlot + ".data", FileMode.Open);
            SavedData sd = (SavedData)binaryFormatter.Deserialize(file);
            file.Close();

            //Values being retrieved from the file and being set in the game.
            PlayerData.instance.currentEXP = sd.currentEXP;
            PlayerData.instance.name = sd.name;
            PlayerData.instance.currentMainCurrency = sd.currentMainCurrency;
            PlayerData.instance.currentRareCurrency = sd.currentRareCurrency;
            PlayerData.instance.currentReserveAmmo = sd.currentReserveAmmo;
            PlayerData.instance.maxReserveAmmo = sd.maxReserveAmmo;
            //EquipmentManager.instance.equippedEquipment = sd.equippedEquipment;
            Inventory.instance.space = sd.space;
            currentSaveSlot = saveSlot;
            time = sd.time;

            print("Loading saved data complete");

            //LoadPlayerScene(); //Calls the LoadPlayerScene method.

            LoadingScreen.instance.LoadLevel(3);

        }
        else
        {

            Debug.LogError("No saved data found");
            SceneManager.LoadScene(1); //Loads the main menu scene.

        }
    }

    public void LoadPlayerScene() //Loads the scene that was the player's last location in the saved file.
    {
        
        print("Loading scene :");

        SceneManager.LoadScene(3); //Loads the selected scene

    }
}

[System.Serializable]
public class SavedData //This class will contain variables that will be stored in the save file.
{
    public int currentEXP;
    public string name;
    public int currentMainCurrency;
    public int currentRareCurrency;
    public int map;
    public int[] currentReserveAmmo = new int[7];
    public int[] maxReserveAmmo = new int[7];
    //public Equipment[] equippedEquipment = new Equipment[4];
    public int space;
    //public List<Equipment> equipments = new List<Equipment>();
    public int enemiesKilled;
    public int missionsCompleted;
    public float hoursPlayed;
    public int characterClass;
    public DateTime time;
}
