using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Rigidbody2D rigid; // 리지드바디 변수 선언
    float angle = -700.0f; // 앵글 값
    float force = 40000.0f; // 물리적인 힘 값
    bool isrotate; // 회전시에 bool 값을 받는 변수명
    bool isCrashed; // 충돌시에 bool 값을 받는 변수명
    int rot;

    void Start()
    {
        rot = Random.Range(0, 2); // 정수 값을 입력받는 rot 변수에 0~2사이의 정수 중 임의의 값을 할당(2는 제외)
        rigid = this.GetComponent<Rigidbody2D>(); // 변수 rigid에 컴포넌트 리지드바디 할당
        isrotate = false;
        isCrashed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) // 충돌 시 정보를 받는 트리거 메서드
    {
        if(SubGameManager.instance.isGameover == false) // 게임오버가 아닐 시에
        {
            if(collision.gameObject.tag == "Player" && PlayerController.instance.isreinforce && isCrashed == false) // 충돌한 게임 오브젝트의 태그가 Player이고 
            {                                                                                               // bool 값인 isreinforce(힘의 강화 관련)의 디폴트값이 false이며 충돌하지 않은 상태에서
                isCrashed = true;
                StopCoroutine(Onrotate()); //Onrotate메서드 코루틴 중지
                StartCoroutine(Onrotate()); // 코루틴 함수 발동
                rigid.constraints = RigidbodyConstraints2D.None; // 리지드바디 모션의 제한 관련 -> 기본적으로 None 값이 할당되어 모든 축에서 자유롭게 움직임 가능
                rigid.AddForce(Vector2.right * force * Time.deltaTime);
                SoundAllmanager.instance.CrashWithObstacle(); // 장애물 충돌 시 발동되는 사운드 관련 메서드

                rigid.velocity = Vector3.zero;
            }
        }
    }

    IEnumerator Onrotate() // 코루틴 발동 상태
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
