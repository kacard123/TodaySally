using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    public static DamageUI instance;

    private void Awake()
    {
        if (instance == null) // 싱글턴 패턴 전역변수에 자기 자신을 할당
            instance = this;
        else
            Destroy(gameObject); // 자기자신을 파괴
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f); 
    }

    public void Ondamaged() // 조건식에 의해서 발동되는 함수들을 담은 메서드
    {
        StopCoroutine(Dmeffect());
        StartCoroutine(Dmeffect());
    }

    IEnumerator Dmeffect() // 오브젝트의 컬러값 조정
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }
}
