using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBullet : MonoBehaviour
{
    float speed;
    public float relativeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        speed = SubGameManager.instance.getspeed();
        Destroy(gameObject, 3f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -(speed - relativeSpeed) * Time.deltaTime);
    }
}
