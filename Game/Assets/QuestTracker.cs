using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using static Print;

public class QuestTracker : MonoBehaviour
{
    string sN = "QUEST TRACKER", sC = "#ffa500ff";
    public static QuestTracker instance;

    GameObject[] trackerObjects = new GameObject[10];

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

    private void Start()
    {
        trackerObjects = GameObject.FindGameObjectsWithTag("QuestTracker");
        DisplayTracker(false);
    }

    public void DisplayTracker(bool x)
    {
        Print.Log("Setting Tracker to: " + x, sN, sC);
        if (trackerObjects != null)
        {
            for (int i = 0; i < trackerObjects.Length; i++)
            {
                trackerObjects[i].SetActive(x);
                Print.Log(trackerObjects[i].name, sN, sC);
            }
        }
    }

    public void SetTrackerData(string title, string g1t, string g2t, string g3t, string g4t, string g1p, string g2p, string g3p, string g4p)
    {
        trackerObjects[1].GetComponent<TextMeshProUGUI>().text = title;
        Print.Log("Title: " + title, sN, sC);
        trackerObjects[2].GetComponent<TextMeshProUGUI>().text = g1t;
        Print.Log("Goal 1 Title: " + g1t, sN, sC);
        trackerObjects[3].GetComponent<TextMeshProUGUI>().text = g2t;
        Print.Log("Goal 2 Title: " + g2t, sN, sC);
        trackerObjects[4].GetComponent<TextMeshProUGUI>().text = g3t;
        Print.Log("Goal 3 Title: " + g3t, sN, sC);
        trackerObjects[5].GetComponent<TextMeshProUGUI>().text = g4t;
        Print.Log("Goal 4 Title: " + g4t, sN, sC);
        trackerObjects[6].GetComponent<TextMeshProUGUI>().text = g1p;
        Print.Log("Goal 1 Progress: " + g1p, sN, sC);
        trackerObjects[7].GetComponent<TextMeshProUGUI>().text = g2p;
        Print.Log("Goal 2 Progress: " + g2p, sN, sC);
        trackerObjects[8].GetComponent<TextMeshProUGUI>().text = g3p;
        Print.Log("Goal 3 Progress: " + g3p, sN, sC);
        trackerObjects[9].GetComponent<TextMeshProUGUI>().text = g4p;
        Print.Log("Goal 4 Progress: " + g4p, sN, sC);

    }
}
