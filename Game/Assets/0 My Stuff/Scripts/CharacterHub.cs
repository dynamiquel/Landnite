//Project Landnite
//
//Created by Liam Hall on 15/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterHub : MonoBehaviour {
    
    [HideInInspector]
    public bool hubOpen = false; //Creates a bool called gamePaused and sets it to false by default. It is public so other classes can use it.


    [Header("Links - User Interface")]
    public GameObject characterHubUI; //Creates a GameObject and lets it link to a game object in the scene (the pause menu).

    public GameObject hudCanvas; //Creates a reference to a game object and calls the reference 'hudCanvas'.

    public GameObject pauseMenuUI; //Creates a reference to a game object and calls the reference 'pauseMenuUI'.


    TMPro.TMP_Text levelUI;

    TMPro.TMP_Text playerNameUI;

    bool gun1Setup;
    bool gun2Setup;
    bool gun3Setup;

    private void Start() //A method that is called at the beginning of the script.
    {

        Resume(); //Calls the 'Resume()' method.

    }


    private void Update() //A method that is called once every frame.
    {
        
    //This if statement toggles between resume and pause when the ESC key is pressed.
        if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton6)) && pauseMenuUI.activeSelf == false) //If ESC is pressed, then...
        {

        if (hubOpen) //If the gamePaused bool is set to true (game is paused), then...
            {

                Resume(); //Calls the Resume method.

            }

            else //Else if the gamePaused bool is set to false (game is playing), then...
            {
                
                Pause(); //Calls the Pause method.

            }

        }

    }

    void Resume()
    {

        characterHubUI.SetActive(false); //Hides the pauseMenuUI (pause menu).

        Time.timeScale = 1f; //Sets the time scale of the game to normal.

        Cursor.lockState = CursorLockMode.Locked; //Locks the cursor in the centre of the screen.

        Cursor.visible = false; //Hides the cursor so the user can't see it when playing the game.

        hubOpen = false; //Sets the gamePaused bool to false.

        hudCanvas.SetActive(true);

        if (!gun1Setup)
        {
            GameObject gun1 = GameObject.Find("Gun 1");

            if (gun1 != null)
            {
                GunReworked gun1D = gun1.GetComponent<GunReworked>();
                gun1D.OnEnable();
                gun1.SetActive(false);
                gun1Setup = true;
            }
        }
        
        if (!gun2Setup)
        {
            GameObject gun2 = GameObject.Find("Gun 2");

            if (gun2 != null)
            {
                GunReworked gun2D = gun2.GetComponent<GunReworked>();
                gun2D.OnEnable();
                gun2.SetActive(false);
                gun2Setup = true;
            }
        }

        if (!gun3Setup)
        {
            GameObject gun3 = GameObject.Find("Gun 3");

            if (gun3 != null)
            {
                GunReworked gun3D = gun3.GetComponent<GunReworked>();
                gun3D.OnEnable();
                gun3.SetActive(false);
                gun3Setup = true;
            }
        }

        print("Hub Closed."); //Outputs the game is resumed in the console.

        GameObject[] gun = GameObject.FindGameObjectsWithTag("Gun"); //Finds the game object called "Player" so it can acces its scripts.

        for (int i = 0; i < 3; i++)
        {
            gun[i].GetComponent<GunReworked>().enabled = true;
        }

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        player.GetComponent<PlayerMovement>().enabled = true; //Finds the script called "PlayerData" so it can access its variables.

        player.GetComponent<MouseMovement>().enabled = true;

       

    }

    void Pause()
    {
        

        characterHubUI.SetActive(true); //Shows the pauseMenuUI (pause menu)

        ApplyingData();

        Time.timeScale = 0f; //Freezes time in the game.

        Cursor.lockState = CursorLockMode.None; //Unlocks the cursor so the user can move it throughout the pause menu.

        Cursor.visible = true; //Shows the cursor so the user knows where it is on the screen.

        hubOpen = true; //Sets the gamePaused bool to true.

        hudCanvas.SetActive(false);

        print("Hub Open"); //Outputs the game is paused in the console.


        GameObject[] gun = GameObject.FindGameObjectsWithTag("Gun"); //Finds the game object called "Player" so it can acces its scripts.

        for (int i = 0; i < 3; i++)
        {
            gun[i].GetComponent<GunReworked>().enabled = false;
        }

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        player.GetComponent<PlayerMovement>().enabled = false; //Finds the script called "PlayerMovement" and disables it.

        player.GetComponent<MouseMovement>().enabled = false; //Finds the script called "MouseMovement" and disables it.

        player.GetComponent<DamagePlayer>().enabled = false; //Finds the script called "MouseMovement" and disables it.



    }

    public void ResumeGame() //A public method that can be called when a particular button is clicked.
    {

        Resume(); //Calls the Resume method.

    }


    void ApplyingData()
    {

        levelUI = GameObject.Find("Player Level Text").GetComponent<TextMeshProUGUI>();

        playerNameUI = GameObject.Find("Player Name Text").GetComponent<TextMeshProUGUI>();

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        PlayerData playerData = player.GetComponent<PlayerData>(); //Finds the script called "PlayerData" so it can access its variables.

        levelUI.text = "LEVEL " + playerData.currentLevel;

        playerNameUI.text = playerData.name;

    }

}
