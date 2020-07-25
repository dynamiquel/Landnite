//Project Landnite
//
//Created by Liam Hall on 27/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMusic : MonoBehaviour
{
    
    [Header("Links")]
    public AudioSource musicAudioSource; //Creates a reference to an audio source called 'musicAudiosource'.


    static bool AudioBegin = false; //Creates a booleon called 'AudioBegin' and sets it to false by default.



    void Awake() //A method that is called when the script is first accessed.
    {
        
            DontDestroyOnLoad(gameObject); //Tells Unity not to destroy this current game object when changing scenes. This allows the 'musicAudioSource' and the music assigned to it to keep playing when changing scenes.

    }

    void Update() //A method that is called once every frame.
    {
        
        if ((SceneManager.GetActiveScene().name == ("TitleScreen")) || (SceneManager.GetActiveScene().name == ("LaunchScreen"))) //Gets the name of the scene currently loaded, if the scene's name is not equal to "TitleScreen" or "LaunchScreen", then...
        {
            if (!AudioBegin) //If the 'AudioBegin' bool is false, then...
            {
                
                musicAudioSource.Play(); //Play the audio clip that is currently stored in the audio source referenced in 'musicAudioSource'.
                AudioBegin = true; //Set the 'AudioBegin' bool to true;

            }

            else //Else, if the 'AudioBegin' bool is true, then...
            {

                return; //Return.

            }

        }

        else //If the name of the current scene is not equal to "TitleScreen" or "LaunchScreen", then...
        {
            
            musicAudioSource.Stop(); //Stop playing the audio clip that is currently stored in the audio source referenced in 'musicAudioSource'.
            AudioBegin = false; //Set the 'AudioBegin' bool to false;

        }

    }

}