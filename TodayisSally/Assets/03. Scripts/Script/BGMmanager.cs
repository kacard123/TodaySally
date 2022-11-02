using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{

    public static BGMmanager instance;

    AudioSource audioSource;

    public AudioClip bgm_Mainlobby;
    public AudioClip bgm_The_Witchs_House;
    public AudioClip bgm_Twisted_Maze_Grove;

    bool isvolumeOn;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("BGMisOn"))
            if (PlayerPrefs.GetInt("BGMisOn") == 1)
                SoundOn(PlayerPrefs.GetFloat("BGMslider"));
            else
                SoundOff();
        else
            SoundOn(PlayerPrefs.GetFloat("BGMslider"));
    }

    public void PlayOnMainlobby()
    {
        audioSource.clip = bgm_Mainlobby;
        audioSource.Stop();
        audioSource.Play();
    }
    public void PlayOnChanege()
    {
        audioSource.clip = bgm_Twisted_Maze_Grove;
        audioSource.Stop();
        audioSource.Play();
    }

    public void PlayOnTitle()
    {

        audioSource.clip = bgm_The_Witchs_House;
        audioSource.Stop();
        audioSource.Play();
    }

    public void SoundOn(float value)
    {
        isvolumeOn = true;
        audioSource.mute = false;
        PlayerPrefs.SetFloat("BGMslider", value);
        audioSource.volume = PlayerPrefs.GetFloat("BGMslider");
    }

    public void SoundOff()
    {
        isvolumeOn = false;
        audioSource.mute = true;
    }

    public void ChangeVolume(float value)
    {
        if (isvolumeOn)
        {
            audioSource.volume = value;
        }
    }
}