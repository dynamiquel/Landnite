//Project Landnite
//
//Created by Liam Hall on 12/10/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterDeleteButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{

    Image[] hoverImage = new Image[2];

	public AudioSource navigationAudiosource; //Creates a reference for an audio source called 'navgigationAudiosource'.
    public AudioClip hoverOverClip; //Creates a reference for an audio clip called 'hoverOverClip'.

    // Start is called before the first frame update
    void Start()
    {
        hoverImage = GetComponentsInChildren<Image>();
    }

    public void OnPointerEnter(PointerEventData ped) //If the mouse enters the proximity of this game object, then...
    {
		WhenHovered(); //Calls the WhenHovered method.
	}

	public void WhenHovered() //This method changes the visual state of the button so the user knows if they are hovering over it, whiles also playing a sound.
	{
		hoverImage[1].enabled = true; //Enables the second image script located in the children of this game object.
		navigationAudiosource.PlayOneShot(hoverOverClip);
	}

	public void OnPointerExit(PointerEventData ped) //If the mouse enters the proximity of this game object, then...
    {
		WhenNotHovered(); //Calls the WhenNotHovered method.
	}

	public void WhenNotHovered() //This method changes the visual state of the button so the user knows when they are no longer hovering over the button.
	{
		hoverImage[1].enabled = false; //Disables the second image script located in the children of this game object.
	}
}
