using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void Onclick()
    {
        SoundAllmanager.instance.PlayOnuibutton();
        // SubGameManager.instance.GameStop();
        Application.Quit();
    }
}
