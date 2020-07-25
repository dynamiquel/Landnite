//Project Landnite
//
//Created by Liam Hall on 14/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Gun", menuName = "Items/Equipment/Gun")]
public class GunData : Equipment {

    [Header("Statistics")]
    [Range(0, 10000)]
    [Tooltip("The damage of the weapon before level scaling.")]
    public int baseDamage; //A public float, which allows a base damage value to be inserted for the weapon.
    [Tooltip("What overall range of the weapon.")]
    public AnimationCurve range = new AnimationCurve(new Keyframe(0, 0.1f), new Keyframe(100, 1));
    [Range(0f, 100f)]
    [Tooltip("The max range of the weapon.")]
    public float maxRange;
    [Tooltip("Should the weapon be fired automatically?")]
    public bool fullAuto; //A public bool, which allows a true or false statement for the weapon being full auto or not.
    [Tooltip("The rate of fire of the weapon.")]
    public float rateOfFire; //A public float, which allows a rate of fire value to be inserted for the weapon.
    [Tooltip("The time it takes to reload the weapon.")]
    public float reloadTime; //A public float, which allows a reload time value to be inserted for the weapon.
    [HideInInspector]
    public bool isReloading; //A private bool, which states if the weapon is reloading or not.

    [Tooltip("The number of bullets the weapon can hold in a clip.")]
    public int maxMagAmmo; //A public int, which allows a maximum value for the weapon's ammunition in the mag.
    [Tooltip("The type of ammo the weapon will use. 0 = Pistol, 1 = SMG, 2 = Shotgun, 3 = Battle Rifle, 4 = Assault Rifle, 5 = Sniper Rifle.")]
    public char ammoType; //1 = marksman, 2 = assualt, 3 = pistol, 4 = shotgun, 5 = sniper, 6 = laser, 7 = revolver
    [Tooltip("Should the weapon have infinite ammo?")]
    public bool infiniteAmmo; //A public bool, which allows the weapon to have infinite ammo or not.

    public AudioSource shotSoundSource;
    public AudioSource reloadSoundSource;

}
