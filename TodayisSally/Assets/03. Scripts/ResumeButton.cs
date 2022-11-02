using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject pauseMenu;

    public void OnClick() // 버튼 클릭시 작동하는 메서드
    {
        Time.timeScale = 1; // 일시정지
        SoundAllmanager.instance.PlayOnuibutton(); // 사운드 플레이버튼 관련 메서드를 싱글턴 패턴으로 접근
        pauseMenu.SetActive(false); // 일시중지 메뉴 활성화를 false로 할당
    }

}
