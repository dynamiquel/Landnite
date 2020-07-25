using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Print;

public class Goal
{
    string sN = "GOAL", sC = "#ffa500ff";

    public Quest quest {get; set;}
    public string description {get; set;}
    public bool completed {get; set;}
    public int currentAmount {get; set;}
    public int requiredAmount {get; set;}
 
    public virtual void Initialise()
    {
        Debug.Log("[GOAL] " + description);
        Debug.Log("[GOAL] " + completed);
        Debug.Log("[GOAL] " + currentAmount);
        Debug.Log("[GOAL] " + requiredAmount);
    }

     public void Evaluate()
     {
        quest.CheckIfTracked();
        Print.Log("Updating", sN, sC);

        if (currentAmount >= requiredAmount)
                Complete();
     }

    public void Complete()
    {
        completed = true;
        Debug.Log("[GOAL] Goal Completed");
        quest.CheckGoals();
    }
}
