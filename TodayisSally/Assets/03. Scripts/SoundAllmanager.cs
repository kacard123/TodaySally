using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAllmanager : MonoBehaviour
{
    public static SoundAllmanager instance;

    AudioSource audioSource;

    public AudioClip[] getFlyingBearJelly;

    public AudioClip GameStart;
    public AudioClip GameEnd;
    public AudioClip Result;

    public AudioClip getAlphabatJelly;
    public AudioClip getBigBearJelly;
    public AudioClip getBigCoinJelly;
    public AudioClip getGoldJelly;
    public AudioClip getItemJelly;
    public AudioClip getJelly;

    public AudioClip crashWithBody;
    public AudioClip crashWithPower;
    public AudioClip bounceWithObstacle;
    public AudioClip giganticStart;
    public AudioClip giganticEnd;
    public AudioClip giganticLanding;

    public AudioClip jumpClip;
    public AudioClip slideClip;

    public AudioClip uibutton;

    int flyingjellyidx;
    bool isvolumeOn;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("SFXisOn"))
            if (PlayerPrefs.GetInt("SFXisOn") == 1)
                SoundOn(PlayerPrefs.GetFloat("SFXslider"));
            else
                SoundOff();
        else
            SoundOn(PlayerPrefs.GetFloat("SFXslider"));
        flyingjellyidx = 0;
    }

    public void PlayOnGameEnd()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(GameEnd);
    }

    public void PlayOnResult()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(Result);
    }

    public void PlayOnGetJelly()
    {
        audioSource.PlayOneShot(getJelly);
    }


    public void PlayOnGetFlyingBearJelly()
    {

        if (flyingjellyidx >= 6) flyingjellyidx = 0;
        // audioSource.PlayOneShot(getFlyingBearJelly[flyingjellyidx++]);

    }

    public void PlayOnGetBigBearJelly()
    {
        audioSource.PlayOneShot(getBigBearJelly);
    }

    public void PlayOnGetItemJelly()
    {
        audioSource.PlayOneShot(getItemJelly);
    }

    public void CrashWithObstacle()
    {
        audioSource.PlayOneShot(bounceWithObstacle);
    }

    public void PlayOnCrashWithBody()
    {
        audioSource.PlayOneShot(crashWithBody);
    }

    public void PlayOnGiganticStart()
    {
        audioSource.PlayOneShot(giganticStart);
    }

    public void PlayOnGiganticEnd()
    {
        audioSource.PlayOneShot(giganticEnd);
    }

    public void PlayOnGiganticLanding()
    {
        audioSource.PlayOneShot(giganticLanding);
    }

    public void PlayOnSlideclip()
    {
        audioSource.PlayOneShot(slideClip);
    }

    public void PlayOnJumpclip()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlayOnuibutton()
    {
        audioSource.PlayOneShot(uibutton);
    }

    public void SoundOn(float value)
    {
        isvolumeOn = true;
        audioSource.mute = false;
        PlayerPrefs.SetFloat("SFXslider", value);
        audioSource.volume = PlayerPrefs.GetFloat("SFXslider");
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
