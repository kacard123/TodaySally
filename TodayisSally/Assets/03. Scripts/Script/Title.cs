using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject readText;
    public static Title instance;


    void Awake()
    {
        if (Title.instance == null)
            Title.instance = this;
    }
    // Use this for initialization
    void Start()
    {
        readText.SetActive(false);
        StartCoroutine(ShowReady());
    }

    IEnumerator ShowReady()
    {
        int count = 0;
        while (count < 3)
        {
            readText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            readText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
}
