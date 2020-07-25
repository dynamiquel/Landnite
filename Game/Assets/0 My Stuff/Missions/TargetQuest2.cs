using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetQuest2 : Quest
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        id = 2;
        title = "Just One More";
        description = "Shoot one more target.";
        expReward = 50;
        money1Reward = 5;
        money2Reward = 1;
        //questReward = ;
        //itemReward = ;

        type = '1';
        goals.Add(new KillGoal(this, 1, "Shoot 1 Target", false, 0, 1));
        goals.ForEach(g => g.Initialise());
    }
}
