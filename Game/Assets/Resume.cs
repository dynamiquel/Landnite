using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    bool[] saveExists = new bool[5];
    DateTime[] time = new DateTime[5];

    public GameObject resumeButton;
    public GameObject loadingScreen;

    int mostRecentIndex;

    public void Check()
    {
        for (int i = 0; i < saveExists.Length; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/save" + i + ".data")) //If a file exists at Unity's persistentDataPath (which would be under the AppData/Roaming folder within Windows 10), and the file is called 'Save"+characterButtonIndex+".data', then...
            {
                saveExists[i] = true; //Tells the class that a save exists at this current save slot
                time[i] = LoadData(i); //Calls the 'LoadData' method with the current save slot, the method will then return the time stored in this save and save it in the 'time' array under the current save slot.
            }
            else //Else,
            {
                saveExists[i] = false; //Tells the class that a save does not exist at this current save slot.
            }
        }

        if (!(saveExists[0] || saveExists[1] || saveExists[2] || saveExists[3] || saveExists[4] || saveExists[5])) //If no save exists, then...
        {
            resumeButton.SetActive(false); //Hides the 'Resume' button so the user cannot click it as they have no save to resume.
        }
        else //Else,
        {
            resumeButton.SetActive(true); //Displays the 'Resume' button as the user has a save they can resume.
        }

        DateTime mostRecent = time.Max(); //Gets the most recent time in the 'time' array and saves it as a variable called 'mostRecent'.
        mostRecentIndex = time.ToList().IndexOf(mostRecent); //Converts the time array into a list and finds the index of the 'mostRecent' time and saves it in a veriable called 'mostRecentIndex'. This value will be the most recently saved save slot.
    }

    // Start is called before the first frame update
    void Start()
    {
        Check();
    }

    public void LoadMostRecent() //This mehtod loads the most recent save.
    {
        SetPlayerData.instance.saveSlot = mostRecentIndex; //Tells the program that this save slot is wanted to be loaded.
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(2); //Loads the scene that will retrieve all of the save data from the file and make it into a playable character.  
    }

    DateTime LoadData(int i) //This method gets some of the important data that is located within the save game file and displays it to the user. This info includes the character's name and level so the player has a great understanding of which of their characters it is.
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter(); //Creates a new binary formatter.
        FileStream file = File.Open(Application.persistentDataPath + "/save" + i + ".data", FileMode.Open); //Opens the save game of this slot and saves its data to a binary file attribute called 'file'.
        SavedData sd = (SavedData)binaryFormatter.Deserialize(file); //Deserialises the binary file by using the binary formatter with the 'SavedData' class as the binary file is an object of the 'SavedData' class. It then saves all of this data as another SavedData object called sd so we can call its attributes.
        file.Close(); //Closes the binary file as it is no longer needed since we have the deserialsed version of the file.

        return sd.time; //Returns the time of the saved data.
    }

}
