using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTargetQuest : Quest
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        id = 1;
        title = "Target Down";
        description = "Shoot some of the nearby targets and get used to your gun.";
        expReward = 20;
        money1Reward = 10;
        //money2Reward = ;
        //questReward = new TargetQuest2();
        //itemReward = ;

        type = '1';
        goals.Add(new KillGoal(this, 1, "Shoot 5 Targets", false, 0, 5));
        goals.ForEach(g => g.Initialise());
    }
}
