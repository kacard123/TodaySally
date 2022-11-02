using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXslider");
    }

    public void ValueChanged()
    {
        PlayerPrefs.SetFloat("SFXslider", gameObject.GetComponent<Slider>().value);
        SoundAllmanager.instance.ChangeVolume(PlayerPrefs.GetFloat("SFXslider"));
    }
}
