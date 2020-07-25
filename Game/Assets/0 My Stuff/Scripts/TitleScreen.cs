//Project Landnite
//
//Created by Liam Hall on 27/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    [Header("Links")]
    public AudioSource selectAudioSource; //Creates a reference to an audio source and calls the reference 'selectAudioSource'.

	void Update() //A method which is called every frame.
	{

        PlayGame(); //Calls the 'PlayGame()' method.

	}

	void PlayGame() //Creates a method called 'PlayGame'. This method will detect when the user has entered a key, and if so, will load the main menu scene.
	{

        if (Input.anyKeyDown) //If any key or button is pressed, then...
        {

            selectAudioSource.Play(); //Plays the audio source referenced in 'selectAudiosource'.

            SceneManager.LoadScene(1); //Loads scene 1.
		}

	}
}
