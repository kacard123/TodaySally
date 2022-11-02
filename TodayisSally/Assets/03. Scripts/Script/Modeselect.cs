using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modeselect : MonoBehaviour
{

    public string sceneName;

    public void Enterpoint()
    {
        transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
    }
    
    public void Exitpoint()
    {
        transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public void MouseDown()
    {
        transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
    }

    public void MouseUp()
    {
        transform.localScale = new Vector3(2f, 2f, 2f);
        if (sceneName != "null")
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
