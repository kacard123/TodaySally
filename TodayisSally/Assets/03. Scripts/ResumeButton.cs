using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject pauseMenu;

    public void OnClick() // ��ư Ŭ���� �۵��ϴ� �޼���
    {
        Time.timeScale = 1; // �Ͻ�����
        SoundAllmanager.instance.PlayOnuibutton(); // ���� �÷��̹�ư ���� �޼��带 �̱��� �������� ����
        pauseMenu.SetActive(false); // �Ͻ����� �޴� Ȱ��ȭ�� false�� �Ҵ�
    }

}
