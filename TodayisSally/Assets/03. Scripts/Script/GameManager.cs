using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 새 장면 로드 시 gameObject를 파괴하지 않도록
        Application.targetFrameRate = 60;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            Time.timeScale = 1;
            BGMmanager.instance.PlayOnChanege();
        }
        if (scene.name == "login")
        {
            Time.timeScale = 1;
            BGMmanager.instance.PlayOnTitle();
        }
        if (scene.name == "mode_select")
        {
            Time.timeScale = 1;
            BGMmanager.instance.PlayOnMainlobby();
        }

    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
