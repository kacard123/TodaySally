using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartButton : MonoBehaviour
{
    public void OnClick() // ����� ��ư Ŭ���� �ߵ��ϴ� �޼���
    {

        SoundAllmanager.instance.PlayOnuibutton(); // �÷��̽� ����Ǵ� ����� ���� �޼���
        SceneManager.LoadScene("GameScene"); // ��ư Ŭ���� "GameScene"�� �� �Ŵ����� ���� �ҷ���
        Time.timeScale = 1;
    }
}
