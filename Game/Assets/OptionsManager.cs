using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Print;

public class OptionsManager : MonoBehaviour
{
    string sN = "OPTIONS MANAGER", sC = "#40b01e";

    int previousScene = 0;

    public static OptionsManager instance; //This allows a particular instance of this class to be accessed by any other class in the program.

    private void Awake()
    {
        if (instance == null) //If an instance of thei script does not already exists, then...
        {
            instance = this; //Set the instance to this.

            DontDestroyOnLoad(gameObject); //Tell the program to not destory this object between scene changes. This allows the game object to be present in many scenes before reinitialising.
        }
        else //Else,
        {
            Destroy(gameObject); //Destory this game object as one already exists in the program.
        }
    }

    private void Update() //This method is called once every frame.
    {
        if (previousScene != SceneManager.GetActiveScene().buildIndex) //Check whether the scene has changed.
        {
            Print.Log("Scene has changed. Applying Options in game.", sN, sC);
            Options.instance.OptionsChanged(); //Calls the 'OptionsChanged' method in the current instance of the 'Options' class.
            Print.Log("Options have been set in game.", sN, sC);
            previousScene = SceneManager.GetActiveScene().buildIndex; //Changes the 'previousScene' to the current scene.
        }
    }
}
