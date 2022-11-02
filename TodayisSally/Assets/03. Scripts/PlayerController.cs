using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance; // �̱����� �Ҵ��� ���� ����

    bool isGround = true; // Ground�� ����� �� �Է¹޴� ���� true�� ����
    public bool isboost; // bool ������ �Ű�����
    public bool isbig;
    public bool isreinforce = false; // �÷��̾��� ���� ��ȭ�Ǵ����� bool���� false�� �⺻ ����

    private int jump = 2;
    private float jumpforce = 460.0f; // ������ �Է¹޴� ���� ��

    public MagnetField magnetField;
    
    Animator animator;
    Rigidbody2D rigidbody;

    private void Awake() 
    {
        if (instance == null) // ����ִ� instance�� ���� �ڽ��� �Ҵ�
            instance = this;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody ������Ʈ�� ������ �Ҵ�
        animator = GetComponent<Animator>(); // Animator ������Ʈ�� animator ������ �Ҵ�
        isbig = false;
        isboost = false;
    }

    void Update()
    {
        if (SubGameManager.instance.isGameover) return; // SubGameManager�� isGameover�� ���� ���� �� ��ȯ
        // �÷��̾��� ��ġ ���� ����3�� ������ �������� SubGamaManager�� getspeed�޼��忡�� �Էµ� �ӵ��� ���ư�
        gameObject.transform.Translate(Vector3.right * SubGameManager.instance.getspeed() * Time.deltaTime);
    }

    public void Die()
    {
        animator.SetTrigger("Die"); // �浹 �� �ߵ��Ǵ� �Ķ������ Die �� ����
        rigidbody.velocity = Vector2.zero; // ���������� �Է¹޴� �ӵ��� Vector2 ���⿡�� ��ȿȭ
    }

    public void OnClickJumpButton() // ȭ���� Ŭ���� / ����Ͽ��� ��ġ�� �۵��ϴ� �÷��̾� �������
    {
        if(isGround && !SubGameManager.instance.isGameover) // ���� ����� �� ���ӿ����� �ƴ϶��
        {
            isGround = false;
            animator.SetBool("Grounded", false);
            animator.SetBool("Jump", true);
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector2(0, jumpforce));
            jump--;
        }

        else if(!isGround && jump == 1 && !SubGameManager.instance.isGameover)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Jump2", true);
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector2(0, jumpforce));
            jump--;
        }
    }

    public void DownSlideButton()
    {
        animator.SetBool("Slide", true); // �ִϸ��̼� �Ķ���� setbool �Լ� �� slide ���� true�� �Ҵ�
    }

    public void UpSlideButton()
    {
        animator.SetBool("Slide", false); // �ִϸ��̼� �Ķ���� SetBool �Լ� �� Slide ���� fasle�� �Ҵ�
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jump = 2;
            isGround = true;
            animator.SetBool("Jump", false);
            animator.SetBool("Jump2", false);
            animator.SetBool("Grounded", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!SubGameManager.instance.isGameover) // ���ӿ����� �ƴ� ���
        {
            if(collision.gameObject.tag == "Boost") // �±� ���� Boost�� ���
            {
                isreinforce = true;
                animator.SetBool("Boost", true);
                isboost = true;
                SubGameManager.instance.Boosteffect();
                SoundAllmanager.instance.PlayOnGetItemJelly(); // ������ ������ �ε����� �� ����Ǵ� ����� �ҽ�
            }

            if (collision.gameObject.tag == "Bigger")
            {
                isreinforce = true;
                OnBigger();
                isbig = true;
                Invoke("Offbigger", 3f);
            }
            if (collision.gameObject.tag == "Magnetic")
            {
                SubGameManager.instance.ismagatic = true;
                // Pet.instance.Mgeffect();
            }
            if (collision.gameObject.tag == "Obstacle" && !isreinforce)
            {
                animator.SetTrigger("Hurt");
                SubGameManager.instance.damagedhp(0.03f);
                SoundAllmanager.instance.PlayOnCrashWithBody();
                StopCoroutine(invincibilityeffect());
                StartCoroutine(invincibilityeffect());
                DamageUI.instance.Ondamaged();
            }
            if (collision.gameObject.tag == "Potion")
            {
                SubGameManager.instance.healhp(0.1f);
                SoundAllmanager.instance.PlayOnGetItemJelly();
            }
        }
    }


    public void OnBigger()
    {
        StopCoroutine(biggerscale());
        StartCoroutine(biggerscale());
    }

    void Offbigger()
    {
        isbig = false;
        StopCoroutine(smallerscale());
        StartCoroutine(smallerscale());
        StopCoroutine(invincibilityeffect());
        StartCoroutine(invincibilityeffect());
    }

    public void Offboost()
    {
        isreinforce = false;
        isboost = false;
        animator.SetBool("Boost", false);
        StopCoroutine(invincibilityeffect());
        StartCoroutine(invincibilityeffect());
    }

    IEnumerator biggerscale()
    {
        float time = 0f;
        SoundAllmanager.instance.PlayOnGiganticStart();
        while (time <= 1f)
        {
            yield return new WaitForSeconds(0.001f);
            time += Time.deltaTime * 2f;
            gameObject.transform.localScale = new Vector3(1f + time, 1f + time, 1f);
        }
        gameObject.transform.localScale = new Vector3(1.7f, 1.7f, 1f);

    }

    IEnumerator smallerscale()
    {
        float time = 0f;
        SoundAllmanager.instance.PlayOnGiganticEnd();
        while (time <= 1f)
        {
            yield return new WaitForSeconds(0.001f);
            time += Time.deltaTime * 2f;
            gameObject.transform.localScale = new Vector3(1.7f - time, 1.7f - time, 1f);
        }
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    IEnumerator invincibilityeffect()
    {
        if (isbig || isboost) yield break;
        gameObject.layer = 11;
        isreinforce = false;
        for (int i = 0; i < 5; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.3f);
        }
        gameObject.layer = 8;
        yield break;
    }

    public void Magnet()
    {
        StartCoroutine("Magnetic");
        StopCoroutine("Magnetic");
    }

    IEnumerator Magnetic()
    {
        while (true)
        {
            MagnetTime();
            yield return new WaitForSeconds(2f);
        }
    }

    public void MagnetTime()
    {
        magnetField.magnetTime = true;
    }
}
