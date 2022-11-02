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
        rect = GetComponent<RectTransform>(); // RectTransform : ���簢���� ��ġ, ũ��, ��Ŀ �� �ǹ� ����
    }

    private void Update()
    {
        // ��Ŀ �������� �������� �� �ǹ� ��ġ��
        rect.anchoredPosition = new Vector2(HpgameObject.fillAmount * 743.0f, 0.0f); 
    }
}
