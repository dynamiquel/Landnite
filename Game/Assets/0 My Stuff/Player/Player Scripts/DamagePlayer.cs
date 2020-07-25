//Project Landnite
//
//Created by Liam Hall on 15/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public static DamagePlayer instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            GameObject shield = GameObject.Find("Shield"); //Finds the game object called "Player" so it can acces its scripts.

            Shield shieldD = shield.GetComponent<Shield>(); //Finds the script called "PlayerData" so it can access its variables.

            int totalHP = PlayerData.instance.currentMaxHealth + shieldD.currentCapacity;



            //  playerData.currentHealth -= Mathf.RoundToInt((float)((playerData.currentMaxHealth * 0.1f)));



            TakeDamage(Mathf.RoundToInt((float)((totalHP * 0.1f))));

        }
		
	}


    public void TakeDamage(int damage)
    {

        GameObject shield = GameObject.Find("Shield"); //Finds the game object called "Player" so it can acces its scripts.

        Shield shieldD = shield.GetComponent<Shield>(); //Finds the script called "PlayerData" so it can access its variables.

        int armourDamage = Mathf.Min(shieldD.currentCapacity, damage);
        int healthDamage = Mathf.Min(PlayerData.instance.currentHealth, damage - armourDamage);

        shieldD.currentCapacity -= armourDamage;
        PlayerData.instance.currentHealth -= healthDamage;

        shieldD.tookDamage = true;

    }

}
