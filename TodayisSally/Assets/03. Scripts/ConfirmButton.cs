using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    public void OnClick()
    {
        // SoundAllmanager.instance.PlayOnuibutton(); // ���� ���� �Ŵ��� ��ũ��Ʈ�� �÷��̽� �ߵ��Ǵ� ���� ���� �޼��忡 ����
        SceneManager.LoadScene("GameScene"); // ������ ����Ǵ� ���Ӿ��� ���� ���� �ҷ���
    }
}
