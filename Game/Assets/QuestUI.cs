using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static Print;

public class QuestUI : MonoBehaviour
{ 
    string sN = "QUEST UI", sC = "#ffa500ff";

    void Start()
    {
        QuestManager.instance.onItemChangedCallback += UpdateUI;
    }
    void Update () //This method is called once per frame.
    {
        UpdateUI(); //Calls the UpdateUI method.
    }

    void CombineList()
    {
        //allQuests = QuestManager.instance.questsInPro.Union<Quest>(QuestManager.instance.questsCompleted).ToList<Quest>();
        //allQuests = QuestManager.instance.questsInPro;
    }

    public void UpdateUI () //This method creates an array of inventory slots depending on the number of InventorySlots in the backpack. For every slot, the equipment item is sent to a visual inventory slot, so the user can see it on screen.
    {
        //CombineList();        
        MissionSlot[] slots = GetComponentsInChildren<MissionSlot>(); //Creates an array of InventorySlot1s called slots. All of the InventorySlot1 components in the current transform is then assigned to the array.

        for (int i = 0; i < slots.Length; i++) //For every inventory slot...
        {
            if (i < QuestManager.instance.questsInPro.Count) //If there is less slots than equipment in inventory, then...
            {
                MissionsScrollList.instance.RefreshScrollList();
                Print.Log("Adding Mission Slot!", sN, sC);
                slots[i].AddMission(QuestManager.instance.questsInPro[i]); //Add the equipment to the slot (Calls the AddEquipment method in the current slot with the current equipment from inventory being sent over).
            } 
            else //If there are more slots than needed, then clear the slot.
            {
                Print.Log("Clearing Mission Slot!", sN, sC); 
                //slots[i].ClearSlot();
                slots[i].RemoveSlot();  
            }
        }
    }
}
