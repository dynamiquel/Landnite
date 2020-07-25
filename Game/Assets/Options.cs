using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    string sN = "OPTIONS", sC = "#40b01e";

    public static Options instance;

    //Audio
    public float musicVolume;
    public float fxVolume;
    //Mouse sensitivity
    public float mouseXSens;
    public float mouseYSens;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshOptions()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetFloat("MusicVolume", 0.7f);
        if (!PlayerPrefs.HasKey("FXVolume"))
            PlayerPrefs.SetFloat("FXVolume", 0.7f);
        if (!PlayerPrefs.HasKey("MouseXSens"))
            PlayerPrefs.SetFloat("MouseXSens", 6f);
        if (!PlayerPrefs.HasKey("MouseYSens"))
            PlayerPrefs.SetFloat("MouseYSens", 5f);

        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        fxVolume = PlayerPrefs.GetFloat("FXVolume");
        mouseXSens = PlayerPrefs.GetFloat("MouseXSens");
        mouseYSens = PlayerPrefs.GetFloat("MouseYSens");

        Print.Log("Applying Changes... (3/5 - Applying Changes in game)", sN, sC);
        OptionsChanged();
        Print.Log("Applying Changes... (4/5 - Applied Changed in game)", sN, sC);

    }

    public void OptionsChanged()
    {
        if (GameObject.FindGameObjectWithTag("MusicAudioSource"))
        {
            GameObject.FindGameObjectWithTag("MusicAudioSource").GetComponent<AudioSource>().volume = musicVolume;
        }
        if (GameObject.FindGameObjectWithTag("NavigationAudioSource"))
        {
            GameObject.FindGameObjectWithTag("NavigationAudioSource").GetComponent<AudioSource>().volume = fxVolume;
        }
        if (GameObject.FindGameObjectWithTag("FXAudioSource"))
        {
            GameObject[] aS = GameObject.FindGameObjectsWithTag("FXAudioSource");
            for (int i = 0; i < aS.Length; i++)
            {
                aS[i].GetComponent<AudioSource>().volume = fxVolume;
            }
        }
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject[] aS = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < aS.Length; i++)
            {
                aS[i].GetComponent<AudioSource>().volume = fxVolume;
                aS[i].GetComponent<MouseMovement>().mouseXSensitivity = mouseXSens;
                aS[i].GetComponent<MouseMovement>().mouseYSensitivity = mouseYSens;
            }
        }
        if (GameObject.FindGameObjectWithTag("MainCamera"))
        {
            GameObject[] aS = GameObject.FindGameObjectsWithTag("MainCamera");
            for (int i = 0; i < aS.Length; i++)
            {
                if (aS[i].GetComponent<AudioSource>())
                {
                    aS[i].GetComponent<AudioSource>().volume = fxVolume;
                }
            }
        }
    }
}
