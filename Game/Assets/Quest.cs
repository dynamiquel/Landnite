using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static Print;

public class Quest : MonoBehaviour
{
    string sN = "QUEST", sC = "#ffa500ff";

    public int id {get; set;}
    public List<Goal> goals {get; set;} = new List<Goal>();
    public string title {get; set;}
    public string description {get; set;}
    public int money1Reward {get; set;}
    public int money2Reward  {get; set;}
    public int expReward  {get; set;}
    public Item itemReward {get; set;}
    public Quest questReward { get; set; }
    public bool completed  {get; set;}
    public char type {get; set;}

    public void CheckGoals()
    {
        if (goals.All(g => g.completed))
        {
            completed = true;
        }

        if (completed)
        {
            Completed();
        }
    }

    void Completed()
    {
        Print.Log("Quest Completed", sN, sC);
        Untrack();
        GiveRewards();
        QuestManager.instance.questsInPro.Remove(this);
    }

    void GiveRewards()
    {
         if (itemReward != null)
        {
            //Give item
            Inventory.instance.AddEquipment((Equipment)itemReward);
        }
        if (money1Reward != null)
        {
            //Give money 1
            PlayerData.instance.currentMainCurrency += money1Reward;
        }
        if (money2Reward != null)
        {
            //Give money 2
            PlayerData.instance.currentMainCurrency += money2Reward;
        }
        if (expReward != null)
        {
            //Give exp
            PlayerData.instance.currentEXP += expReward;
        }
        if (questReward != null)
        {
            //Give quest
            QuestManager.instance.AddQuest(questReward);
        }
    }

    void Untrack()
    {
        Print.Log("Untracking Quest...", sN, sC);

        bool worked;
        bool done;

        try
        {
            string id__ = QuestManager.instance.trackedQuest.id.ToString();
            worked = true;
            done = true;
        }
        catch (System.Exception e)
        {
            worked = false;
            done = true;
        }

        if (worked && done)
        {
            QuestManager.instance.trackedQuest = null;
            Print.Log("Tracked Quest deleted", sN, sC);
            QuestTracker.instance.DisplayTracker(false);
        }
        
    }

    public void CheckIfTracked()
    {
        bool worked, done;
        try
        {
            string id__ = QuestManager.instance.trackedQuest.id.ToString();
            worked = true;
            done = true;
        }
        catch (System.Exception e)
        {
            worked = false;
            done = true;
        }

        if (worked && done)
        {
            Print.Log("Quest is same as Tracked Quest", sN, sC);
            UpdateTracked();
        }
    }

    void UpdateTracked()
    {
        Print.Log("Updating Tracked Quest...", sN, sC);
        QuestTracker.instance.DisplayTracker(true);
        //QuestTracker.instance.SetTrackerData(this.title, this.goals[0].description, this.goals[1].description, this.goals[2].description, this.goals[3].description, this.goals[0].currentAmount + "/" + this.goals[0].requiredAmount, this.goals[1].currentAmount + "/" + this.goals[1].requiredAmount, this.goals[2].currentAmount + "/" + this.goals[2].requiredAmount, this.goals[3].currentAmount + "/" + this.goals[3].requiredAmount);
        QuestTracker.instance.SetTrackerData(this.title, this.goals[0].description, "X", "X", "X", this.goals[0].currentAmount + "/" + this.goals[0].requiredAmount, "X", "X", "X");
        Print.Log("Tracked Quest Updated", sN, sC);
    }

    public virtual void Start()
    {
        
    }
}
