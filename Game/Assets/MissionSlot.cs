using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using static Print;

public class MissionSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    string sN = "MISSION SLOT";
    string sC = "#ffa500ff";

    public Quest quest;
    public TMPro.TMP_Text missionText;
    bool displayInfo;
    char progressChar;
    TMPro.TMP_Text[] descriptionLabels = new TMPro.TMP_Text[11];
    TMPro.TMP_Text[] descriptionLabelsNoEdit = new TMPro.TMP_Text[6];
    Color32 customColour;

    public void Start() //This method is called when this script is first activated.
    {
        LinkingLabels(); //Calls the LinkingLabels method.
        LinkingImages(); //Calls the LinkingImages method.
    }

    public void AddMission(Quest newQuest)
    {
        
            Print.Log("Mission Added!", sN, sC);
            quest = newQuest; //Set the equipment attribute of this class equal to the one that was just added.

            missionText.text = quest.title; //Set the text field in the backpack slot equal to the name of the equipment (Set the text of backpackText to the string stored in the name attribute of the equipment scriptable object).
            Print.Log("Mission Added After Text Set!", sN, sC);
            if (!displayInfo) //If the displayInfo bool is false (the user is not currently hovering over the equipment item in the backpack UI), then...
            {
                //SettingTextColour(); //Call the SettingTextColour method.
            }
        
    }

    public void ClearSlot()
    {
        quest = null;
    }

    public void Update()
    {
        //RemoveSlot();
    }

    public void RemoveSlot()
    {
         if (quest == null)
        {
            Print.Log("Mission Slot Removed!", sN, sC);
            Destroy(gameObject);
        }
        
    }

    public void TrackQuest()
    {
        if (!quest.completed)
        {
            Print.Log("Mission " + quest.title + " Tracked!", sN, sC);
            QuestManager.instance.SetTrackedQuest(quest);
            UpdateTracked();
            DisplayMissionInfo();
        }
    }

    void UpdateTracked()
    {
        Print.Log("Updating Tracked Quest...", sN, sC);
        QuestTracker.instance.DisplayTracker(true);
        //QuestTracker.instance.SetTrackerData(this.title, this.goals[0].description, this.goals[1].description, this.goals[2].description, this.goals[3].description, this.goals[0].currentAmount + "/" + this.goals[0].requiredAmount, this.goals[1].currentAmount + "/" + this.goals[1].requiredAmount, this.goals[2].currentAmount + "/" + this.goals[2].requiredAmount, this.goals[3].currentAmount + "/" + this.goals[3].requiredAmount);
        QuestTracker.instance.SetTrackerData(quest.title, quest.goals[0].description, "X", "X", "X", quest.goals[0].currentAmount + "/" + quest.goals[0].requiredAmount, "X", "X", "X");
        Print.Log("Tracked Quest Updated", sN, sC);
    }

    void LinkingLabels() //This method assigns GUI text labels to the text label arrays of descriptionLabels and descriptionLabelsNoEdit.
    { 
         //This array has all of the text that changes depending on their equipment.
        descriptionLabels[0] = GameObject.Find("Title Text").GetComponent<TextMeshProUGUI>();
        descriptionLabels[1] = GameObject.Find("Type Text").GetComponent<TextMeshProUGUI>();
        descriptionLabels[2] = GameObject.Find("Completion Text").GetComponent<TextMeshProUGUI>();
        descriptionLabels[3] = GameObject.Find("Goal 1 Progress").GetComponent<TextMeshProUGUI>();
        descriptionLabels[4] = GameObject.Find("Goal 2 Progress").GetComponent<TextMeshProUGUI>();
        descriptionLabels[5] = GameObject.Find("Goal 3 Progress").GetComponent<TextMeshProUGUI>();
        descriptionLabels[6] = GameObject.Find("Goal 4 Progress").GetComponent<TextMeshProUGUI>();
        descriptionLabels[7] = GameObject.Find("EXP Text").GetComponent<TextMeshProUGUI>();
        descriptionLabels[8] = GameObject.Find("Main Currency Text").GetComponent<TextMeshProUGUI>();
        descriptionLabels[9] = GameObject.Find("Rare Currency Text").GetComponent<TextMeshProUGUI>();
        descriptionLabels[10] = GameObject.Find("Item Text").GetComponent<TextMeshProUGUI>();

        //This array has all of the text that only really changes on the equipment type (shield or gun).
        descriptionLabelsNoEdit[1] = GameObject.Find("Description Text").GetComponent<TextMeshProUGUI>();
        descriptionLabelsNoEdit[2] = GameObject.Find("Goal 1 Text").GetComponent<TextMeshProUGUI>();
        descriptionLabelsNoEdit[3] = GameObject.Find("Goal 2 Text").GetComponent<TextMeshProUGUI>();
        descriptionLabelsNoEdit[4] = GameObject.Find("Goal 3 Text").GetComponent<TextMeshProUGUI>();
        descriptionLabelsNoEdit[5] = GameObject.Find("Goal 4 Text").GetComponent<TextMeshProUGUI>();
    }

    [Tooltip("Link to the 'Description Rarity Image' game object.")]
    Image descriptionRarityBackground;


    [Tooltip("Link to the 'Description Background' game object.")]
    Image descriptionBackground;

    Image backpackHoverImage;

    [Header("Description Rarity Colours")]

    [Tooltip("Link to the 7 'Description Rarity Colours'. 0 = Empty, 1 = Common, 2 = Uncommon, 3 = Rare, 4 = Heroic, 5 = Legendary, 6 = Mythic.")]
    Sprite[] descriptionRarityColours = new Sprite[4];

    [Tooltip("Link to the 7 'Hover Rarity Colours'. 0 = Empty, 1 = Common, 2 = Uncommon, 3 = Rare, 4 = Heroic, 5 = Legendary, 6 = Mythic.")]
    Sprite[] hoverRarityImage = new Sprite[4];

    void LinkingImages() //This method finds the wanted images from the asset folder, and assigns them to certain sprites. It also finds certain game objects on the scene that can display these sprites.
    {

        //Finds the Image components of the game objects and saves them in an image variable.
        descriptionRarityBackground = GameObject.Find("Heading Background").GetComponent<Image>();

        descriptionBackground = GameObject.Find("Main Background").GetComponent<Image>();

        //Finds the game object in the current transform's children.
        backpackHoverImage = GetComponentInChildren<Image>();

        //Loads sprites from the assets folder and assigns them to the array called descriptionRarityColours.
        descriptionRarityColours[1] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/LegendaryDescriptionBackground");
        descriptionRarityColours[2] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/UncommonDescriptionBackground");
        descriptionRarityColours[3] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Description/RareDescriptionBackground");
        
        //Loads sprites from the assets folder and assigns them to the array called hoverRarityImage. These images will be enabled when the player is hovering over the inventory slot.
        hoverRarityImage[1] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/LegendaryBackpackHover");
        hoverRarityImage[2] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/UncommonBackpackHover");
        hoverRarityImage[3] = Resources.Load<Sprite>("My Stuff/Overlay Graphics/Character Hub/Inventory/Backpack/RareBackpackHover");
    }

 
    bool isMouse = true; ///Put in settings config later AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

    public void OnPointerEnter(PointerEventData ped) //If the mouse enters the proximity of this game object, then...
    {
        if (isMouse) //If the isMouse boolean is true (the user has chosen to use mouse support over keyboard support), then...
        {
            print("Pointer Enter");
            WhenSelected(); //Calls the WhenSelected method.
        }
    }
 
    public void OnSelect() //This method is called when the user hovers over the game object using arrow keys.
    {
        if (!isMouse) //If the isMouse boolean is false (the user has chosen not to use mouse support over keyboard support), then...
        {
            WhenSelected(); //Calls the WhenSelected method.
        }
        else
        {
            return;
        }
    }

    public void WhenSelected() //This method starts to display certain information on screen, including equipment stats and shows the user that this current game object is being selected.
    {

        if (missionText.text == "")
        {
            return;
        }

        else
        {
            print("Selected");
            displayInfo = true;
            //missionHoverImage.enabled = true;
            FindInfoToDisplay();
        }
    }

    public void OnPointerExit(PointerEventData ped) //If the mouse pointer has left the proximity of the game object, then...
    {
        if (isMouse) //If the isMouse boolean is true (the user has chosen to use mouse support over keyboard support), then...
        {
            print("Pointer Exit");
            WhenNotSelected(); //Calls the WhenNotSelected method.
        }
    }
 
    public void OnDeselect() //This method is called when the user deselects the game object using arrow keys.
    {
        if (!isMouse) //If the isMouse boolean is false (the user has chosen not to use mouse support over keyboard support), then...
        {
            WhenNotSelected(); //Calls the WhenNotSelected method.
        }
    }

    public void WhenNotSelected() //This method hides all the information that was shown when the game object was selected (hides weapon statistics, disables the hover image, etc).
    {
        print("Deselected");
        displayInfo = false;
        //backpackHoverImage.enabled = false;
        FindInfoToDisplay();
    }

    public void FindInfoToDisplay()
    {
        if (displayInfo)
        {
            DisplayMissionInfo();
        }
        else
        {
            RemoveMissionInfo();
        }
    }

    void DisplayMissionInfo()
    {
        CalculateMissionStats();
    }

    void DisplayMissionInfo2(string missionProgress, string[] goalProgress)
    {
        missionText.color = new Color32(255, 255, 255, 255);
        backpackHoverImage.enabled = true;
        descriptionRarityBackground.enabled = true;
        descriptionBackground.enabled = true;
        descriptionLabels[0].text = quest.title;
        descriptionLabels[1].text = CalculateQuestType();
        descriptionLabels[2].text = missionProgress;
        descriptionLabels[3].text = goalProgress[0];
        descriptionLabels[4].text = goalProgress[1];
        descriptionLabels[5].text = goalProgress[2];
        descriptionLabels[6].text = goalProgress[3];
        descriptionLabels[7].text = quest.expReward.ToString() + " EXP";
        descriptionLabels[8].text = "$" + quest.money1Reward.ToString();
        descriptionLabels[9].text = "$$$" + quest.money2Reward.ToString();
        //descriptionLabels[10].text = quest.itemReward.name;

        descriptionLabelsNoEdit[1].text = quest.description;
        descriptionLabelsNoEdit[2].text = quest.goals[0].description;
        descriptionLabelsNoEdit[3].text = quest.goals[1].description;
        descriptionLabelsNoEdit[4].text = quest.goals[2].description;
        descriptionLabelsNoEdit[5].text = quest.goals[3].description;
    }

    void RemoveMissionInfo()
    {
        missionText.color = customColour;
        backpackHoverImage.enabled = false;
        descriptionRarityBackground.enabled = false;
        descriptionBackground.enabled = false;
        descriptionLabels[0].text = "";
        descriptionLabels[1].text = "";
        descriptionLabels[2].text = "";
        descriptionLabels[3].text = "";
        descriptionLabels[4].text = "";
        descriptionLabels[5].text = "";
        descriptionLabels[6].text = "";
        descriptionLabels[7].text = "";
        descriptionLabels[8].text = "";
        descriptionLabels[9].text = "";
        descriptionLabels[10].text = "";

        descriptionLabelsNoEdit[1].text = "";
        descriptionLabelsNoEdit[2].text = "";
        descriptionLabelsNoEdit[3].text = "";
        descriptionLabelsNoEdit[4].text = "";
        descriptionLabelsNoEdit[5].text = "";
    }

    void CalculateMissionStats()
    {
        string missionProgress = CalculateQuestCompletion(quest.completed);
        string[] goalProgress = new string[4];

        for (int i = 0; i < quest.goals.Count; i++)
        {
            goalProgress[i] = CalculateGoalCompletion(quest.goals[i].currentAmount, quest.goals[i].requiredAmount);
        }

        DisplayMissionInfo2(missionProgress, goalProgress);
    }

    string CalculateQuestType()
    {
        if (quest.type == '1')
        {
            return "Main Mission";
        }
        else if (quest.type == '2')
        {
            return "Side Mission";
        }
        else
        {
            return "Unknown Mission";
        }
    }

    string CalculateQuestCompletion(bool completed)
    {
        if (completed)
        {
            customColour = new Color32(100, 186, 84, 255);
            descriptionRarityBackground.sprite = descriptionRarityColours[2];
            backpackHoverImage.sprite = hoverRarityImage[2];
            return "Completed";
        }
        else
        {
            string answer;
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
                if (quest.id == QuestManager.instance.trackedQuest.id)
                {
                    customColour = new Color32(230, 171, 77, 255);
                    descriptionRarityBackground.sprite = descriptionRarityColours[1];
                    backpackHoverImage.sprite = hoverRarityImage[1];
                    answer = "Pursuing";
                }
                else
                {
                    customColour = new Color32(90, 162, 237, 255);
                    descriptionRarityBackground.sprite = descriptionRarityColours[3];
                    backpackHoverImage.sprite = hoverRarityImage[3];
                    answer = "In Progress";
                }
            }
            else if (!worked && done)
            {
                customColour = new Color32(90, 162, 237, 255);
                descriptionRarityBackground.sprite = descriptionRarityColours[3];
                backpackHoverImage.sprite = hoverRarityImage[3];
                answer = "In Progress";
            }
            else
            {
                customColour = new Color32(90, 162, 237, 255);
                descriptionRarityBackground.sprite = descriptionRarityColours[3];
                backpackHoverImage.sprite = hoverRarityImage[3];
                answer = "In Progress";
            }       
                 
            return answer;
        }
    }

    string CalculateGoalCompletion(int currentAmount, int requiredAmount)
    {
        if (currentAmount >= requiredAmount)
        {
            return "Done";
        }
        else
        {
            return currentAmount.ToString() + "/" + requiredAmount.ToString();
        }
    }
}
