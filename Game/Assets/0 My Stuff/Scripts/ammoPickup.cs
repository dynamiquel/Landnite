//Project Landnite
//
//Created by Liam Hall on 10/7/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ammoPickup : MonoBehaviour {

	public char ammoType;
    int ammoValue;
    
	public void OnTriggerEnter(Collider collision)
	{

        if (collision.gameObject.tag == "Player")
        {
            if(PlayerData.instance != null)
            {
                print("In contact with ammo.");

                if (ammoType == '1') //If the ammoType is 1, then find the ammo value of PistolAmmo and add it to the player's pistol reserve ammo.
                {
                    PistolAmmo();
                    PlayerData.instance.currentReserveAmmo[0] += ammoValue;
                }
                else if (ammoType == '2') //If the ammoType is 2, then find the ammo value of SMGAmmo and add it to the player's SMG reserve ammo.
                {
                   SMGAmmo();
                   PlayerData.instance.currentReserveAmmo[1] += ammoValue;
                }
                else if (ammoType == '3') //If the ammoType is 3, then find the ammo value of ShotgunAmmo and add it to the player's shotgun reserve ammo.
                {
                    ShotgunAmmo();
                    PlayerData.instance.currentReserveAmmo[2] += ammoValue;
                }
                else if (ammoType == '4') //If the ammoType is 4, then find the ammo value of BattleAmmo and add it to the player's battle rifle reserve ammo.
                {
                    BattleAmmo();
                    PlayerData.instance.currentReserveAmmo[3] += ammoValue;
                }
                else if (ammoType == '5') //If the ammoType is 5, then find the ammo value of AssualtAmmo and add it to the player's assualt ammo reserve ammo.
                {
                    AssualtAmmo();
                    PlayerData.instance.currentReserveAmmo[4] += ammoValue;
                }
                else if (ammoType == '6') //If the ammoType is 6, then find the ammo value of SniperAmmo and add it to the player's sniper rifle reserve ammo.
                {
                    SniperAmmo();
                    PlayerData.instance.currentReserveAmmo[5] += ammoValue;
                }
                else if (ammoType == '7') //If the ammoType is 7, then give the player maximum ammo for everything.
                {
                    PlayerData.instance.currentReserveAmmo[0] = PlayerData.instance.maxReserveAmmo[0];
                    PlayerData.instance.currentReserveAmmo[1] = PlayerData.instance.maxReserveAmmo[1];
                    PlayerData.instance.currentReserveAmmo[2] = PlayerData.instance.maxReserveAmmo[2];
                    PlayerData.instance.currentReserveAmmo[3] = PlayerData.instance.maxReserveAmmo[3];
                    PlayerData.instance.currentReserveAmmo[4] = PlayerData.instance.maxReserveAmmo[4];
                    PlayerData.instance.currentReserveAmmo[5] = PlayerData.instance.maxReserveAmmo[5];
                    PlayerData.instance.currentReserveAmmo[6] = PlayerData.instance.maxReserveAmmo[6];
                }

                Destroy(gameObject); //Destroys this game object.
                PlayerData.instance.AmmoPickup(); //Calls the public AmmoPickup method in the current PlayerData instance.
            }
        }
	}


    void BattleAmmo()
    {
        ammoValue = 21;
    }

    void AssualtAmmo()
    {
        ammoValue = 38;
    }

    void PistolAmmo()
    {
        ammoValue = 42;
    }

    void ShotgunAmmo()
    {
        ammoValue = 8;
    }

    void SniperAmmo()
    {
        ammoValue = 6;
    }

    void SMGAmmo()
    {
        ammoValue = 36;
    }

    void RevolverAmmo()
    {
        ammoValue = 21;
    }

}
