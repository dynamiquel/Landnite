using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunReworked : MonoBehaviour
{
    [Header("Descriptions")]
    //[HideInInspector]
    public string name; //A public string, which allows a name for the weapon.
    [HideInInspector]
    public string description; //A public string, which allows a description for the weapon.
    [HideInInspector]
    public char rarity; //c = common, u = uncommon, r = rare, e = epic, h = heroic, l = legendary, m = mythic


    [Header("Statistics")]
    [Range(0, 101)]
    [HideInInspector]
    public int level; //A public int, which allows a level for the gun.
    [Range(0, 10000)]
    [HideInInspector]
    public int baseDamage; //A public float, which allows a base damage value to be inserted for the weapon.
    [HideInInspector]
    public AnimationCurve range = new AnimationCurve(new Keyframe(0, 0.1f), new Keyframe(100, 1));

    [Range(0f, 100f)]
    [HideInInspector]
    public float maxRange;

    [HideInInspector]
    public bool fullAuto; //A public bool, which allows a true or false statement for the weapon being full auto or not.
    [HideInInspector]
    public float rateOfFire; //A public float, which allows a rate of fire value to be inserted for the weapon.

    [HideInInspector]
    public float reloadTime; //A public float, which allows a reload time value to be inserted for the weapon.
    [HideInInspector]
    public bool isReloading; //A private bool, which states if the weapon is reloading or not.


    [HideInInspector]
    public int damage; //A public float used to store the damage value so it can be used within multiple methods and classes.
    //[HideInInspector]
    public int maxMagAmmo; //A public int, which allows a maximum value for the weapon's ammunition in the mag.

    [HideInInspector]
    public char ammoType; //1 = marksman, 2 = assualt, 3 = pistol, 4 = shotgun, 5 = sniper, 6 = laser, 7 = revolver

    int currentMagAmmo; //A private int, which states the current ammunition in the weapon's mag.
    int currentReserveAmmo;

    [HideInInspector]
    int lowAmmoNumber; //A private int, which states the value required for the gun to be "low on ammo".

    [HideInInspector]
    public bool infiniteAmmo; //A public bool, which allows the weapon to have infinite ammo or not.

    [Header("Value")]
    [HideInInspector]
    public int baseSellValue;
    [HideInInspector]
    public int sellValue;
    [HideInInspector]
    public int buyValue;


    [Header("Links - User Interface")]
    public TMP_Text currentMagAmmoUI; //Allows a GUI text element on the scene to have text set by using this script.
	public TMP_Text currentReserveAmmoUI; //Allows a GUI text element on the scene to have text set by using this script.
    public Animator crosshair;
	public Image reloadingImage; //A public image, which allows a GUI image element on the scene to be altered by using this script.


    [Header("Links - Audio Sources")]
    public AudioSource shotSoundSource;
    public AudioSource reloadSoundSource;
	public Camera fpsCam; //Allows a camera in the scene to be altered by this script.
	
    [Header("Links - Other Game Objects")]
    public GameObject[] muzzleFlash;
    public GameObject muzzleSpawn;
    private GameObject holdFlash;
    private GameObject holdSmoke;

    public int equipmentSlot;
    public GunData gunData;
    int i;
    bool reloadCancelled;

    public void Start() //Method executed when script is started.
    {
        OnEnable(); //Calls the OnEnable method.
    }
    
    public void OnEnable() //Method is called everytime the script component is re-enabled.
    {
        print("[GUN] Enabled"); //Prints the string in the console.
        if (currentMagAmmoUI == null) //If currentMagUI is empty (the script has not been enabled before), then...
        {
            print("[GUN] Weapon slot not setup"); //Outputs in the console that the weapon script has not been setup before.
            SetupReferences(); //Calls the SetupReferences method.
            SetupUI(); //Calls the SetupUI method.
        }
        
        if (gunData != null) //If the gunData scriptable object is present (the gun has already been setup), then...
        {
            print("[GUN] Weapon already exists");
            LowAmmo(); //Call the LowAmmo method.
        }
        
        if (gunData == null && currentMagAmmoUI != null) //If currentMagUI is not null and the gunData scriptable object is (the weapon slot has already been setup, but the gun has not), then...
        {
            print("[GUN] Weapon slot setup and no weapon assigned");
            RetrieveGunData(); //Call the RetrieveGunData method.
            SetupGun(); //Call the SetupGun method.
            FindAmmoType(); //Call the FindAmmoType method.
            LowAmmo(); //Call the LowAmmo method.
        }

    }

    void OnDisable() //This method is called when this script component is disabled.
    {
        print("[GUN] Disabled"); //Prints everything within the brackets in the console.
        CancelReload(); //Calls the CancelReload method.
    }

    void SetupReferences() //This method links up this script component with other game objects present in the scene. This allows things such as the weapon's current ammo and whether the weapon is reloading to be shown to the user.
    {
        print("[GUN] SetupReferences Executed"); //Outputs in the console that this method has just started.
        currentMagAmmoUI = GameObject.Find("Current Mag Counter Text").GetComponent<TextMeshProUGUI>(); //Finds the text label that will output the weapon's current magazine ammo to the user, and sets it to the currentMagUI attribute.
        currentReserveAmmoUI = GameObject.Find("Current Reserve Counter Text").GetComponent<TextMeshProUGUI>(); //Finds the text label that will output the weapon's reserve ammo to the user, and sets it to the reserveMagUI attribute.
        reloadingImage = GameObject.Find("Reloading Image").GetComponent<Image>(); //Finds the reloading image on the scene and assigns it to the reloadingImage Image attribute.
        crosshair = GameObject.Find("Crosshair").GetComponent<Animator>();
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        print("[GUN] SetupReferences Finished"); //Outputs in the console that this method has succesfully been executed.
    }

    void SetupUI() //This method sets all of the game objects in the scene that have been assigned an attribute to a null state. This is done to ensure the previously equipped weapon's attributes does not conflict with the newly assigned weapon.
    {
        print("[GUN] SetupUI Executed");
        reloadingImage.enabled = false; //Hide the reloadingImage so the user knows they are not reloading.
        currentMagAmmoUI.text = ""; //Sets the text within the currentMagAmmoUI label to nill;
        currentReserveAmmoUI.text = "";  //Sets the text within the currentMagAmmoUI label to nill;
        print("[GUN] SetupUI Finished");
    }

    void RetrieveGunData() //This method accesses the player's equipment manager, finds the weapon they currently have equipped in this script's particular weapon slot, saves it into an attributed called gunData and continues with the script.
    {
        print("[GUN] RetrieveGunData Executed");
        gunData = (GunData)EquipmentManager.instance.equippedEquipment[equipmentSlot]; //Sets the gunData attribute to the GunData scriptable object located in player's according weapon slot in the EquipmentManager instance.

        if (gunData != null) //If the gunData attribute is not null (a gun is found in the weapon slot), then...
        {
            ApplyGunData(); //Calls the ApplyGunData method.
        }
        print("[GUN] RetrieveGunData Finished");
    }

    void ApplyGunData() //This method gets all the public variable data from the scriptable object stored in gunData, and assigns it to the equivelantly named public variables in this class so they can be accessed by other methods.
    {
        print("[GUN] ApplyGunData Executed");
        name = gunData.name;
        description = gunData.description;
        rarity = gunData.rarity;

        level = gunData.level;
        baseDamage = gunData.baseDamage;
        maxRange = gunData.maxRange;
        fullAuto = gunData.fullAuto;
        rateOfFire = gunData.rateOfFire;

        baseSellValue = gunData.baseSellValue;
        reloadTime = gunData.reloadTime;
        maxMagAmmo = gunData.maxMagAmmo;
        ammoType = gunData.ammoType;
        i = (int)char.GetNumericValue(ammoType) - 1; //As the ammoType variable within the gunData script is of a char data type that is presented with whole numbers, it is converted to an integer.
        print("[GUN] ApplyGunData Finished");
    }

    void SetupGun() //This method determines the damage, sell value and buy value of the weapon, and finds the mag size of the weapon. It is also calculates what the low ammo number of the weapon should be by finding 20% of the mag size.
    {
        print("[GUN] SetupGun Executed");
        damage = Mathf.RoundToInt((float)(baseDamage * Mathf.Pow(1.1301f, level))); //Calculates the damage of the weapon so it increases damage when the weapon level is increased.
        sellValue = Mathf.RoundToInt((float)(baseSellValue * Mathf.Pow(1.1301f, level))); //Gets the integer stored within 'baseSellValue', multiplies it by 1.1301 to the power of the integer stored within 'level', then gets the value stored in 'level', multiplies it by 3 and takes it away from the previous answer. It then makes sellValue equal to the previous answer. 
        buyValue = sellValue * 2; //Multiplies the integer stored within 'sellValue' by 2 and stores it within 'buyValue'.
        
        currentMagAmmo = maxMagAmmo; //Sets the currentMagAmmo to the maxMagAmmo when the game starts.
        lowAmmoNumber = Mathf.RoundToInt((float)(maxMagAmmo * 0.2)); //Calculates the lowAmmoNumber (value when the weapon is considered to be low on ammo) by getting 20% of the maxMagAmmo (ammo that can be accepted in a mag) and rounding it up to an intger as you can't have a percentage of a bullet.

        print("[GUN] Ammo in mag: " + currentMagAmmo); //Outputs the current ammo in the mag in the console.
        print("[GUN] Ammo in reserves: " + PlayerData.instance.currentReserveAmmo[i]); //Outputs the current ammo in reserves in the console.
        print("[GUN] SetupGun Finished");
    }

    public void FindAmmoType() //This method checks if the current reserve ammo located in the PlayerData instance is greater than the max reserve ammo, and if it is, decreases the current reserve ammo back down to the max reserve ammo. (Makes sure the player does not hold more ammo than they should)
    {
        print("[GUN] FindAmmoType Executed");
        
        if (PlayerData.instance.currentReserveAmmo[i] > PlayerData.instance.maxReserveAmmo[i]) //If the currentReserveAmmo integer located in the PlayerData instance is greater than the maxReserveAmmo, then...
        {
            PlayerData.instance.currentReserveAmmo[i] = PlayerData.instance.maxReserveAmmo[i]; //Sets the currentReserveAmmo integer equal to the integer stored in maxReserveAmmo.
        }
        
        print("[GUN] FindAmmoType Finished");
    }

    void CancelReload() //This method cancels the reload of the weapon.
    {
        print("[GUN] CancelReload Executed");
        if (isReloading) //If the isReloading bool is true (if the weapon is currently reloading), then...
        {
            isReloading = false; //Sets the isReloading bool to false (tells the class the weapon is no longer reloading).
            reloadingImage.enabled = false; //Disables the reloadingImage image (hides the image that notifies the user the weapon is currently reloading).
            reloadCancelled = true; //Sets the reloadCancelled bool to true (tells the class that the weapon just cancelled their reload).
        }
        print("[GUN] CancelReload Finished");
    }

    void OnGUI() //This method is called every frame and is used to update certain UI elements.
    {
        print("[GUN] OnGUI Executed");
        if (infiniteAmmo == false)
        {
            currentMagAmmoUI.text = currentMagAmmo.ToString(); //Converts the currentMagAmmo integer as a string and sets it in the currentMagAmmoUI label (displays the current ammo in the weapons mag on the GUI).
            currentReserveAmmoUI.text = PlayerData.instance.currentReserveAmmo[i].ToString(); //Converts the currentReserveAmmo integer as a string and sets it in the currentReserveAmmoUI label (displays the current ammo on the player on the GUI).
        }
        else
        {
            currentMagAmmoUI.text = currentMagAmmo.ToString(); //Converts the currentMagAmmo integer as a string and sets it in the currentMagAmmoUI label (displays the current ammo in the weapons mag on the GUI).
            currentReserveAmmoUI.text = "∞"; //Sets the currentReserveAmmo label as an infinity symbol.
        }
        print("[GUN] OnGUI Finished");
    }
    
    void LowAmmo() //This method is used to change the colour of the ammo text labels depending on how much ammo is remaining in the weapon and in the player's reserves.
    {
        print("[GUN] LowAmmo Executed");
        //This if statement changes the colour of text used in the currentMagAmmoUI label to a yellow colour when the weapon is low on ammo.
		if (currentMagAmmo <= lowAmmoNumber && PlayerData.instance.currentReserveAmmo[i] > 0) //If currentMagAmmo is equal or smaller than lowAmmo number; larger than 0 (the weapon is low on ammo), then...
		{
            currentMagAmmoUI.enabled = true; //Shows the currentMagAmmoUI label (the ammo in the mag).
			currentMagAmmoUI.color = new Color32(255, 232, 35, 255); //Changes the colour of the currentMagAmmoUI label to a yellow colour.
		}
        //This if statement changes the colour of the text used in the currentReserveAmmoUI label to a red colour when the weapon is out of ammo and hides the currentMagAmmoUI label.
        if (currentMagAmmo <= 0 && PlayerData.instance.currentReserveAmmo[i] <= 0) //If currentMagAmmo and currentReserveAmmo are equal to 0 (the weapon has no ammo and the player has no ammo in reserves), then...
        {
            currentMagAmmoUI.enabled = false; //Hides the currentMagAmmoUI label (the ammo in the mag).
		    currentReserveAmmoUI.color = new Color32(243, 67, 54, 255); //Changes the colour of the currentReserveAmmoUI label to a red colour.
        }
		//This if statement changes the colour of text used in the currentMagAmmoUI label to a white colour when the weapon isn't low on ammo.
		if (currentMagAmmo > 0 || PlayerData.instance.currentReserveAmmo[i] > 0) //If currentMagAmmo is more than 0 (the weapon has ammo), then...
		{
            currentMagAmmoUI.enabled = true; //Shows the currentMagAmmoUI label (the ammo in the mag).
            currentReserveAmmoUI.color = new Color32(255, 255, 255, 255);
            
            //If currentMagAmmo is more than lowAmmoNumber (the weapon isn't low on ammo), then...
            if (currentMagAmmo > lowAmmoNumber)
            {
			    currentMagAmmoUI.color = new Color32(255, 255, 255, 255); //Changes the colour of the currentMagAmmoUI label to a white colour.
            }
		}

        print("[GUN] LowAmmo Finished");
    }

    void Update() //This method is called once every frame
    {
        if (isReloading) //If the isReloading bool is true (the weapon is currently reloading), then...
        {
            return; //Do not execute the code after this if statement (do not let the weapon fire or reload again).
        }

        CheckForFireInput(); //Call the CheckForFireInput method.
        CheckForReload(); //Call the CheckForReload method.
    }

    void CheckForFireInput() //This method listens to the user's inputs and depending on the input used, calls another method. For example, if a player presses R, the Reload method is called.
    {
        if (Input.GetButtonDown("Fire") && currentMagAmmo > 0) //If the user shoots the weapon by clicking left mouse and the weapon has more than one bullet, then...
		{
			Shoot(); //Starts the shoot method.
        }
        else if (Input.GetButtonDown("Fire") && currentMagAmmo <= 0 && PlayerData.instance.currentReserveAmmo[i] > 0) //If the user presses the left mouse button; the weapon has no ammo; the player has ammo they can put in the weapon, then...
        {
            StartCoroutine(Reload()); //Starts the reload method.
        }
    }

    void Shoot() //The basic principle for this method is to shoot a bullet from the weapon/
    {
        print("[GUN] Shoot Executed");

        //Muzzle flash
        shotSoundSource.Play(); //Plays the audio clip sourced within the shotSoundSource audio source game object (plays a sound of the gun being shot).
        crosshair.SetTrigger("Shoot"); //Changes the state of the crosshair to Shoot.

        if (!infiniteAmmo) //If the infiniteAmmo bool is false (the weapon does not have infinite ammo), then...
        {
            currentMagAmmo--; //Decrement the currentMagAmmo integer by one (take one bullet away from the weapon's magazine).
        }
        
        RaycastHit hit; //Creates a RaycastHit attribute called hit.

		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, maxRange)) //Fires the raycast from the weapon's position up to the distance stored in the weapon's maxRange, and gets the transform of the game object it hits.
		{
			Debug.Log(hit.transform.name); //Prints out the name of the game object the raycast hit.
			if (hit.transform.tag == "Target") //If the transform did have a Target script located within it, then...
			{
                hit.transform.GetComponent<Target>().isHit = true; //Accesses the Target script and sets the public isHit bool located in it to true.
			}
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<Enemy>().DetectHit(damage);
            }
		}

        LowAmmo();
        print("[GUN] Shoot Finished");
    }

    void CheckForReload() //Checks whether the weapon should be reloaded by the use of certain criteria.
    {
        if ((currentMagAmmo <= 0 && PlayerData.instance.currentReserveAmmo[i] > 0 && !reloadCancelled) || (Input.GetButtonDown("Reload") && (currentMagAmmo < maxMagAmmo) && PlayerData.instance.currentReserveAmmo[i] > 0)) //If there is no ammo in the weapon; the player ammo they can reload into the weapon; the weapon was not previously reloaded, then...  OR, the user pressed the reload button; the weapon's magazine is not full; the player has ammo they can put into the weapon, then...
        {
            StartCoroutine(Reload()); //Starts the Reload method.
        }
    }

    IEnumerator Reload() //This method reloads the weapon's magazine.
    {
        print("[GUN] Reload Executed");
        isReloading = true; //Sets the isReloading boolean to true.
        reloadingImage.enabled = true; //Displays the reloadingImage, so the user knows they are reloading.
        reloadSoundSource.Stop(); //Stops the reloadSoundSource audio source (stops the previous reload from corrupting the audio of the current reload).
        reloadSoundSource.Play(); //Plays the audio clip sourced within the reloadSoundSource (plays the reload sound).

		yield return new WaitForSeconds(reloadTime); //Waits for the number of seconds set in reloadTime before executing the next line of code. This allows a time period between the reload of the weapon so the user can't instantly start shooting again.         

        PlayerData.instance.currentReserveAmmo[i] += currentMagAmmo; //Sets currentReserveAmmo as currentReserveAmmo + currentMagAmmo (puts all the ammo together).

		//This if statement makes it so if the player has more ammo the weapon can take, then it will set the weapon's ammo to full and subtract it from the player's reserve ammo.
        if (PlayerData.instance.currentReserveAmmo[i] > maxMagAmmo) //If the currentReserveAmmo is higher than the maxMagAmmo (there's ammo to spare after the mag has been filled), then...
		{
			currentMagAmmo = maxMagAmmo; //Sets the currentMagAmmo to the maxMagammo (fully fills the mag).
            PlayerData.instance.currentReserveAmmo[i] -= maxMagAmmo; //Sets currentReserveAmmo to currentReserveAmmo - maxMagAmmo (moves an entire mag worth of ammo from reserves).
		}

		//This else statment makes it so if the player has less ammo than it takes to fully fill a mag, then it will put the remaining ammo in the mag and remove all ammo from reserves.
		else //Else...
		{
            currentMagAmmo = PlayerData.instance.currentReserveAmmo[i]; //Sets the ammo in the mag by how much ammo was left in reserves.
            PlayerData.instance.currentReserveAmmo[i] = 0; //Sets the current ammo in reserves as 0.
		}

        reloadCancelled = false; //Sets the reloadCancelled bool to false (tells the program the next time the weapon is out of ammo, it can be automatically reloaded).

		print("[GUN] Ammo in mag: " + currentMagAmmo); //Outputs the current ammo in the mag.
        print("[GUN] Ammo in reserves: " + PlayerData.instance.currentReserveAmmo[i]); //Outputs the current ammo in reserves.

		reloadingImage.enabled = false; //Hides the reloadingImage so the player knows they are not reloading.
		isReloading = false; //Sets the isReloading boolean to false.

        LowAmmo(); //Calls the LowAmmo method.

        print("[GUN] Reload Finished");
    }

}
