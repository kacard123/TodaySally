using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSizeItem : MonoBehaviour
{
    public int score;
    bool isCrashed;
    float dis;
    Vector3 target;
    // Animator animator;

    private void Start()
    {
        // animator = GetComponent<Animator>();
        isCrashed = false;
        dis = 2.5f;
    }

    private void Update()
    {
        //if (SubGameManager.instance.ismagatic && !isCrashed)
        //{
        //    //target = Pet.instance.transform.position;
        //    if (Vector3.Distance(target, transform.position) < dis)
        //        transform.position = Vector3.MoveTowards(transform.position, target, 0.35f);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isCrashed)
        {
            // isCrashed = true;
            if(collision.gameObject.tag == "Player")
            {
                // gameObject.layer = 13;
                SubGameManager.instance.updateScore(score);
                SoundAllmanager.instance.PlayOnGetFlyingBearJelly();
                //animator.SetTrigger("Die");
                gameObject.SetActive(false);
            }
        }

    }
}
