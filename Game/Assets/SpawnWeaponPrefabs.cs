//Project Landnite
//
//Created by Liam Hall on 22/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

public class SpawnWeaponPrefabs : MonoBehaviour {

    public GameObject gun2Prefab, gun3Prefab;

    GameObject gun2, gun3;

    bool gun2Spawned, gun3Spawned;

	// Update is called once per frame
	void Update ()
    {

        CheckForWeaponSlots(); //Calls the CheckForWeaponSlots method.

	}

    void CheckForWeaponSlots() //This method spawns in the extra weapons in the weapon holster when a second or third weapon is equipped.
    {

        if (EquipmentManager.instance.equippedEquipment[1] != null && !gun2Spawned) //If the weapon 2 prefab hasn't spawned yet but a second weapon is equipped, then...
        {

            gun2 = Instantiate(gun2Prefab); //The gun2 game object is then assigned a clone of the gun 2 prefab.

            gun2.transform.parent = GameObject.Find("Weapon Holster").GetComponent<Transform>(); //The gun2 game object is then moved so it is under the weapon holster in the hierarchy.

            gun2.name = "Gun 2"; //Renames the game object to Gun 2 so it can be easily found by other classes.

            gun2Spawned = true; //Sets the gun2Spawned boolean to true (notifies the program that this weapon has already been spawned so it doesn't keep looping).

            gun2.SetActive(true);

            //Time.timeScale = 1f; //Sets the time scale of the game to normal.
            //gun2.SetActive(true);
            //GunReworked gun = gun2.GetComponent<GunReworked>();
            //gun.Start();
            //gun2.SetActive(false);
            //Time.timeScale = 0f; //Sets the time scale of the game to freeze.

        }

        if (EquipmentManager.instance.equippedEquipment[2] != null && !gun3Spawned)
        {

            gun3 = Instantiate(gun3Prefab); //The gun3 game object is then assigned a clone of the gun 2 prefab.

            gun3.transform.parent = GameObject.Find("Weapon Holster").GetComponent<Transform>(); //The gun3 game object is then moved so it is under the weapon holster in the hierarchy.

            gun3.name = "Gun 3"; //Renames the game object to Gun 3 so it can be easily found by other classes.

            gun3Spawned = true; //Sets the gun3Spawned boolean to true (notifies the program that this weapon has already been spawned so it doesn't keep looping).

            gun3.SetActive(true);

            //Time.timeScale = 1f; //Sets the time scale of the game to normal.
            //gun3.SetActive(true);
            //GunReworked gun = gun2.GetComponent<GunReworked>();
            //gun.OnEnable();
            //gun3.SetActive(false);
            //Time.timeScale = 1f; //Sets the time scale of the game to freeze.

        }

    }

}
