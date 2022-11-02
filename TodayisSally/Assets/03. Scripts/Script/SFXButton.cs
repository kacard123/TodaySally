using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXButton : MonoBehaviour
{
    public Slider slider;
    public Sprite onImage;
    public Sprite offImage;
    Color oncolor = new Color(0.3529412f, 0.4156863f, 0.1058824f, 1f);
    Color offcolor = new Color(0.4392157f, 0.4156863f, 0.3529412f, 1f);

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("SFXisOn"))
            PlayerPrefs.SetInt("SFXisOn", 1);
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("SFXisOn") == 1)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
            gameObject.GetComponentInChildren<Image>().sprite = onImage;
            gameObject.GetComponentInChildren<Text>().text = "켜짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = oncolor;
            SoundAllmanager.instance.SoundOn(PlayerPrefs.GetFloat("SFXslider"));
        }
        else
        {
            gameObject.GetComponent<Toggle>().isOn = false;
            gameObject.GetComponentInChildren<Image>().sprite = offImage;
            gameObject.GetComponentInChildren<Text>().text = "꺼짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = offcolor;
            SoundAllmanager.instance.SoundOff();
        }
    }

    //706A5A,5A6A1B//
    public void Valuechanged()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            PlayerPrefs.SetInt("SFXisOn", 1);
            gameObject.GetComponentInChildren<Image>().sprite = onImage;
            gameObject.GetComponentInChildren<Text>().text = "켜짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = oncolor;
            SoundAllmanager.instance.SoundOn(PlayerPrefs.GetFloat("SFXslider"));
        }
        else
        {
            PlayerPrefs.SetInt("SFXisOn", 0);
            gameObject.GetComponentInChildren<Image>().sprite = offImage;
            gameObject.GetComponentInChildren<Text>().text = "꺼짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = offcolor;
            SoundAllmanager.instance.SoundOff();
        }
    }
}
