//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class Crosshair : MonoBehaviour {
    
    public static bool gamePaused = false;

    public Texture2D crosshairImage;

    public GameObject pauseMenuUI;

    public GameObject characterHubUI;


	

	void OnGUI()
    {
        if (pauseMenuUI.activeSelf == false && characterHubUI.activeSelf == false)
        {
            
            float x = (Screen.width / 2) - (crosshairImage.width / 2);
            float y = (Screen.height / 2) - (crosshairImage.height / 2);
            GUI.DrawTexture(new Rect(x, y, crosshairImage.width, crosshairImage.height), crosshairImage);

        }
    }
}
