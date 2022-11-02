using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour
{
    public int score; // 기본 아이템 섭취 시 나타나는 스코어
    bool isCrashed;
    float dis;
    Vector3 target;
    // Animator animator;
    
    void Start()
    {
        // animator = GetComponent<Animator>(); // 변수에 Animator 컴포넌트 할당
        isCrashed = false; // isCrashed에 false 값으로 할당
        dis = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //if(SubGameManager.instance.ismagatic && !isCrashed)
        //{
        //    // 플레이어를 따라다니는 펫 스크립트에서 위치 값을 target에 할당
        //    // target = Pet.instance.transform.position;
        //    if (Vector3.Distance(target, transform.position) < dis) // 타겟의 위치와 펫의 위치 값 거리 값이 dis에 할당된 수보다 작다면
        //        transform.position = Vector3.MoveTowards(transform.position, target, 0.35f); // 현재 이동할 위치 위치값에는 현재 위치가 타겟을 향해 
        //                                                                                     //최대 0.35f의 거리값으로 나아갈 때의 값이 할당됨.           
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCrashed) // 충돌하지 않았다면
        {
            // isCrashed = true; // 충돌 값에 true 할당
            if (collision.gameObject.tag == "Player") // 충돌하는 게임 오브젝트의 태그가 "Player"
            {
                // gameObject.layer = 13;
                SubGameManager.instance.updateScore(score);
                SoundAllmanager.instance.PlayOnGetJelly(); // 아이템을 먹었을 때 발동되는 사운드 메서드
                // animator.SetTrigger("Die"); // 충돌시 발동되는 파라미터 값
                Destroy(gameObject);
            }
        }
           
    }
}
