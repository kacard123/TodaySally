using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        while(true)
        {
            SceneManager.LoadScene("GameScene");
            yield return new WaitForSeconds(7f);
        }
        
    }
}
