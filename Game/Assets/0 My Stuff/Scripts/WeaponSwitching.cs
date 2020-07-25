//Project Landnite
//
//Created by Liam Hall on 6/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {


    int selectedWeapon = 1;

    GunReworked[] gun = new GunReworked[3]; //Creates a new array called gun, which can hold three Gun scripts.

	// Use this for initialization
	void Start () //This method is called when the script starts.
    {

        ChangeWeapon(); //Calls the 'ChangeWeapon' method.

	}
	
	// Update is called once per frame
	void Update () 
    {

        UserInput(); //Calls the 'UserInput' method.
		
	}

    void ChangeWeapon()
    {

        int i = 0;

        foreach (Transform weapon in transform)
        {

            if (i == selectedWeapon)
            {

                weapon.gameObject.SetActive(true);

            }

            else
            {

                weapon.gameObject.SetActive(false);

            }

            i++;

        }

    }

    void UserInput() //This method detects mouse scroll wheel and keyboard input by the user, and if the input is correct, it will switch the currently held weapon.
    {

        int previousWeaponSelected = selectedWeapon; //Sets the previously selected weapon equal to the same integer value in 'selectedWeapon'. This is used to the program knows when the user has switched their weapon.


        if (Input.GetAxis("Mouse ScrollWheel") < 0f || Input.GetKeyDown(KeyCode.JoystickButton3)) //If the user scrolls their mouse scroll wheel in the positive direction (positive values are different in macOS and Windows) or clicks the Y button on the Xbox One controller, then...
        {

            if (selectedWeapon >= transform.childCount - 1) //If the selectedWeapon is the last weapon in the parent transform, then select the first weapon.
            {

                selectedWeapon = 0; //Sets the selected weapon to the first weapon.

            }

            else //Else if the selected weapon isn't the last one in the parent transform, then...
            {

                selectedWeapon++; //Sets the selectedWeapon up one integer. (The next weapon in the parent is selected).

            }

        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //If the user scrolls their mouse scroll wheel in a negative value, then...
        {

            if (selectedWeapon <= 0) //If the selectedWeapon is the first in the parent (equal or less than 0), then...
            {

                selectedWeapon = transform.childCount - 1; //Set the selectedWeapon to the last weapon in the parent.

            }

            else //Else, then...
            {

                selectedWeapon--; //Decend selectedWeapon variable by one integer (The previous weapon in the parent is selected).

            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) //If key 1 is pressed, then set the active weapon to the first weapon in the parent (first weapon in player's weapon holster).
        {

            selectedWeapon = 0;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //If key 2 is pressed, then set the active weapon to the second weapon in the parent (second weapon in player's weapon holster).
        {

            selectedWeapon = 1;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) //If key 3 is pressed, then set the active weapon to the third weapon in the parent (third weapon in player's weapon holster).
        {

            selectedWeapon = 3;

        }

        if (previousWeaponSelected != selectedWeapon) //If the value in previousWeaponSelected is not the same as selectedWeapon (the user has chosen to switch weapons), then...
        {

            ChangeWeapon(); //Calls the ChangeWeapon method.

        }

    }

}
