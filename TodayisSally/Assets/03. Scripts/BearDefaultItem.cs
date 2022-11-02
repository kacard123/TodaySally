using UnityEngine;

public class BearDefaultItem : MonoBehaviour
{
    public int score;
    bool isCrashed;
    // Animator animator;

    private void Start()
    {
        // animator = GetComponent<Animator>();
        isCrashed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isCrashed)
        {
            //isCrashed = true;
            if(collision.gameObject.tag == "Player")
            {
                gameObject.layer = 13;
                SubGameManager.instance.updateScore(score);
                SoundAllmanager.instance.PlayOnGetFlyingBearJelly();
                // animator.SetTrigger("Die");
                gameObject.SetActive(false);
            }
        }
    }
}
