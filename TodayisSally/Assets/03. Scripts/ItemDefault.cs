using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDefault : MonoBehaviour
{
    bool isCrashed;
    float dis;
    Vector3 target;
    // Animator animator;

    private void Start()
    {
        // animator = GetComponent<Animator>();
        // isCrashed = false;
        dis = 2.5f;
    }

    private void Update()
    {
        //if (SubGameManager.instance.ismagatic && !isCrashed) // ���׳�ƽ ������ ������ �۵� & �浹���� �ʾ��� ��
        //{
        //    // target = Pet.instance.transform.position; // ���� ��ġ�� Ÿ�꿡 �Ҵ�

        //    if (Vector3.Distance(target, transform.position) < dis)
        //        transform.position = Vector3.MoveTowards(transform.position, target, 0.35f);
        //    // ���� ��ġ���� Ÿ�꿡 �Ҵ�� ��ġ�� 0.35f�� �ӵ��� ���ϴ� ���� ���� ��ġ������ �ٲ��.
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isCrashed)
        {
            // isCrashed = true;
            if (collision.gameObject.tag == "Player")
            {
                gameObject.layer = 13;
                SoundAllmanager.instance.PlayOnGetItemJelly();
                // animator.SetTrigger("Die");
                gameObject.SetActive(false);
            }
        }
    }
}
