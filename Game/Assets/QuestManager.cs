using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestManager : MonoBehaviour
{
   public static QuestManager instance;
   public List<Quest> questsInPro {get; set;} = new List<Quest>();
   public List<Quest> questsCompleted {get; set;} = new List<Quest>();

   public Quest trackedQuest {get; set;}

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }

    public void AddQuest(Quest quest)
    {
        quest.Start();
        questsInPro.Add(quest);
        if (onItemChangedCallback != null)
        {

            onItemChangedCallback.Invoke();

        }
        questsInPro.ForEach(q =>
        {
            print("[QUEST MANAGER] Quest in Progress: " + q.title);
        });
    }

   public delegate void OnItemChanged();
   public OnItemChanged onItemChangedCallback;

   void Start()
   {
      Quest introQuest = new IntroTargetQuest();
      AddQuest(introQuest);
      Quest targetQuest2 = new TargetQuest2();
      AddQuest(targetQuest2);
    }

   public void MoveCompletedQuest(Quest quest)
   {
      questsInPro.Remove(quest);
      questsCompleted.Add(quest);
   }

   public void SetTrackedQuest(Quest quest)
   {
      trackedQuest = quest;
   }

   public void SortLists()
   {
      questsInPro.OrderBy(q => q.title);
      questsCompleted.OrderBy(q => q.title);
   }
}
