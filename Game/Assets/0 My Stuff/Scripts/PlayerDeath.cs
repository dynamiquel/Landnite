using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject playerDeathScreen;
    // Update is called once per frame
    void Update()
    {
        DetectPlayerHealth();
    }

    void DetectPlayerHealth() //This method calculates if the player currently has no health by accessing the player's current health through the 'PlayerData' instance.
    {
        if (PlayerData.instance.currentHealth <= 0) //If the player's current health is less or equal to 0, then...
        {
            KillPlayer(); //Call the 'KillPlayer' method.
        }
    }

    void KillPlayer() //This method calls other methods that are supposed to be displayed when the player dies.
    {
        print("Player died.");
        ShowPlayerDeathScreen(); //Calls the 'ShowPlayerDeathScreen' method.
        DisablePlayer(); //Calls the 'DisablePlayer' method.
    }

    void DisablePlayer() //This method tries to prevent the user from interacting in the game by altering the state of certain functions in the game.
    {
        Time.timeScale = 0f; //Freezes time in the game.
        Cursor.lockState = CursorLockMode.None; //Unlocks the cursor so it can be used to click buttons.
        Cursor.visible = true; //Makes the cursor visable to the user so they know what they are going to click.
        PlayerData.instance.GetComponent<MouseMovement>().enabled = false; //Disables the player from moving their character's camera in the game by disabling the script that causes this mechanism to work.
    }

    void ShowPlayerDeathScreen() //This method displays the 'PlayerDeathScreen' to the user.
    {
        playerDeathScreen.SetActive(true); //Display the 'playerDeathScreen'.
    }

    public GameObject loadingScreen;

    public void QuitGame() //This method returns the user to the main menu.
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(1); //Loads the main menu.
    }
}
