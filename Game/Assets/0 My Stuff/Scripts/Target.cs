//Project Landnite
//
//Created by Liam Hall on 12/8/18.
//Copyright © 2018 Liam Hall. All rights reserved.
//

//Namespaces used by this C# class.
using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour, IEnemy {

    public bool isHit; //Creates a public boolean called isHit. Booleans can only store two values, true and false. A public variable can be edited in the inspector and be accessed by other classes.

    public int id { get; set; }

    bool isDown, isCooldown; //Creates two booleans.

    float speed = 14f; //Creates a float variable called 'speed' and sets its value.

    public float cooldown = 3f; //Creates a public float variable called 'cooldown' and sets its value.

    public bool isDamagable = true;

    bool isGoingDown;

    public int expValue = 10;

    Quaternion downRotation, upRotation; //Creates two quanternions, one called downRotation and the other upRotation. These variables will store angles.


    void Start() //This method is called when the class starts.
    {
        id = 1;
        
        downRotation = Quaternion.Euler(87, transform.eulerAngles.y, transform.eulerAngles.z); //Sets the value of the downRotation to the rotation the target should have when it is down.
                    
        upRotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z); //Sets the value of the upRotation to the rotation the target should have when it is erected.

    }

    // Update is called once per frame
    void Update () 
    {

        DetectHit(); //Cals the DetectHit method.

        if (isDown) //If the isDown boolean is true (the target is down), then...
        {

            if (isCooldown) //If the isCooldown boolean is true (hasn't passed its cooldown stage after being down), then...
            {

                StartCoroutine(DownCoolDown()); //Start the coroutine method DownCoolDown.

            }

            if (!isCooldown) //If the isCooldown boolean is false (has passed its cooldown stage after being down), then...
            {

                Erect(); //Calls the Erect method.

            }
        }

	}

    void DetectHit() //This method detects if the target has been hit, and if it is and it is erected, then it will call the GoDown method.
    {
        if (isDamagable)
        {

            if (isHit && !isDown) //If the isHit boolean is true (if the target has been hit), and the isDown boolean is false (is erected), then...
            {

                GoDown(); //Calls the GoDown method.

            }

        }

    }

    void GoDown() //This method sets the rotation of the game object to the rotation stored in the downRotation quaternion overtime. Once the x rotation has reached 85 degrees, then it starts the cooldown.
    {
       
        transform.rotation = Quaternion.Slerp(transform.rotation, downRotation, Time.deltaTime * speed); //Gradually sets the transform rotation to the rotation in downRotation overtime depending on the float stored in speed. (Adds realism to the target going down, instead of simply switching to a different rotation).

        if (transform.eulerAngles.x >= 85) //If the x rotation of the transform (target) is more or equal to 85 degress, then...
        {

            AddingEXP(); //Starts the AddingEXP method.

            isCooldown = true; //Sets the isCooldown boolean to true.
            isDown = true; //Sets the isDown boolean to true.
            Die();

        }

    }

    public void Die()
    {
        CombatEvents.EnemyKilled(this);
    }
    public void TakeDamage(float i)
    {

    }
    public void PerformAttack()
    {

    }

    IEnumerator DownCoolDown() //This method starts the cooldown before the target is erected.
    {
            
        yield return new WaitForSeconds(cooldown); //Pauses the method for the number of seconds in the cooldown float.

        //After the cooldown has finished.
        isCooldown = false; //Sets the isCooldown boolean to false.
        isHit = false; //Sets the isHit boolean to false.

    }

    void Erect() //This method changes the rotation of the target to the rotation stored in the upRotation quaternion. (Back to the default erect stage of the target).
    {
        
        StopAllCoroutines(); //Stops all coroutines, this helps to stop the DownCoolDown IEnumerator as it caused errors otherwise).

        transform.rotation = Quaternion.Slerp(transform.rotation, upRotation, Time.deltaTime * 18); //Gradually sets the rotation of the game object to the rotation stored in upRotation. This is done over time.

        if (transform.eulerAngles.x <= 1) //If the current x rotation of the game object is less than or equal to 1, then...
        {

            isDown = false; //Set the isDown boolean to false.

        }

    }

    public void AddingEXP() //This method finds the PlayerData script and adds the EXP gathered from this target to the player's current EXP.
    {

        GameObject player = GameObject.Find("Player"); //Finds the game object called "Player" so it can acces its scripts.

        PlayerData playerData = player.GetComponent<PlayerData>(); //Finds the script called "PlayerData" so it can access its variables.

        playerData.currentEXP += expValue; //Gets the currentEXP integer from the PlayerData script and adds the EXP from destroying this target on to it.

        print("[TARGET] Gained EXP: " + expValue + "."); //Ouputs the EXP gained from destroying this target into the console.
        print("[TARGET] Total EXP: " + playerData.currentEXP + "."); //Ouputs the new total EXP of the player into the console.

    }

}
