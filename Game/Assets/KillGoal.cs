using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public int enemyID {get; set;}

    public KillGoal(Quest quest_, int enemyID_, string description_, bool completed_, int currentAmount_, int requiredAmount_)
    {
        this.quest = quest_;
        this.enemyID = enemyID_;
        this.description = description_;
        this.completed = completed_;
        this.currentAmount = currentAmount_;
        this.requiredAmount = requiredAmount_;
    }
 
    public override void Initialise()
    {
        base.Initialise();
        CombatEvents.OnEnemyDeath += EnemyKilled;
    }

    void EnemyKilled(IEnemy enemy)
    {
        if (enemy.id == this.enemyID)
        {
            this.currentAmount++;
            Evaluate();
        }
    }
}
