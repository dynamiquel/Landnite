//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour, IPointerEnterHandler {

	
    public static bool gamePaused = false; //Creates a bool called gamePaused and sets it to false by default.


    [Header("Links - User Interface")]

	public GameObject pauseMenuUI; //Creates a GameObject and lets it link to a game object in the scene (the pause menu).

    public GameObject hudCanvas; //Creates a reference for a general game object and calls the reference 'hudCanvas' (the HUD canvas).

    public GameObject characterHubUI;  //Creates a reference for a general game object and calls the reference 'characterHubUI' (the Character Hub Menu).


    [Header("Links - Audio Sources")]

    public AudioSource navigationAudiosource;//Creates a reference for an audio source called 'navgigationAudiosource'.


    [Header("Links - Audio Clips")]

    public AudioClip selectClip; //Creates a reference to an audio clip and calls the reference 'selectClip'.

    public AudioClip returnClip; //Creates a reference to an audio clip and calls the reference 'returnClip'.

    public AudioClip hoverOverClip; //Creates a reference to an audio clip and calls the reference 'hoverOverClip'.

    public static PauseMenu instance;

    void Awake()
    {
        instance = this;
    }

	public void Start()
	{
		
        Resume(); //When the script is first run, it calls the Resume method.

	}

	private void Update()
	{
		 
        //This if statement toggles between resume and pause when the ESC key is pressed.
        if ((Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.JoystickButton7))) && characterHubUI.active == false) //If ESC is pressed, then...
        {

			if (gamePaused) //If the gamePaused bool is set to true (game is paused), then...
            {
                if (OptionsMenu.instance.menuOpen)
                {
                    OptionsMenu.instance.BackButton();
                }
                else
                {

                    Resume(); //Calls the Resume method.

                }

            }

			else //Else if the gamePaused bool is set to false (game is playing), then...
            {
                
                Pause(); //Calls the Pause method.

            }

        }

	}

    void Resume()
    {


		pauseMenuUI.SetActive(false); //Hides the pauseMenuUI (pause menu).

        ReturnSound();

        Time.timeScale = 1f; //Sets the time scale of the game to normal.

        Cursor.lockState = CursorLockMode.Locked; //Locks the cursor in the centre of the screen.

        Cursor.visible = false; //Hides the cursor so the user can't see it when playing the game.

        gamePaused = false; //Sets the gamePaused bool to false.

        hudCanvas.SetActive(true);

		print("Game resumed"); //Outputs the game is resumed in the console.

        GameObject gun = GameObject.FindWithTag("Gun"); //Finds the game object called "Player" so it can acces its scripts.

        gun.GetComponent<GunReworked>().enabled = true; //Finds the script called "PlayerData" so it can access its variables.

        PlayerData.instance.GetComponent<PlayerMovement>().enabled = true; //Finds the script called "PlayerData" so it can access its variables.

        PlayerData.instance.GetComponent<MouseMovement>().enabled = true;

    }

	void Pause()
    {

		pauseMenuUI.SetActive(true); //Shows the pauseMenuUI (pause menu)

        Time.timeScale = 0f; //Freezes time in the game.

		Cursor.lockState = CursorLockMode.None; //Unlocks the cursor so the user can move it throughout the pause menu.

        Cursor.visible = true; //Shows the cursor so the user knows where it is on the screen.

		gamePaused = true; //Sets the gamePaused bool to true.

        hudCanvas.SetActive(false);

		print("Game paused"); //Outputs the game is paused in the console.

        GameObject gun = GameObject.FindWithTag("Gun"); //Finds the game object called "Player" so it can acces its scripts.

        gun.GetComponent<GunReworked>().enabled = false; //Finds the script called "PlayerData" so it can access its variables.

        PlayerData.instance.GetComponent<PlayerMovement>().enabled = false; //Finds the script called "PlayerData" so it can access its variables.

        PlayerData.instance.GetComponent<MouseMovement>().enabled = false;


    }

    public void ResumeGame() //Creates a public method called 'ResumeGame', since it's public, it allows a button press to call this method.
    {

        Resume(); //Calls the Resume method.

    }

    public void ReturnToMainMenu() //Creates a public method called 'ReturnToMainMenu', since it's public, it allows a button press to call this method.
    {

        SelectSound(); //Calls the 'SelectSound' method.

	//	SceneManager.LoadScene(1); //Loads scene 1 (the main menu).

    }

    void SelectSound() //This method plays the 'selectClip' once in the 'navigationAudiosource' (the select button sound is played).
    {

        navigationAudiosource.PlayOneShot(selectClip); //Plays the audio clip referenced within 'selectClip' and plays it once in the audio source referenced in 'navigationAudiosource'.

    }

    void ReturnSound() //This method plays the 'returnClip' once in the 'navigationAudiosource' (the return button sound is played).
    {

        navigationAudiosource.PlayOneShot(returnClip); //Plays the audio clip referenced within 'returnClip' and plays it once in the audio source referenced in 'navigationAudiosource'.

    }

    public void OnPointerEnter(PointerEventData ped) //This method is called when the pointer cursor is in proximity of a raycast target (button). When it is, the 'hoverOverClip' audio clip is played in the 'navigationAudiosource' audio source. (a hover sound effect is played when the user hover overs a new button)
    {
        navigationAudiosource.PlayOneShot(hoverOverClip); //Plays the audio clip referenced within 'hoverOverClip' and plays it once in the audio source referenced in 'navigationAudiosource'.
    }
}
