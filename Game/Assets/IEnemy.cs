using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int id {get; set;}
    void Die();
    void TakeDamage(float amount);
    void PerformAttack();

}
