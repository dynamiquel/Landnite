//Project Landnite
//
//Created by Liam Hall on 29/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {


    public GameObject loadingScreen; //Creates a reference to a game object and calls the reference 'loadingScreen'.

    public static LoadingScreen instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            print("Loading Screen // Instance already exists.");
        }
    }

    public void LoadLevel (int sceneIndex) //A public void called 'LoadLevel'. Since it's public, it can be accessed by a particular button click.
    {

        StartCoroutine(LoadASync(sceneIndex)); //Gets an integer value from 'sceneIndex', which would be given by the inspector. It then loads the 'LoadASync' method whiles passing the 'sceneIndex' integer into the method.

    }

    IEnumerator LoadASync (int sceneIndex) //A method called 'LoadASync'. It recieves an integer from the method call, and saves it into an integer called 'sceneIndex'.
    {

        loadingScreen.SetActive(true); //Sets the 'loadingScreen' game object active. (Shows the loading screen to the user).

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex); //Creates an AsyncOperation, calls it 'asyncOperation' and loads the scene with the 'sceneIndex' value into it.

        while (!asyncOperation.isDone) //While the 'asyncOperation' is not complete, then... (If the scene hasn't finished loading)
        {

            float loadProgress = Mathf.Clamp01(asyncOperation.progress / .9f); //Gets the percentage of how close the scene is to loading and saves it in the 'loadProgress' float.

            print(loadProgress * 100 + "%"); //Prints the value stored in 'loadProgress'. (Prints the percentage of how much the scene has loaded).


            yield return null; //Repeats the while loop once per frame.

        }

    }

}
