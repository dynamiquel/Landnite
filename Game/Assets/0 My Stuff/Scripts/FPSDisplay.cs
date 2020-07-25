//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    float deltaTime = 0.0f;

    bool showingFPS = false;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        if (Input.GetKeyDown(KeyCode.F8))
        {

            if (showingFPS)
            {

                showingFPS = false;

            }

            else
            {

                showingFPS = true;

            }

        }

    }

    void OnGUI()
    {

        if (showingFPS == true)
        {

            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
            float fps = 1.0f / deltaTime;
            string text = string.Format("({0:0.} fps)", fps);
            GUI.Label(rect, text, style);

        }
    }
}