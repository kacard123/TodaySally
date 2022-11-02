using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultScore : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = SubGameManager.instance.getscore();
    }
}