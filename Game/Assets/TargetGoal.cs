using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGoal : Goal
{
    public int targetID;
    public TargetGoal(int targetID_, string description_, bool completed_, int currentAmount_, int requiredAmount_)
    {
        this.targetID = targetID_;
        this.description = description_;
        this.completed = completed_;
        this.currentAmount = currentAmount_;
        this.requiredAmount = requiredAmount_;
    }

   /*  public override void Initialise()
    {
        base.Initialise();
        //CombatEvents.OnEnemyDeath += TargetKilled;
    }*/

     void TargetKilled(Target target)
    {
        if (target.id == this.targetID)
        {
            this.currentAmount++;
            //Evaluate();
        }
    }
}
