using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    public static DamageUI instance;

    private void Awake()
    {
        if (instance == null) // �̱��� ���� ���������� �ڱ� �ڽ��� �Ҵ�
            instance = this;
        else
            Destroy(gameObject); // �ڱ��ڽ��� �ı�
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f); 
    }

    public void Ondamaged() // ���ǽĿ� ���ؼ� �ߵ��Ǵ� �Լ����� ���� �޼���
    {
        StopCoroutine(Dmeffect());
        StartCoroutine(Dmeffect());
    }

    IEnumerator Dmeffect() // ������Ʈ�� �÷��� ����
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }
}
