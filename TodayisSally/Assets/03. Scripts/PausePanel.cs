using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
        SoundAllmanager.instance.PlayOnuibutton();
    }
}
