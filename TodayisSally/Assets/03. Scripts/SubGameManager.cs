using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubGameManager : MonoBehaviour
{
    public static SubGameManager instance;
    public Image hpbar;
    public TextMeshProUGUI jellyScore;
    public GameObject result;
    public Image newicon;

    public GameObject boosteffectPrefab;

    GameObject[] boosteffect; // boosteffect 의 효과를 담을 게임 오브젝트 배열
    GameObject[] basicjellies; // 기본 아이템의 효과를 가진 게임 오브젝트 배열

    int idx;
    int targetidx;

    static public float speed = 7f;
    public bool isGameover;
    public bool ismagatic;
    int gamescore = 0;
    int bestScore;
    string strScore = "";

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        boosteffect = new GameObject[20];
        for (int i = 0; i < boosteffect.Length; i++)
        {
            //boosteffect[i] = Instantiate(boosteffectPrefab);
            //boosteffect[i].SetActive(false);
        }
    }

    private void OnEnable()
    {
        speed = 7f;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
            PlayerPrefs.SetInt("BestScore", 0);
        isGameover = false;
        ismagatic = false;
        idx = 0;
    }

    void Update()
    {
        if (isGameover) return;
        hpbar.fillAmount -= 0.02f * Time.deltaTime;

        if (hpbar.fillAmount == 0)
        {
            isGameover = true;
            speed = 0f;
            PlayerController.instance.Die();
            SoundAllmanager.instance.PlayOnGameEnd();
            Invoke("GameStop", 2f);
        }
    }

    public void healhp(float percent)    {
        hpbar.fillAmount += percent;
    }

    public void damagedhp(float percent)
    {
        hpbar.fillAmount -= percent;
    }

    public void updateScore(int score)
    {
        gamescore += score;
        strScore = string.Format("{0:#,##0}", gamescore);
        jellyScore.text = strScore;
    }

    public void GameStop() // 게임 중지 후 플레이를 끝내는 메서드
    {
        isGameover = true; // 게임오버 값 true
        speed = 0f; // 스피드 값 0
        if (gamescore > PlayerPrefs.GetInt("BestScore")) // 게임점수가 최고 점수보다 클 때
            PlayerPrefs.SetInt("BestScore", gamescore); // PlayerPrefs 클래스는 유니티에서 제공해주는 데이터 관리 클래스이다.
                                                        //해당 클래스는 int, float, string, bool 타입의 변수를 저장하고 로드하는 기능을 제공한다.
        result.SetActive(true); // 게임의 결과는 나타내는 게임 오브젝트 result의 활성화
        SoundAllmanager.instance.PlayOnResult(); // 게임의 결과를 알리는 메서드 발동
    }

    public void Boosteffect()
    {
        speed = 12f;
        StopAllCoroutines();
        StartCoroutine(BoostTime());
    }

    void Offboosteffect()
    {
        speed = 7f;
        PlayerController.instance.Offboost();
        StopCoroutine(BoostTime());
    }

    public Vector3 GetTargetjellyPos()
    {
        basicjellies = GameObject.FindGameObjectsWithTag("BasicItem");
        if (basicjellies.Length == 0) return Vector3.zero;
        targetidx = basicjellies.Length + 1;
        for (int i = 0; i < basicjellies.Length; i++)
        {
            if (PlayerController.instance.transform.position.x + 10f < basicjellies[i].transform.position.x && PlayerController.instance.transform.position.x + 15f > basicjellies[i].transform.position.x)
            {
                targetidx = i;
            }
        }
        if (basicjellies.Length <= targetidx) return Vector3.zero;
        Vector3 targetpos = basicjellies[targetidx].transform.position;
        return targetpos;
    }

    public void OffTargetjelly()
    {
        basicjellies[targetidx].SetActive(false);
    }

    IEnumerator BoostTime()
    {
        for (int i = 0; i < 50; i++)
        {
            //if (idx > boosteffect.Length - 1) idx = 0;
            //boosteffect[idx++].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        Offboosteffect();
        yield break;
    }

    public float getspeed()
    {
        return speed;
    }

    public string getscore()
    {
        return strScore;
    }

    public string getBestscore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        if (bestScore == gamescore)
        {
            newicon.gameObject.SetActive(true);
        }
           
        else
        {
            newicon.gameObject.SetActive(false);
        }
            
        return string.Format("{0:#,##0}", bestScore);
    }
}
