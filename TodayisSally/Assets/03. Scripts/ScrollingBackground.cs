using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    float speed;
    public float relativeSpeed;
    int startIndex;
    int endIndex;
    public float dis;
    public Transform[] sprites;

    void Start()
    {
        speed = SubGameManager.instance.getspeed(); // SubGameManager의 getspeed() 메서드를 싱글턴 패턴으로 접근
        startIndex = 0;
        endIndex = 3;
    }

    
    void LateUpdate()
    {
        Move();
        Scrolling();
    }

    private void Move()
    {
        // SubGameManager의 bool 값인 isGameover를 싱글턴 패턴으로 선언한다면 반환한다.
        if (SubGameManager.instance.isGameover) return; 
        // 게임 오브젝트의 위치에서 상대적인 Vecotr3의 오른쪽으로 이동시킨다. 
        transform.Translate(Vector3.right * (speed - relativeSpeed) * Time.deltaTime);
    }

    private void Scrolling() // 배경이 넘어가는 방향과 위치 값의 유효 범위
    {
        if(sprites[startIndex].position.x < Camera.main.transform.position.x - dis) // 이미지가 x축으로 움직이는 방향이 메인 카메라의 x축 위치보다 작다면
        {
            // Vector3 backSpritePos의 값은 이미지(sprites)의 부모의 위치 기준으로 설정
            // 따라서 오브젝트의 인스펙터의 트랜스폼에 나오는 숫자와 일치한다
            Vector3 backSpritePos = sprites[endIndex].localPosition;
            //sprites[startIndex]의 위치(부모 위치 기준일 때의 값) 
            sprites[startIndex].transform.localPosition = backSpritePos + Vector3.right * dis;

            int endIndexSave = endIndex;
            endIndex = startIndex;
            startIndex = (endIndexSave - 1 == -1) ? sprites.Length - 1 : endIndexSave - 1;
        }
    }
}
