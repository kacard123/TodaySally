using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    //    public static Pet instance;

    //    Animator animator;

    //    GameObject[] gomjellies;
    //    Vector3 targetpos;

    //    float posx;
    //    float posy;
    //    float magneticRange;
    //    float abilityTime;
    //    bool isAbility;
    //    int gomidx;
    //    public GameObject gomjellytPrefab;

    //    private void Awake()
    //    {
    //        if (instance == null) // 변수 instance가 비어있다면
    //            instance = this; // 자기 자신을 할당
    //        gomjellies = new GameObject[6];
    //        gomidx = 0;
    //        isAbility = false;
    //        for (int i = 0; i < gomjellies.Length; i++)
    //        {
    //            gomjellies[i] = Instantiate(gomjellytPrefab);
    //            gomjellies[i].SetActive(false);
    //        }
    //    }

    //    void Start()
    //    {
    //        posx = -1.03f;
    //        posy = 2.39f;
    //        magneticRange = 1f;
    //        animator = GetComponent<Animator>();
    //    }

    //    private void LateUpdate()
    //    {
    //        if (!SubGameManager.instance.ismagatic && PlayerController.instance != null && !isAbility)
    //            gameObject.transform.position = new Vector3(PlayerController.instance.transform.position.x + posx, PlayerController.instance.transform.position.y + posy, transform.position.z);
    //        if (abilityTime > 2.0f && !isAbility && !SubGameManager.instance.ismagatic)
    //            OnAbility();
    //        else
    //            abilityTime += Time.deltaTime;
    //    }

    //    public void Mgeffect()
    //    {
    //        animator.SetBool("Mag", true);
    //        gameObject.layer = 8;
    //        StopCoroutine(MoveToMagpos());
    //        StartCoroutine(MoveToMagpos());
    //    }

    //    void OnAbility()
    //    {
    //        isAbility = true;
    //        StartCoroutine(MoveToAbilitypos());
    //    }

    //    public float getMagneticRange()
    //    {
    //        return magneticRange;
    //    }

    //    IEnumerator MoveToMagpos()
    //    {
    //        float time = 0f;
    //        while (time <= 3f)
    //        {
    //            transform.position = Vector3.MoveTowards(transform.position, new Vector3(PlayerController.instance.transform.position.x + 6.99f, 0, 0), 0.3f);
    //            yield return new WaitForSeconds(0.01f);
    //            time += Time.deltaTime;
    //        }
    //        time = 0f;
    //        animator.SetBool("Mag", false);
    //        while (time <= 1f)
    //        {
    //            transform.position =
    //                Vector3.MoveTowards(transform.position, new Vector3(PlayerController.instance.transform.position.x + posx, PlayerController.instance.transform.position.y + posy, transform.position.z), 0.3f);
    //            yield return new WaitForSeconds(0.01f);
    //            time += Time.deltaTime;
    //        }
    //        SubGameManager.instance.ismagatic = false;
    //        gameObject.layer = 14;

    //        yield break;
    //    }

    //    IEnumerator MoveToAbilitypos()
    //    {
    //        float time = 0f;
    //        targetpos = SubGameManager.instance.GetTargetjellyPos();
    //        if (targetpos == Vector3.zero)
    //        {
    //            isAbility = false;
    //            abilityTime = 0;
    //            yield break;
    //        }
    //        while (time <= 0.3f)
    //        {
    //            transform.position = Vector3.MoveTowards(transform.position, targetpos, 1.0f);
    //            yield return new WaitForSeconds(0.01f);
    //            time += Time.deltaTime;
    //        }
    //        //SubGameManager.instance.OffTargetjelly();
    //        //gomjellies[gomidx].SetActive(true);
    //        //gomjellies[gomidx++].transform.position = targetpos;
    //        if (gomidx > 5) gomidx = 0;
    //        time = 0f;
    //        while (time <= 0.3f)
    //        {
    //            transform.position =
    //                Vector3.MoveTowards(transform.position, new Vector3(Pl
    //                ayerController.instance.transform.position.x + posx, PlayerController.instance.transform.position.y + posy, transform.position.z), 1.0f);
    //            yield return new WaitForSeconds(0.01f);
    //            time += Time.deltaTime;
    //        }
    //        isAbility = false;
    //        abilityTime = 0;
    //        yield break;
    //    }

    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        if (!SubGameManager.instance.isGameover)
    //        {
    //            if (collision.gameObject.tag == "Boost")
    //            {
    //                PlayerController.instance.isreinforce = true;
    //                animator.SetBool("Boost", true);
    //                PlayerController.instance.isboost = true;
    //                SubGameManager.instance.Boosteffect();
    //                SoundAllmanager.instance.PlayOnGetItemJelly();
    //            }
    //            if (collision.gameObject.tag == "Bigger")
    //            {
    //                PlayerController.instance.isreinforce = true;
    //                PlayerController.instance.OnBigger();
    //                PlayerController.instance.isbig = true;
    //                Invoke("Offbigger", 3f);
    //            }
    //            if (collision.gameObject.tag == "Magnetic")
    //            {
    //                SubGameManager.instance.ismagatic = true;
    //                Mgeffect();
    //            }
    //            if (collision.gameObject.tag == "Potion")
    //            {
    //                SubGameManager.instance.healhp(0.1f);
    //                SoundAllmanager.instance.PlayOnGetItemJelly();
    //            }
    //        }
    //    }
    //}
    public float speed; // 펫 스피드
    public float distance; // 펫과 플레이와의 거리
    Transform player; // 플레이어의 위치
    Animator ani;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - player.position.x) > distance)
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
            ani.SetBool("IsWalk", true);
            DirectionPet();
        }

        else
        {
            ani.SetBool("IsWalk", false);
        }
    }

    void DirectionPet()
    {
        if (transform.position.x - player.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

}