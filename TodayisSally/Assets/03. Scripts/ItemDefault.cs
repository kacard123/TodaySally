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
        //if (SubGameManager.instance.ismagatic && !isCrashed) // 마그네틱 역할의 아이템 작동 & 충돌하지 않았을 때
        //{
        //    // target = Pet.instance.transform.position; // 현재 위치를 타깃에 할당

        //    if (Vector3.Distance(target, transform.position) < dis)
        //        transform.position = Vector3.MoveTowards(transform.position, target, 0.35f);
        //    // 현재 위치에서 타깃에 할당된 위치로 0.35f의 속도로 향하는 것이 현재 위치값으로 바뀐다.
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
