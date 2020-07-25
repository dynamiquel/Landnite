//Project Landnite
//
//Created by Liam Hall on 13/10/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDFix : MonoBehaviour
{

    public bool fixDone;

    HUDPlayerData playerHUD;

    // Start is called before the first frame update
    void Start()
    {
        if (!fixDone)
        {
            playerHUD = GameObject.Find("Player").GetComponent<HUDPlayerData>();
            
            playerHUD.OnEnable(); 
                        
            fixDone = true;
        }
    }

    /*if (!fixDone)
        {
            playerHUD = GameObject.Find("Player").GetComponent<HUDPlayerData>();
           
            while (playerHUD.currentHealthUI == null)
            {
                 playerHUD.OnEnable();
            }
            
            if (playerHUD.currentHealthUI != null)
            {        
                fixDone = true;
            }
        } */

    
}
