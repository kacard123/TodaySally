using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMoving: MonoBehaviour
{
    float posx = 6.26f;

    // 모든 Update 함수가 호출된 후, 마지막으로 호출
    // 주로 오브젝트를 따라가게 설정한 카메라는 LateUpdate를 사용(카메라가 따라가는 오브젝트가 Update함수 안에서 움직일 경우가 있기 때문).
    void LateUpdate()
    {

        if (PlayerController.instance != null && !SubGameManager.instance.isGameover)
            transform.position = new Vector3(PlayerController.instance.transform.position.x + posx, transform.position.y, transform.position.z);
    }
}
