using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMoving: MonoBehaviour
{
    float posx = 6.26f;

    // ��� Update �Լ��� ȣ��� ��, ���������� ȣ��
    // �ַ� ������Ʈ�� ���󰡰� ������ ī�޶�� LateUpdate�� ���(ī�޶� ���󰡴� ������Ʈ�� Update�Լ� �ȿ��� ������ ��찡 �ֱ� ����).
    void LateUpdate()
    {

        if (PlayerController.instance != null && !SubGameManager.instance.isGameover)
            transform.position = new Vector3(PlayerController.instance.transform.position.x + posx, transform.position.y, transform.position.z);
    }
}
