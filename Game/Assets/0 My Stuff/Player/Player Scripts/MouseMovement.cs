//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    [Header("Sensitivities")]

    [Range(1f, 24.0f)]
    public float mouseXSensitivity; //Creates a public float called mouseXSensitivity. This value is assigned in the Unity Editor. This sets the speed of the X axis of the mouse.
    [Range(1f, 24.0f)]
    public float mouseYSensitivity; //Creates a public float called mouseYSensitivity. This value is assigned in the Unity Editor. This sets the speed of the Y axis of the mouse.


    float xAxisClamp = 0.0f; //Creates a private flow called xAxisClamp. This float makes sure the user can only look up and down by 90 degrees.

    void Awake() //This void only runs once in its lifetime and it initialises variables before the game actually starts.
    {
        Cursor.lockState = CursorLockMode.Locked; //Once in the game, the cursor becomes locked, meaning it can't be moved. 
    }

    void Update() //This void runs once per frame.
    {
        RotateCamera(); //Calls the RotateCamera method.
    }

    void RotateCamera() //This method allows the user to use the mouse to rotate their view within the game.
    {
        if (PauseMenu.gamePaused == false)
        {

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float rotAmountX = mouseX * mouseXSensitivity;
            float rotAmountY = mouseY * mouseYSensitivity;

            xAxisClamp -= rotAmountY;

            Vector3 targetRot = transform.rotation.eulerAngles;

            targetRot.x -= rotAmountY;
            targetRot.z = 0;
            targetRot.y += rotAmountX;

            if (xAxisClamp > 90)
            {
                xAxisClamp = 90;
                targetRot.x = 90;
            }
            else if (xAxisClamp < -90)
            {
                xAxisClamp = -90;
                targetRot.x = 270;
            }

            //print("Mouse Y axis: " + mouseY); //Prints the position of the Y axis of the mouse in the console.

            //print("Mouse X axis: " + mouseX); //Prints the position of the X axis of the mouse in the console.


            transform.rotation = Quaternion.Euler(targetRot); //Applies the change of rotation of the mouse in the game.

        }


    }



}
