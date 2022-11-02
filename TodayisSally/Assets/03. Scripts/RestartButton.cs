using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartButton : MonoBehaviour
{
    public void OnClick() // 재시작 버튼 클릭시 발동하는 메서드
    {

        SoundAllmanager.instance.PlayOnuibutton(); // 플레이시 재생되는 오디오 관련 메서드
        SceneManager.LoadScene("GameScene"); // 버튼 클릭시 "GameScene"을 씬 매니저를 통해 불러옴
        Time.timeScale = 1;
    }
}
