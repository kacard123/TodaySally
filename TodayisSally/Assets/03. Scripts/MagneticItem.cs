using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticItem : MonoBehaviour
{
    public PlayerController playerController; // �÷��̾��� ���� ������ �����ϱ� ����

    private void Start()
    {
        // �÷��̾ �±��� ������Ʈ�� ã�Ƽ� �÷��̾� ��Ʈ�ѷ� ������Ʈ ��������
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε��� ������Ʈ�� �±װ� player��
        if (collision.CompareTag("Player"))
        {
            if (playerController != null)
                playerController.MagnetTime();
            OnDie();
        }
    }

    public void OnDie()
    {
        // �� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
