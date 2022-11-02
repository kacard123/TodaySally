using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticItem : MonoBehaviour
{
    public PlayerController playerController; // 플레이어의 점수 정보에 접근하기 위해

    private void Start()
    {
        // 플레이어가 태그인 오브젝트를 찾아서 플레이어 컨트롤러 컴포넌트 가져오기
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪힌 오브젝트의 태그가 player면
        if (collision.CompareTag("Player"))
        {
            if (playerController != null)
                playerController.MagnetTime();
            OnDie();
        }
    }

    public void OnDie()
    {
        // 이 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
