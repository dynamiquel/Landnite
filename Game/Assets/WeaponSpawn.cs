using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    private void Update()
    {
        GameObject gun = PlayerData.instance.gameObject.GetComponentInChildren<GunReworked>().gameObject;
        GunReworked gunn = gun.GetComponent<GunReworked>();
        
        if (!gunn.enabled)
        {
            gunn.enabled = true;
            gun.SetActive(true);
        }        
    }
}
