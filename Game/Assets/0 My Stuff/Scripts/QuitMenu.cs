//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitMenu : MonoBehaviour, IPointerEnterHandler{

    [Header("Links")]

    [Header("")]

    [Header("General Objects")]

    public GameObject quitMenu; //Creates a reference to a general game object and calls the reference 'quitMenu'.
    public GameObject mainMenuEventSystem; //Creates a reference to a general game object and calls the reference 'mainMenuEventSystem'.

    [Header("Audio Sources")]

    public AudioSource navigationAudiosource; //Creates a reference to an audio source and calls the reference 'navigationAudiosource'.

    [Header("Audio Clips")]

    public AudioClip returnClip; //Creates a reference to an audio clip and calls the reference 'returnClip'.
    public AudioClip selectClip; //Creates a reference to an audio clip and calls the reference 'selectClip'.
    public AudioClip hoverOverClip; //Creates a reference to an audio clip and calls the reference 'hoverOverClip'.

    [HideInInspector]
    public bool previouslyOpened; //Creates a public bool called 'previouslyOpened'. It is public so other classes can access it.


    public void Quit() //Creates a public method called 'Quit' and is can be accessed by a particular button.
    {

        Application.Quit(); //Quits the game.

    }


    public void Return() //Creates a public method called 'Return' and is can be accessed by a particular button.
    {

        navigationAudiosource.PlayOneShot(returnClip); //Plays the audio clip referenced in 'returnClip' and plays it once in the audio source referenced in 'navigationAudiosource'.

        mainMenuEventSystem.SetActive(true); //Enables the game object referenced in 'mainMenuEventSystem'. This is so keyboards and gamepads can navigate across the buttons on the main menu.

        quitMenu.SetActive(false); //Disables the game object referenced in 'quitMenu' so the user no longer sees the quit menu.

    }


    private void Update() //A method that is called once every frame.
    {

        ReturnKey(); //Calls the method 'ReturnKey()'.

        OnOpen(); //Calls the method 'OnOpen()'.


    }


    void ReturnKey() //Creates a method called 'ReturnKey'. This method detects if the user has clicked ESC or (B), if so, it calls the 'Return()' method.
    {

        if (Input.GetButtonDown("Cancel")) //If the user has pressed a button under the 'Cancel' input in Unity's Input Manager (ESC or (B)), then...
        {

            Return(); //Calls the 'Return()' method.

        }

    }


    void SelectSound() //Creates a method called 'SelectSound()'. This method plays the audio clip referenced in 'selectClip' and plays it once in the audio source referenced in 'navigationAudioSource'.

    {

        navigationAudiosource.PlayOneShot(selectClip); //Plays the audio clip referenced in 'selectClip' and plays it once in the audio source referenced in 'navigationAudioSource'.

    }


    void OnOpen() //Creates a method called 'OnOpen()'. This method finds out if the quit menu is open by using the game object referenced in 'quitMenu'. If it is open, then it sets the event system referenced in 'mainMenuEventSystem'. This is so keyboard and gamepad input controls the navogation of the buttons in the quit menu instead of the main menu.
    {

        if (quitMenu.activeSelf == true) //If the game object referenced under 'quitMenu' is active, then... (if the quit menu is open, then...)
        {

            mainMenuEventSystem.SetActive(false); //Disable the game object referenced under 'mainMenyEventSystem'. (Disable the Event System that controls the main menu)

        }

    }


    public void OnPointerEnter(PointerEventData ped) //A method that detects when the pointer cursor is in proximity of a ray cast target (button) and plays the audio clip referenced in 'hoverOverClip' in the audio source referenced in 'navigationAudiosource'. (Plays the hover over sound effect when the user hover overs a button so they know they have changed button)
    {
        navigationAudiosource.PlayOneShot(hoverOverClip); //Plays the audio clip referenced in 'hoverOverClip' in the audio source referenced in 'navigationAudiosource'. (Plays the hover over sound effect when the user hover overs a button so they know they have changed button)
    }

}
