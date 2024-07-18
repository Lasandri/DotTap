using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
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

    }

    public void ButtonClicked()
    {
        if (isOn)
        {

            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
            on = isOn;
        }

        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
            on = isOn;
        }
        UpdateURLParameter();
    }

    private void UpdateURLParameter()
    {
        string parameter = isOn ? "1" : "0";
        Application.ExternalCall("updateURLParameter", "s", parameter);
    }
}

