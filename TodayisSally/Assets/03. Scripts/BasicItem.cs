using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour
{
    public int score; // �⺻ ������ ���� �� ��Ÿ���� ���ھ�
    bool isCrashed;
    float dis;
    Vector3 target;
    // Animator animator;
    
    void Start()
    {
        // animator = GetComponent<Animator>(); // ������ Animator ������Ʈ �Ҵ�
        isCrashed = false; // isCrashed�� false ������ �Ҵ�
        dis = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //if(SubGameManager.instance.ismagatic && !isCrashed)
        //{
        //    // �÷��̾ ����ٴϴ� �� ��ũ��Ʈ���� ��ġ ���� target�� �Ҵ�
        //    // target = Pet.instance.transform.position;
        //    if (Vector3.Distance(target, transform.position) < dis) // Ÿ���� ��ġ�� ���� ��ġ �� �Ÿ� ���� dis�� �Ҵ�� ������ �۴ٸ�
        //        transform.position = Vector3.MoveTowards(transform.position, target, 0.35f); // ���� �̵��� ��ġ ��ġ������ ���� ��ġ�� Ÿ���� ���� 
        //                                                                                     //�ִ� 0.35f�� �Ÿ������� ���ư� ���� ���� �Ҵ��.           
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCrashed) // �浹���� �ʾҴٸ�
        {
            // isCrashed = true; // �浹 ���� true �Ҵ�
            if (collision.gameObject.tag == "Player") // �浹�ϴ� ���� ������Ʈ�� �±װ� "Player"
            {
                // gameObject.layer = 13;
                SubGameManager.instance.updateScore(score);
                SoundAllmanager.instance.PlayOnGetJelly(); // �������� �Ծ��� �� �ߵ��Ǵ� ���� �޼���
                // animator.SetTrigger("Die"); // �浹�� �ߵ��Ǵ� �Ķ���� ��
                Destroy(gameObject);
            }
        }
           
    }
}
