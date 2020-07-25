using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool playerInRange;
    UnityEngine.AI.NavMeshAgent nav;

    private void Awake()
    {
        nav = gameObject.GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            if ((gameObject.GetComponentInParent<Enemy>().health > 0) && (PlayerData.instance.currentHealth > 0))
            {
                playerInRange = true;
                nav.SetDestination(PlayerData.instance.gameObject.transform.position);
                nav.enabled = true;
            }
            else
            {
                nav.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
            nav.enabled = false;
        }
    }
}
