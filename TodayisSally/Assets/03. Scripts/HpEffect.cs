using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpEffect : MonoBehaviour
{
    public Image HpgameObject;
    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>(); // RectTransform : 직사각형의 위치, 크기, 앵커 및 피벗 정보
    }

    private void Update()
    {
        // 앵커 참조절을 기준으로 한 피벗 위치값
        rect.anchoredPosition = new Vector2(HpgameObject.fillAmount * 743.0f, 0.0f); 
    }
}
