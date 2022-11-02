using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider slider;
    public string playScene;

    private float time;

    private void Start()
    {
        StartCoroutine(LoadAsynSceneCoroutine());
    }

    IEnumerator LoadAsynSceneCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(playScene); // 로딩 씬 이후의 씬을 비동기적으로 로드하도록 함

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            time =+ Time.time;

            slider.value = time / 5f; // 5초가 경과하면 
            if (time > 5)
            {
                operation.allowSceneActivation = true; // 장면이 준비된 즉시 활성화되도록
            }
            yield return null;
        }
    }

    //public Text text_Loading;
    //public Image image_fill;
    //private float time_loading = 5;
    //private float time_current;
    //private float time_start;
    //private bool isEnded = true;

    //void Start()
    //{
    //    Reset_Loading();
    //}

    //void Update()
    //{
    //    if (isEnded)
    //        return;
    //    Check_Loading();
    //}

    //private void Check_Loading()
    //{
    //    time_current = Time.time - time_start;
    //    if (time_current < time_loading)
    //    {
    //        Set_FillAmount(time_current / time_loading);
    //    }
    //    else if (!isEnded)
    //    {
    //        End_Loading();
    //    }
    //}

    //private void End_Loading()
    //{
    //    Set_FillAmount(1);
    //    isEnded = true;
    //    SceneManager.LoadScene("GameScene");
    //}

    //private void Reset_Loading()
    //{
    //    time_current = time_loading;
    //    time_start = Time.time;
    //    Set_FillAmount(0);
    //    isEnded = false;
    //}
    //private void Set_FillAmount(float _value)
    //{
    //    image_fill.fillAmount = _value;
    //    string txt = (_value.Equals(1) ? "Finished.. " : "Loading.. ") + (_value).ToString("P");
    //    text_Loading.text = txt;
    //    Debug.Log(txt);
    //}

}
