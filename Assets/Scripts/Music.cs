using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Music : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    private bool isOn = true;
    public Button button;
    public bool on;

    public AudioSource audioSource;

    private void Start()
    {
        soundOnImage = button.image.sprite;
        // Load sound setting from PlayerPrefs
        isOn = PlayerPrefs.GetInt("SoundSetting", 1) == 1;
        UpdateSoundSetting();
    }

    public void ButtonClicked()
    {
        isOn = !isOn;
        UpdateSoundSetting();
        // Save sound setting to PlayerPrefs
        PlayerPrefs.SetInt("SoundSetting", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateSoundSetting()
    {
        button.image.sprite = isOn ? soundOnImage : soundOffImage;
        audioSource.mute = !isOn;
        on = isOn;  // Update the 'on' variable
        UpdateURLParameter();
    }

    private void UpdateURLParameter()
    {
        string parameter = isOn ? "1" : "0";
        Application.ExternalCall("updateURLParameter", "m", parameter);
    }
}
