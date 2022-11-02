using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BestScoreButton : MonoBehaviour
{

    private void OnEnable()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = SubGameManager.instance.getBestscore();
    }
}
