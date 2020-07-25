//Project Landnite
//
//Created by Liam Hall on 16/4/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
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
    [HideInInspector]
    public int maxMagAmmo; //A public int, which allows a maximum value for the weapon's ammunition in the mag.

    [HideInInspector]
    public char ammoType; //1 = marksman, 2 = assualt, 3 = pistol, 4 = shotgun, 5 = sniper, 6 = laser, 7 = revolver

    [HideInInspector]
    int currentMagAmmo; //A private int, which states the current ammunition in the weapon's mag.
    [HideInInspector]
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

    public ParticleSystem muzzleFlashL; //Allows a particle system in the scene to be altered by this script.

    public GameObject[] muzzleFlash;
    public GameObject muzzleSpawn;
    private GameObject holdFlash;
    private GameObject holdSmoke;

    public int equipmentSlot;

    public GunData gunData;

    // Use this for initialization
    private void Start()
	{

        SettingUpReferences();

        GettingGunData();

	}

    void SettingUpReferences()
    {

        currentMagAmmoUI = GameObject.Find("Current Mag Counter Text").GetComponent<TextMeshProUGUI>();
        currentReserveAmmoUI = GameObject.Find("Current Reserve Counter Text").GetComponent<TextMeshProUGUI>();
        reloadingImage = GameObject.Find("Reloading Image").GetComponent<Image>();

        crosshair = GameObject.Find("Crosshair").GetComponent<Animator>();

    }
    

    public void GettingGunData()
    {

        Debug.LogWarning("AAAAAAAAAAAAAAAAAA // Before getting gun data");

        gunData = (GunData)EquipmentManager.instance.equippedEquipment[equipmentSlot];

        Debug.LogWarning("AAAAAAAAAAAAAAAAAA // After getting gun data");

        ApplyingGunData();

    }

    void ApplyingGunData()
    {

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

        baseSellValue = gunData.baseSellValue;

        CalculatingVariables();

    }

    void CalculatingVariables()
    {

        damage = Mathf.RoundToInt((float)(baseDamage * Mathf.Pow(1.1301f, level))); //Calculates the damage of the weapon so it increases damage when the weapon level is increased.

        sellValue = Mathf.RoundToInt((float)(baseSellValue * Mathf.Pow(1.1301f, level))); //Gets the integer stored within 'baseSellValue', multiplies it by 1.1301 to the power of the integer stored within 'level', then gets the value stored in 'level', multiplies it by 3 and takes it away from the previous answer. It then makes sellValue equal to the previous answer. 
        buyValue = sellValue * 2; //Multiplies the integer stored within 'sellValue' by 2 and stores it within 'buyValue'.

        ExtraSetup();

    }

    void ExtraSetup()
    {

        FindingAmmoType();

        currentMagAmmo = maxMagAmmo; //Sets the currentMagAmmo to the maxMagAmmo when the game starts.

        reloadingImage.enabled = false; //Hide the reloadingImage so the user knows they are not reloading.
        currentMagAmmoUI.text = ""; //Sets the text within the currentMagAmmoUI label to nill;
        currentReserveAmmoUI.text = "";  //Sets the text within the currentMagAmmoUI label to nill;

        lowAmmoNumber = Mathf.RoundToInt((float)(maxMagAmmo * 0.2)); //Calculates the lowAmmoNumber (value when the weapon is considered to be low on ammo) by getting 20% of the maxMagAmmo (ammo that can be accepted in a mag) and rounding it up to an intger as you can't have a percentage of a bullet.

        print("Low ammo number: " + lowAmmoNumber); //Outputs the low ammo number of the weapon in the console.

        print("Ammo in mag: " + currentMagAmmo); //Outputs the current ammo in the mag in the console.
        print("Ammo in reserves: " + currentReserveAmmo); //Outputs the current ammo in reserves in the console.

    }

    void OnDisable()
    {

        CancelReload();

    }

    private void OnEnable()
    {
        if (currentMagAmmoUI == null)
        {
            SettingUpReferences();
        }

        if (gunData == null)
            GettingGunData();

        NoAmmo();
        LowAmmo();

    }


    public void FindingAmmoType()
    {

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        PlayerData playerData = player.GetComponent<PlayerData>(); //Finds the script called "PlayerData" so it can access its variables.


        //Compares the ammo type of the weapon and uses the according ammo type from the player's ammunitions.
        if (ammoType == '1')
        {
            currentReserveAmmo = playerData.currentReserveAmmo[0];
        }
        else if (ammoType == '2')
        {
            currentReserveAmmo = playerData.currentReserveAmmo[1];
        }
        else if (ammoType == '3')
        {
            currentReserveAmmo = playerData.currentReserveAmmo[2];
        }
        else if (ammoType == '4')
        {
            currentReserveAmmo = playerData.currentReserveAmmo[3];
        }
        else if (ammoType == '5')
        {
            currentReserveAmmo = playerData.currentReserveAmmo[4];
        }
        else if (ammoType == '6')
        {
            currentReserveAmmo = playerData.currentReserveAmmo[5];
        }
        else if (ammoType == '7')
        {
            currentReserveAmmo = playerData.currentReserveAmmo[6];
        }

    }


        public void UpdatingAmmo()
    {

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        PlayerData playerData = player.GetComponent<PlayerData>(); //Finds the script called "PlayerData" so it can access its variables.


        //Compares the ammo type of the weapon refreshes the according ammunition from the player's ammunitions.
        if (ammoType == '1')
        {
            playerData.currentReserveAmmo[0] = currentReserveAmmo;
        }
        else if (ammoType == '2')
        {
            playerData.currentReserveAmmo[1] = currentReserveAmmo;
        }
        else if (ammoType == '3')
        {
            playerData.currentReserveAmmo[2] = currentReserveAmmo;
        }
        else if (ammoType == '4')
        {
            playerData.currentReserveAmmo[3] = currentReserveAmmo;
        }
            else if (ammoType == '5')
        {
            playerData.currentReserveAmmo[4] = currentReserveAmmo;
        }
            else if (ammoType == '6')
        {
            playerData.currentReserveAmmo[5] = currentReserveAmmo;
        }
            else if (ammoType == '7')
        {
            playerData.currentReserveAmmo[6] = currentReserveAmmo;
        }

    }



	// Update is called once per frame
	public void Update()
	{
        
		//This if statement makes it so the program won't loop the reload sequence if they have 0 ammo in the mag.
		if (isReloading == true) //If the player is reloading, then...
		{

			return; //Stops.

		}

		//This if statement makes it so when the weapon is out of ammo, or the user has clicked the R key, it will start the Reload method (weapon will reload).
		if (currentMagAmmo <= 0 || Input.GetKeyDown(KeyCode.R)) //If the weapon is out of ammo in the mag or the user has clicked R (reload key), then...
		{

			StartCoroutine(Reload()); //Starts the Reload method.
			return;

		}

        if (Input.GetButtonDown("Fire")) //If the user shoots the weapon by clicking left mouse, then...
		{

			Shoot(); //Starts the shoot method.
			print("Damage: " + damage); //Outputs the damage the weapon inflicted in the console.

		}

		LowAmmo(); //Starts the LowAmmo method.

		NoAmmo(); //Starts the NoAmmo method.


		//When F7 is pressed, then toggle the infiniteAmmo bool
        if (Input.GetButtonDown("Reload")) //If the user has clicked F7, then...
		{

			if (infiniteAmmo == true) //If the infiniteAmmo bool is true (the weapon already has infinite ammo), then...
			{

				infiniteAmmo = false; //Set infiniteAmmo bool to false (turn infnite ammo off for the weapon), then...

			}

			else //Else, if the infiniteAmmo bool is false (the weapon doesn't have infinite ammo), then...
			{

				infiniteAmmo = true; //Set infiniteAmmo bool to true (turn infnite ammo on for the weapon), then...

			}

		}

	}

	IEnumerator Reload()
	{

        
		//If ammo in the mag was partially filled, and there is less ammo in reserves than it takes to fill an empty mag, the mag will fill as much as it can, and if there is extra bullets, it would go into reserves.
        if (currentMagAmmo < maxMagAmmo && currentReserveAmmo > 0)
		{

			isReloading = true; //Sets the isReloading boolean to true.

			print("Reloading..."); //Outputs in the console, the player is currently reloading.

			reloadingImage.enabled = true; //Displays the reloadingImage, so the user knows they are reloading.

            reloadSoundSource.Play();


			yield return new WaitForSeconds(reloadTime); //Waits for the number of seconds set in reloadTime before executing the next line of code. This allows a time period between the reload of the weapon so the user can't instantly start shooting again.         

            currentReserveAmmo += currentMagAmmo; //Sets currentReserveAmmo as currentReserveAmmo + currentMagAmmo (puts all the ammo together).


			//This if statement makes it so if the player has more ammo the weapon can take, then it will set the weapon's ammo to full and subtract it from the player's reserve ammo.
            if (currentReserveAmmo > maxMagAmmo) //If the currentReserveAmmo is higher than the maxMagAmmo (there's ammo to spare after the mag has been filled), then...
			{

				currentMagAmmo = maxMagAmmo; //Sets the currentMagAmmo to the maxMagammo (fully fills the mag).
                currentReserveAmmo -= maxMagAmmo; //Sets currentReserveAmmo to currentReserveAmmo - maxMagAmmo (moves an entire mag worth of ammo from reserves).

			}

			//This else statment makes it so if the player has less ammo than it takes to fully fill a mag, then it will put the remaining ammo in the mag and remove all ammo from reserves.
			else //Else...
			{

                currentMagAmmo = currentReserveAmmo; //Sets the ammo in the mag by how much ammo was left in reserves.
                currentReserveAmmo = 0; //Sets the current ammo in reserves as 0.

			}

			print("Ammo in mag: " + currentMagAmmo); //Outputs the current ammo in the mag.

            print("Ammo in reserves: " + currentReserveAmmo); //Outputs the current ammo in reserves.

			reloadingImage.enabled = false; //Hides the reloadingImage so the player knows they are not reloading.

			isReloading = false; //Sets the isReloading boolean to false.

            UpdatingAmmo();

		}

	}

	void Shoot()
	{
        
		//muzzleFlashL.Play(); //The muzzleFlash particle system will play once.

        int randomNumberForMuzzleFlash = Random.Range(0, 5);

        holdFlash = Instantiate(muzzleFlash[randomNumberForMuzzleFlash], muzzleSpawn.transform.position /*- muzzelPosition*/, muzzleSpawn.transform.rotation * Quaternion.Euler(0, 0, 90)) as GameObject;
        holdFlash.transform.parent = muzzleSpawn.transform;


        shotSoundSource.Play();

        crosshair.SetTrigger("Shoot");

		if (infiniteAmmo == false) //If the infiniteAmmo is false (the weapon doesn't have infinite ammo), then...
		{

			currentMagAmmo--; //Subtract one ammo from the mag.

		}

		print("Shot fired."); //Outputs the weapon has shot in the console.

		RaycastHit hit;

		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, maxRange))
		{

			Debug.Log(hit.transform.name);

			Target target = hit.transform.GetComponent<Target>();
			if (target != null)
			{

				target.isHit = true;

			}
		}
	}

	void OnGUI()
	{

		//This if statement displays the ammo currently in the weapon's mag and the player's reserves on the GUI.
		if (infiniteAmmo == false) //If the infiniteAmmo bool is false (the weapon doesn't have infinite ammo), then...
		{

			currentMagAmmoUI.text = currentMagAmmo.ToString(); //Converts the currentMagAmmo integer as a string and sets it in the currentMagAmmoUI label (displays the current ammo in the weapons mag on the GUI).
            currentReserveAmmoUI.text = currentReserveAmmo.ToString(); //Converts the currentReserveAmmo integer as a string and sets it in the currentReserveAmmoUI label (displays the current ammo on the player on the GUI).

		}


		//This if statement displays the ammo currently in the weapon's mag and the infinity symbol on the GUI.
		if (infiniteAmmo == true) //If the infiniteAmmo bool is true (the weapon does have infinite ammo), then...
		{

			currentMagAmmoUI.text = maxMagAmmo.ToString(); //Converts the currentMagAmmo integer as a string and sets it in the currentMagAmmoUI label (displays the current ammo in the weapons mag on the GUI).
			currentReserveAmmoUI.text = "∞"; //Sets the currentReserveAmmo label as an infinity symbol.

		}


	}

	void LowAmmo()
	{

		//This if statement changes the colour of text used in the currentMagAmmoUI label to a yellow colour when the weapon is low on ammo.
		if (currentMagAmmo <= lowAmmoNumber && currentReserveAmmo > 0) //If currentMagAmmo is equal or smaller than lowAmmo number; larger than 0 (the weapon is low on ammo), then...
		{

			currentMagAmmoUI.color = new Color32(255, 232, 35, 255); //Changes the colour of the currentMagAmmoUI label to a yellow colour.

		}

		//This else if statement changes the colour of text used in the currentMagAmmoUI label to a white colour when the weapon isn't low on ammo.
		else if (currentMagAmmo > lowAmmoNumber) //If currentMagAmmo is more than lowAmmoNumber (the weapon isn't low on ammo), then...
		{

			currentMagAmmoUI.color = new Color32(255, 255, 255, 255); //Changes the colour of the currentMagAmmoUI label to a white colour.

		}

	}

    void NoAmmo()
	{

    //This is statement changes the colour of the text used in the currentReserveAmmoUI label to a red colour when the weapon is out of ammo and hides the currentMagAmmoUI label.
        if (currentMagAmmo <= 0 && currentReserveAmmo <= 0) //If currentMagAmmo and currentReserveAmmo are equal to 0 (the weapon has no ammo and the player has no ammo in reserves), then...
        {

		currentReserveAmmoUI.color = new Color32(243, 67, 54, 255); //Changes the colour of the currentReserveAmmoUI label to a red colour.

		currentMagAmmoUI.enabled = false; //Hides the currentMagAmmoUI label (the ammo in the mag).

        }

    //This else if statement displays the currentMagAmmoUI label once the mag currently has ammo.
		else if (currentMagAmmo > 0) //If there's ammo in the mag again, then...
		{

		currentMagAmmoUI.enabled = true; //Shows the currentMagAmmoUI label (the ammo in the mag).

            currentReserveAmmoUI.color = new Color32(255, 255, 255, 255);

		}

	}

    void CancelReload()
    {

        isReloading = false;
        reloadingImage.enabled = false;

    }

}