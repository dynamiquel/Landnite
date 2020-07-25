using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCache : MonoBehaviour
{

    public char ammoCacheTier;
    int[] ammoType = new int[4];
    int ammoCacheSizeI;
    int ammoValue;

    // Start is called before the first frame update
    void Start()
    {
        AmmoCacheSize(); //Calls the AmmoCacheSize method.
        RNG(); //Calls the RNG method.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AmmoCacheSize() //Sets the integer value of ammoCacheSize depending on the ammoCacheTier (the higher the tier, the more ammo slots the ammo cache will have).
    {
        if (ammoCacheTier == '1') //If the ammo cache is of tier 1, then...
        {
            ammoCacheSizeI = 1; //Sets the number of ammo drops this ammo cache will include to 1.
        }
        if (ammoCacheTier == '2') //If the ammo cache is of tier 2, then...
        {
            ammoCacheSizeI = 2; //Sets the number of ammo drops this ammo cache will include to 2.
        }
        if (ammoCacheTier == '3') //If the ammo cache is of tier 3, then...
        {
            ammoCacheSizeI = 4; //Sets the number of ammo drops this ammo cache will include to 4.
        }
    }

    void RNG() //This method will choose what ammo type would be included in this ammo cache and depending on the ammo cache tier, will be repeated.
    {
        if (ammoCacheSizeI >= 1) //If the ammo cache will contain at least 1 ammo drop, then...
        {
            ammoType[0] = Random.Range(0, 7); //Choose a random ammo type between 0 and 6 to be the first ammo drop.

            if (ammoCacheSizeI >= 2) //If the ammo cache will contain more than 1 ammo drop, then...
            {
                ammoType[1] = Random.Range(0, 7); //Choose a random ammo type between 0 and 6 to be the second ammo drop.

                if (ammoCacheSizeI >= 4) //If the ammo cache will contain more than 3 ammo drops, then...
                {
                    ammoType[2] = Random.Range(0, 7); //Choose a random ammo type between 0 and 6 to be the third ammo drop.
                    ammoType[3] = Random.Range(0, 7); //Choose a random ammo type between 0 and 6 to be the fourth ammo drop.
                }
            }
        }
        
        

    }

    public void OpenCache() //This public method will be called through the Interact script.
    {
        if(PlayerData.instance != null) //If there is an instance of PlayerData present, then...
        {

            for (int i = 0; i < ammoCacheSizeI; i++) //The program will find the ammo value of each ammo type by calling their partiuclar methods. The ammo value returned will be added to the player's correct currentReserveAmmo integer.
            {
                if (ammoType[i] == 1) //If the ammoType is 1, then find the ammo value of PistolAmmo and add it to the player's pistol reserve ammo.
                {
                    PistolAmmo();
                    PlayerData.instance.currentReserveAmmo[0] += ammoValue;
                }
                else if (ammoType[i] == 2) //If the ammoType is 2, then find the ammo value of SMGAmmo and add it to the player's SMG reserve ammo.
                {
                   SMGAmmo();
                   PlayerData.instance.currentReserveAmmo[1] += ammoValue;
                }
                else if (ammoType[i] == 3) //If the ammoType is 3, then find the ammo value of ShotgunAmmo and add it to the player's shotgun reserve ammo.
                {
                    ShotgunAmmo();
                    PlayerData.instance.currentReserveAmmo[2] += ammoValue;
                }
                else if (ammoType[i] == 4) //If the ammoType is 4, then find the ammo value of BattleAmmo and add it to the player's battle rifle reserve ammo.
                {
                    BattleAmmo();
                    PlayerData.instance.currentReserveAmmo[3] += ammoValue;
                }
                else if (ammoType[i] == 5) //If the ammoType is 5, then find the ammo value of AssualtAmmo and add it to the player's assualt ammo reserve ammo.
                {
                    AssualtAmmo();
                    PlayerData.instance.currentReserveAmmo[4] += ammoValue;
                }
                else if (ammoType[i] == 6) //If the ammoType is 6, then find the ammo value of SniperAmmo and add it to the player's sniper rifle reserve ammo.
                {
                    SniperAmmo();
                    PlayerData.instance.currentReserveAmmo[5] += ammoValue;
                }  
            }

            Destroy(gameObject); //Destroys the game object this script is attached to. 

            PlayerData.instance.AmmoPickup(); //Calls the AmmoPickup method in the PlayerData instance.
        }
    }

//The following methods include the ammo values of particular ammo types.
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
