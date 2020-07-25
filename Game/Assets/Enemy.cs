using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int baseHealth, baseDamage, level;
    public int health, damage;
    public bool isDamageable = true;
    bool canAttack = true;
    public float attackDelay = 2f;

    public bool playerInRange;
    public float lookRadius;
    UnityEngine.AI.NavMeshAgent nav;
    Transform target;

    private void Start()
    {
        CalculateLevelVariables(); //Calls the 'CalculateLevelVariables' method.
        target = PlayerData.instance.gameObject.transform; //Sets the player game object as the target.
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>(); //Sets the nav mesh agent to the one found on this game object.
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); //Calculates the distance between the enemy and the player.

        if ((distance < lookRadius) && (PlayerData.instance.currentHealth > 0) && (health > 0)) //If the distance is less than the look radius for the enemy, and both the player and enemy are alive, then...
        {
            playerInRange = true; //Sets playerInRange bool to true.
            nav.SetDestination(target.position); //Moves the enemy towards the player.
        }
        else //Else...
        {
            playerInRange = false; //Sets playerInRange bool to false.
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; //Sets the colour of a gizmo.
        Gizmos.DrawWireSphere(transform.position, lookRadius); //Creates a gizmo that can be seen in Scene View.
    }

    public void OnTriggerStay(Collider collision) //This method is called when the game object tagged 'Player' is in contact with the enemy (this game object). It gives this money to the player and then destroys this game object so it cannot be picked up again.
    {
        if (collision.gameObject.tag == "Player") //If the gameobject that collided with this game object has a tag of 'Player (if the player collided with this game object), then
        {
            if (PlayerData.instance != null) //If there is a PlayerData instance present, then...
            {
                PerformAttack(); //Calls the 'PerformAttack' method.
            }
        }
    }

    IEnumerator ResetAttack() //This method resets the enemy's attack cooldown.
    {
        if (!canAttack) //If 'canAttack' is false (the enemy has recently attacked), then..
        {
            yield return new WaitForSeconds(attackDelay); //Wait until the 'attackDelay' has finished.
            canAttack = true; //Set 'canAttack' to true (allow the enemy to attack again).
        }
    }

    void PerformAttack() //This method allows the enemy to perform an attack on the player.
    {
        if (canAttack) //If 'canAttack' is true (the enemy is allowed to attack), then...
        {
            PlayerData.instance.gameObject.GetComponent<DamagePlayer>().TakeDamage(damage); //Damage the player accordingly through the 'TakeDamage' method in the 'DamagePlayer' script.
            //PlayerData.instance.currentHealth -= damage; //Damage the player accordingly.
            canAttack = false; //Set 'canAttack' to false (do not allow the enemy to attack again).
            StartCoroutine(ResetAttack()); //Call the 'ResetAttack' method.
        }
    }

    void CalculateLevelVariables() //This method calculates the variables that depend on the enemy's level.
    {
        health = Mathf.RoundToInt((float)(baseHealth * Mathf.Pow(1.1301f, level))); //Calculates the health of the enemy.
        damage = Mathf.RoundToInt((float)(baseDamage * Mathf.Pow(1.1301f, level))); //Calculates the damage of the enemy.
    }

    public void DetectHit(int amount) //This method is called by the 'Gun' script and it damages the enemy.
    {
        if (isDamageable) //If the enemy is allowed to be damaged ('isDamageable' is true), then...
        {
            health -= amount; //Take health away from the enemy.

            CheckDeath(); //Call the 'CheckDeath' method.
        }
    }

    void CheckDeath() //This method checks if the enemy has no health, and if it doesn't calls the method tells the program what to do when it has no health.
    {
        if (health <= 0) //If the enemy's health is equal or less than 0, then...
        {
            OnDeath(); //Call the 'OnDeath' method.
        }
    }

    void OnDeath() //This method does everything the program needs to do when the enemy dies.
    {
        GiveRewards(); //Call 'GiveRewards' method.
        Destroy(gameObject); //Destroys the enemy.
    }

    void GiveRewards() //This methods gives rewards to the player once the enemy has died.
    {
        GiveEXP(); //Call 'GiveEXP' method.
        DropMoney(); //Call 'DropMoney' method.
        DropAmmo(); //Call 'DropAmmo' method.
        DropHealth(); //Call 'DropHealth' method.
    }

    void GiveEXP() //This method gives experience points to the player.
    {
        PlayerData.instance.currentEXP += Mathf.RoundToInt((float)(25 * Mathf.Pow(1.1301f, level))); //Gives experience points to the player depending on the enemy's level.
    }

    public Transform moneyDrop, ammoDrop, healthDrop; //Used to store an instance of particular drops.
    

    Vector3 RandomRange() //This method creates a Vector3 that will have random values depending on a range.
    {
        Vector3 randomRange = new Vector3(UnityEngine.Random.Range(-1.6f, 1.6f), 0, UnityEngine.Random.Range(-1.6f, 1.6f)); //Creates a Vector3 with a random x and z position.
        return randomRange; //Returns the 'randomRange' vector 3 variable.
    }

    void DropMoney() //This method drops a money pickup from the enemy.
    {
        int chance = UnityEngine.Random.Range(1, 5); //Calculates the chance of the item being dropped.

        if (chance <= 1) //25% chance of dropping item.
        {
            Instantiate(moneyDrop, transform.position + RandomRange(), transform.rotation); //Drops the item within a certain range from the enemy.
        }
    }

    void DropAmmo() //This method drops an ammo pickup from the enemy.
    {
        int chance = UnityEngine.Random.Range(1, 5); //Calculates the chance of the item being dropped.

        if (chance <= 3) //75% chance of dropping item.
        {
            ammoDrop.gameObject.GetComponent<ammoPickup>().ammoType = Convert.ToChar(UnityEngine.Random.Range('1', '7')); //Chooses a random ammo type for the ammo drop.
            Instantiate(ammoDrop, transform.position + RandomRange(), transform.rotation); //Drops the item within a certain range from the enemy.
        }
    }

    void DropHealth()//This method drops a health pickup from the enemy.
    {
        int chance = UnityEngine.Random.Range(1, 5); //Calculates the chance of the item being dropped.

        if (chance <= 2) //50% chance of dropping item.
        {
            healthDrop.gameObject.GetComponent<HealthPickup>().isPercentage = true; //Chooses the 'isPercentage' health drop.
            healthDrop.gameObject.GetComponent<HealthPickup>().value = UnityEngine.Random.Range(0.25f, 0.5f); //Chooses a random percentage value between 25% and 50%.
            Instantiate(healthDrop, transform.position + RandomRange(), transform.rotation); //Drops the item within a certain range from the enemy.
        }
    }
}
