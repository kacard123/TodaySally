using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMButton : MonoBehaviour
{
    public Slider slider;
    public Sprite onImage;
    public Sprite offImage;
    Color oncolor = new Color(0.3529412f, 0.4156863f, 0.1058824f, 1f);
    Color offcolor = new Color(0.4392157f, 0.4156863f, 0.3529412f, 1f);

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("BGMisOn"))
            PlayerPrefs.SetInt("BGMisOn", 1);
    }

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("BGMisOn") == 1)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
            gameObject.GetComponentInChildren<Image>().sprite = onImage;
            gameObject.GetComponentInChildren<Text>().text = "켜짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = oncolor;
            BGMmanager.instance.SoundOn(PlayerPrefs.GetFloat("BGMslider"));
        }
        else
        {
            gameObject.GetComponent<Toggle>().isOn = false;
            gameObject.GetComponentInChildren<Image>().sprite = offImage;
            gameObject.GetComponentInChildren<Text>().text = "꺼짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = offcolor;
            BGMmanager.instance.SoundOff();
        }
    }

    //706A5A,5A6A1B//
    public void Valuechanged()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            PlayerPrefs.SetInt("BGMisOn", 1);
            gameObject.GetComponentInChildren<Image>().sprite = onImage;
            gameObject.GetComponentInChildren<Text>().text = "켜짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = oncolor;
            BGMmanager.instance.SoundOn(PlayerPrefs.GetFloat("BGMslider"));
        }
        else
        {
            PlayerPrefs.SetInt("BGMisOn", 0);
            gameObject.GetComponentInChildren<Image>().sprite = offImage;
            gameObject.GetComponentInChildren<Text>().text = "꺼짐";
            gameObject.GetComponentInChildren<Outline>().effectColor = offcolor;
            BGMmanager.instance.SoundOff();
        }
    }
}
