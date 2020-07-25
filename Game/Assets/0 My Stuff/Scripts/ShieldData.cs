//Project Landnite
//
//Created by Liam Hall on 14/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Shield", menuName = "Items/Equipment/Shield")]
public class ShieldData : Equipment {


    [Header("Statistics")]
    [Tooltip("The capacity of the shield before level scaling.")]
    public int baseCapacity; //Creates a public int called 'baseCapacity'.
    [Tooltip("The recharge rate of the shield before level scaling.")]
    public int baseRechargeRate; //Creates a public int called 'baseRechargeRate'.
    [Tooltip("The time it takes for the shield to stimulate the shield for recharge.")]
    public float rechargeDelay; //Creates a public float called 'rechargeDelay'.

    [HideInInspector]
    public int capacity; //Creates a public int called 'capacity'.
    [HideInInspector]
    public int currentCapacity; //Creates a public int called 'currentCapacity'.

    [HideInInspector]
    public int rechargeRate; //Creates a public int called 'rechargeRate'.

}