using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Print;

public class OptionsMenu : MonoBehaviour
{
    string sN = "OPTIONS MENU", sC = "#40b01e";

    public Slider musicVolumeSlider;
    public Slider fxVolumeSlider;
    public Slider mouseXSensSlider;
    public Slider mouseYSensSlider;

    public GameObject applyButton;
    GameObject backButton;

    float musicVolume;
    float fxVolume;
    float mouseXSens;
    float mouseYSens;

    public GameObject optionsMenu;

    public static OptionsMenu instance;

    public bool menuOpen;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicVolumeSlider = GameObject.Find("Music Volume Slider").GetComponent<Slider>();
        fxVolumeSlider = GameObject.Find("FX Volume Slider").GetComponent<Slider>();
        mouseXSensSlider = GameObject.Find("MouseXSens Slider").GetComponent<Slider>();
        mouseYSensSlider = GameObject.Find("MouseYSens Slider").GetComponent<Slider>();

        //applyButton = GameObject.Find("Options Apply Button");
        backButton = GameObject.Find("Options Back Button");
    }

    public void MusicVolumeSliderChanged()
    {
        ValueChanged();
    }

    public void FXVolumeSliderChanged()
    {
        ValueChanged();
    }

    public void MouseXSensSliderChanged()
    {
        ValueChanged();
    }

    public void MouseYSensSliderChanged()
    {
        ValueChanged();
    }

    void ValueChanged()
    {
        applyButton.SetActive(true);
    }

    public void ApplyButton()
    {
        ApplyChanges();
    }

    public void BackButton()
    {        
        optionsMenu.SetActive(false);
        menuOpen = false;
    }

    void ApplyChanges()
    {
        Print.Log("Applying Changes... (1/5)", sN, sC);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("FXVolume", fxVolumeSlider.value);
        PlayerPrefs.SetFloat("MouseXSens", mouseXSensSlider.value);
        PlayerPrefs.SetFloat("MouseYSens", mouseYSensSlider.value);

        applyButton.SetActive(false);
        PlayerPrefs.Save();
        Print.Log("Applying Changes (2/5 - Refreshing Options)", sN, sC);
        Options.instance.RefreshOptions();
        Print.Log("Applied Changes (5/5)", sN, sC);
    }

    public void SetupMenu()
    {
        menuOpen = true;

        optionsMenu.SetActive(true);

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


        musicVolumeSlider.value = musicVolume;
        fxVolumeSlider.value = fxVolume;
        mouseXSensSlider.value = mouseXSens;
        mouseYSensSlider.value = mouseYSens;

        applyButton.SetActive(false);
    }

    char guide = '0';
    public GameObject guideView;

    public void ToggleGuide()
    {
        if (guide == '0')
        {
            guideView.SetActive(true);
            guide = '1';
        }
        else if (guide == '1')
        {
            guideView.SetActive(false);
            guide = '0';
        }

    }
}