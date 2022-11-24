using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public TextMeshProUGUI volumeText;
    public void setVolumeLevel(float sliderValue)
    {
        AudioListener.volume = sliderValue;
        volumeText.text = ((int)(sliderValue * 100)).ToString() + "%";
    }
}
