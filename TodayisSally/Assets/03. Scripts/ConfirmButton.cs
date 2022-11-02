using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    public void OnClick()
    {
        // SoundAllmanager.instance.PlayOnuibutton(); // 사운드 관리 매니저 스크립트의 플레이시 발동되는 사운드 관련 메서드에 접근
        SceneManager.LoadScene("GameScene"); // 게임이 진행되는 게임씬이 전의 씬을 불러옴
    }
}
