using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public static Bird instance;

    float speed;
    public float relativeSpeed;
    public float max = 3;
    public float min = -4;
    public float yspeed;
    public GameObject bridPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private float sign = -1;
    private bool up = false;
    private Transform target;
    private float spawRate;
    private float timeafterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        speed = SubGameManager.instance.getspeed();
        target = FindObjectOfType<PlayerController>().transform;
        timeafterSpawn = 0f;
        spawRate = Random.RandomRange(spawnRateMin, spawnRateMax);

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.instance.isboost)
        {
            transform.Translate(Vector3.right * (speed - relativeSpeed) * Time.deltaTime);

            if (transform.position.y < max && up == false)
            {

                transform.position += new Vector3(0, sign * Time.deltaTime * yspeed, 0);
                if (transform.localPosition.y > max)
                {
                    up = true;
                }
            }
            else if (transform.position.y > min && up == true)
            {

                transform.position += new Vector3(0, -sign * Time.deltaTime * yspeed, 0);
                if (transform.localPosition.y < min)
                {
                    up = false;
                }

            }


        }

        else if (PlayerController.instance.isboost)
        {
            transform.Translate(Vector3.right * (speed * 12 / 7 - relativeSpeed) * Time.deltaTime);
            if (transform.position.y < max && up == false)
            {

                transform.position += new Vector3(0, sign * Time.deltaTime * yspeed, 0);
                if (transform.localPosition.y > max)
                {
                    up = true;
                }
            }
            else if (transform.position.y > min && up == true)
            {

                transform.position += new Vector3(0, -sign * Time.deltaTime * yspeed, 0);
                if (transform.localPosition.y < min)
                {
                    up = false;
                }

            }

        }

        timeafterSpawn += Time.deltaTime;
        if(timeafterSpawn >= spawRate)
        {
            timeafterSpawn = 0;
            GameObject brid = Instantiate(bridPrefab, transform.position, transform.rotation);
            // brid.transform.LookAt(target);
            spawRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
