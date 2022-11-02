using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideButton : MonoBehaviour
{

    public void OnButtonDown() // 버튼을 누를 때 발동되는 메서드
    {
        PlayerController.instance.DownSlideButton(); // 싱글턴 패턴 변수에 할당된, 버튼을 눌렀을 때 발동되는 애니메이션 관련 메서드
    }

    public void OnButtonUP() // 버튼에서 땔 떄 발동되는 메서드
    {
        PlayerController.instance.UpSlideButton(); // 싱글턴 패턴 변수에 할당된, 버튼을 눌렀을 때 발동되는 슬라이드 관련 애니메이션 관리하는 메서드
    }
}
