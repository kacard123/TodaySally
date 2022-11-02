using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Rigidbody2D rigid; // ������ٵ� ���� ����
    float angle = -700.0f; // �ޱ� ��
    float force = 40000.0f; // �������� �� ��
    bool isrotate; // ȸ���ÿ� bool ���� �޴� ������
    bool isCrashed; // �浹�ÿ� bool ���� �޴� ������
    int rot;

    void Start()
    {
        rot = Random.Range(0, 2); // ���� ���� �Է¹޴� rot ������ 0~2������ ���� �� ������ ���� �Ҵ�(2�� ����)
        rigid = this.GetComponent<Rigidbody2D>(); // ���� rigid�� ������Ʈ ������ٵ� �Ҵ�
        isrotate = false;
        isCrashed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) // �浹 �� ������ �޴� Ʈ���� �޼���
    {
        if(SubGameManager.instance.isGameover == false) // ���ӿ����� �ƴ� �ÿ�
        {
            if(collision.gameObject.tag == "Player" && PlayerController.instance.isreinforce && isCrashed == false) // �浹�� ���� ������Ʈ�� �±װ� Player�̰� 
            {                                                                                               // bool ���� isreinforce(���� ��ȭ ����)�� ����Ʈ���� false�̸� �浹���� ���� ���¿���
                isCrashed = true;
                StopCoroutine(Onrotate()); //Onrotate�޼��� �ڷ�ƾ ����
                StartCoroutine(Onrotate()); // �ڷ�ƾ �Լ� �ߵ�
                rigid.constraints = RigidbodyConstraints2D.None; // ������ٵ� ����� ���� ���� -> �⺻������ None ���� �Ҵ�Ǿ� ��� �࿡�� �����Ӱ� ������ ����
                rigid.AddForce(Vector2.right * force * Time.deltaTime);
                SoundAllmanager.instance.CrashWithObstacle(); // ��ֹ� �浹 �� �ߵ��Ǵ� ���� ���� �޼���

                rigid.velocity = Vector3.zero;
            }
        }
    }

    IEnumerator Onrotate() // �ڷ�ƾ �ߵ� ����
    {
        float time = 0f;
        while(time <= 3f)
        {
            yield return new WaitForSeconds(0.01f);
            time += Time.deltaTime;
            if(rot == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + angle * Time.deltaTime);
            }
        }
        gameObject.SetActive(false);
    }
}
