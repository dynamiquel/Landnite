//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour, IPointerEnterHandler {

    [Header("Links")]
    public AudioSource navigationAudiosource; //Creates a reference for an audio source called 'navgigationAudiosource'.
    public AudioClip hoverOverClip; //Creates a reference for an audio clip called 'hoverOverClip'.
    public GameObject quitMenuCanvas; //Creates a reference to a general game object called 'quitMenuCanvas'.

    public GameObject selectCharacter; //Creates a reference to a general game object called 'quitMenuCanvas'.
    public GameObject characterButtons;


      public void OnPointerEnter(PointerEventData ped) //When the mouse cursor enters the proximity of a raycast target, then...
      {
          navigationAudiosource.PlayOneShot(hoverOverClip); //Play the audio clip referenced in 'hoverOverClip' once from the 'navigationAudiosource' audio source.
      }

    public void Quit() //Creates a public method called 'Quit' that can be accessed by the inspector so when a particular button is clicked, this method will start.
	{
        
        quitMenuCanvas.SetActive(true); //Enables the game object referenced in the 'quitMenuCanvas' variable.

	}

  public void Select()
  {
      //GameObject selectCharacter = GameObject.Find("Character Selection");
      GameObject mainMenu = GameObject.Find("Main Menu Area");
      selectCharacter.SetActive(true);
      characterButtons.SetActive(true);
      mainMenu.SetActive(false);
  }

}
