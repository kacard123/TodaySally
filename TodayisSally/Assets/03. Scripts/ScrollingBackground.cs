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
        speed = SubGameManager.instance.getspeed(); // SubGameManager�� getspeed() �޼��带 �̱��� �������� ����
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
        // SubGameManager�� bool ���� isGameover�� �̱��� �������� �����Ѵٸ� ��ȯ�Ѵ�.
        if (SubGameManager.instance.isGameover) return; 
        // ���� ������Ʈ�� ��ġ���� ������� Vecotr3�� ���������� �̵���Ų��. 
        transform.Translate(Vector3.right * (speed - relativeSpeed) * Time.deltaTime);
    }

    private void Scrolling() // ����� �Ѿ�� ����� ��ġ ���� ��ȿ ����
    {
        if(sprites[startIndex].position.x < Camera.main.transform.position.x - dis) // �̹����� x������ �����̴� ������ ���� ī�޶��� x�� ��ġ���� �۴ٸ�
        {
            // Vector3 backSpritePos�� ���� �̹���(sprites)�� �θ��� ��ġ �������� ����
            // ���� ������Ʈ�� �ν������� Ʈ�������� ������ ���ڿ� ��ġ�Ѵ�
            Vector3 backSpritePos = sprites[endIndex].localPosition;
            //sprites[startIndex]�� ��ġ(�θ� ��ġ ������ ���� ��) 
            sprites[startIndex].transform.localPosition = backSpritePos + Vector3.right * dis;

            int endIndexSave = endIndex;
            endIndex = startIndex;
            startIndex = (endIndexSave - 1 == -1) ? sprites.Length - 1 : endIndexSave - 1;
        }
    }
}
