using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideButton : MonoBehaviour
{

    public void OnButtonDown() // ��ư�� ���� �� �ߵ��Ǵ� �޼���
    {
        PlayerController.instance.DownSlideButton(); // �̱��� ���� ������ �Ҵ��, ��ư�� ������ �� �ߵ��Ǵ� �ִϸ��̼� ���� �޼���
    }

    public void OnButtonUP() // ��ư���� �� �� �ߵ��Ǵ� �޼���
    {
        PlayerController.instance.UpSlideButton(); // �̱��� ���� ������ �Ҵ��, ��ư�� ������ �� �ߵ��Ǵ� �����̵� ���� �ִϸ��̼� �����ϴ� �޼���
    }
}
