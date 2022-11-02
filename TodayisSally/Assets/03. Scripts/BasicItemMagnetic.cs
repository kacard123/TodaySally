using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItemMagnetic : MonoBehaviour
{
    public int score; 
    bool isCrashed;
    float dis;
    Vector3 target;
    public GameObject targett;
    public bool magnetTime;
    private PlayerController playerController;

    void Start()
    {
        isCrashed = false;
        dis = 2.5f;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetTime)
        {                                 
            transform.position = Vector3.MoveTowards(transform.position, targett.transform.position, 0.07f);
        }
    }

    private void OnEnable()
    {
        targett = null;
        magnetTime = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCrashed) 
        {
            // isCrashed = true; 
            if (collision.gameObject.tag == "Player") 
            {
                // gameObject.layer = 13;
                SubGameManager.instance.updateScore(score);
                SoundAllmanager.instance.PlayOnGetJelly(); 
                Destroy(gameObject);
            }
        }

    }
}
