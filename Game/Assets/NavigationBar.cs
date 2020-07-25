using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBar : MonoBehaviour
{
    GameObject inventoryLink;
    //GameObject mapLink;
    char currentState = '0'; //1 = inventory, 2 = missions, 3 = map
    int keyState = 1;

    void Start()
    {
        inventoryLink = GameObject.Find("Inventory");
        Inventory();
    }

    void Update()
    {
        //KeySwitch();
    }

    public void Inventory()
    {
        if (currentState != '1')
        {
            //mapLink.SetActive(false);
            inventoryLink.SetActive(true);
            currentState = '1';
            keyState = 1;
        }
    }

    public void Map()
    {
        if (currentState != '2')
        {
            inventoryLink.SetActive(false);
            //mapLink.SetActive(true);
            currentState = '2';
            keyState = 2;
        }
    }

    void KeySwitch()
    {
        bool switchDone = true;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyState--;
            switchDone = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            keyState++;
            switchDone = false;
        }

        if (keyState > 2)
        {
            keyState = 1;
        }
        if (keyState < 1)
        {
            keyState = 2;
        }

        if (!switchDone)
        {
            if (keyState == 1)
            {
                Inventory();
            }
            else if (keyState == 2)
            {
                Map();
            }
            else
            {
                return;
            }
            switchDone =  true;
        }
    }
}
