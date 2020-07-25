using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float distance = 24f;

    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {
        //fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
     void Update()
    {
        RaycastHit hit; //Creates a new raycast called hit.

		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, distance)) //A raycast is fired upto the range defined in the distance attribute. If a game object is hit (if the user is looking at a game object that is not further away than the defined distance) then...
        {
            if (hit.transform.tag == "MoneyCache") //If the tag of the gameobject is MoneyCache (the object is a money cache), then...
            {
                if (Input.GetKeyDown(KeyCode.E)) //If the user presses E, then...
                {
                    MoneyCache moneyCache = hit.transform.GetComponent<MoneyCache>(); //Accesses the MoneyCache script located within the object and tempoaraily saves it as an attribute so its methods can be accessed.
                    moneyCache.OpenCache(); //Calls the OpenCache method within the MoneyCache script.
                }
            }

            if (hit.transform.tag == "AmmoCache") //If the tag of the gameobject is AmmoCache (the object is an ammo cache), then...
            {
                if (Input.GetKeyDown(KeyCode.E)) //If the user presses E, then...
                {
                    AmmoCache ammoCache = hit.transform.GetComponent<AmmoCache>(); //Accesses the AmmoCache script located within the object and temporaily saves it as an attribute so its methods can be accessed.
                    ammoCache.OpenCache(); //Calls the OpenCache method within the AmmoCache script.
                }
            }
        }
    }
}
