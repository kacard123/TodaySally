using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance; // 싱글턴을 할당할 전역 변수

    bool isGround = true; // Ground에 닿았을 때 입력받는 값을 true로 설정
    public bool isboost; // bool 형식의 매개변수
    public bool isbig;
    public bool isreinforce = false; // 플레이어의 힘이 강화되는지의 bool값은 false로 기본 설정

    private int jump = 2;
    private float jumpforce = 460.0f; // 점프시 입력받는 힘의 값

    public MagnetField magnetField;
    
    Animator animator;
    Rigidbody2D rigidbody;

    private void Awake() 
    {
        if (instance == null) // 비어있는 instance의 값에 자신을 할당
            instance = this;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody 컴포넌트를 변수에 할당
        animator = GetComponent<Animator>(); // Animator 컴포넌트를 animator 변수에 할당
        isbig = false;
        isboost = false;
    }

    void Update()
    {
        if (SubGameManager.instance.isGameover) return; // SubGameManager의 isGameover의 값이 참일 때 반환
        // 플레이어의 위치 값은 벡터3의 오른쪽 방향으로 SubGamaManager의 getspeed메서드에서 입력된 속도로 나아감
        gameObject.transform.Translate(Vector3.right * SubGameManager.instance.getspeed() * Time.deltaTime);
    }

    public void Die()
    {
        animator.SetTrigger("Die"); // 충돌 시 발동되는 파라미터의 Die 값 설정
        rigidbody.velocity = Vector2.zero; // 물리적으로 입력받는 속도는 Vector2 방향에서 무효화
    }

    public void OnClickJumpButton() // 화면을 클릭시 / 모바일에선 터치시 작동하는 플레이어 점프기능
    {
        if(isGround && !SubGameManager.instance.isGameover) // 땅에 닿았을 때 게임오버가 아니라면
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
        animator.SetBool("Slide", true); // 애니메이션 파라미터 setbool 함수 중 slide 값을 true로 할당
    }

    public void UpSlideButton()
    {
        animator.SetBool("Slide", false); // 애니메이션 파라미터 SetBool 함수 중 Slide 값을 fasle로 할당
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
        if(!SubGameManager.instance.isGameover) // 게임오버가 아닌 경우
        {
            if(collision.gameObject.tag == "Boost") // 태그 값이 Boost인 경우
            {
                isreinforce = true;
                animator.SetBool("Boost", true);
                isboost = true;
                SubGameManager.instance.Boosteffect();
                SoundAllmanager.instance.PlayOnGetItemJelly(); // 아이템 젤리와 부딪혔을 때 재생되는 오디오 소스
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
