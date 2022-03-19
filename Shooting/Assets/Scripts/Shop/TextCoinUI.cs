using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCoinUI : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;


    private void Update()
    {
        coinText.text = GameManager.Instance.AmountOfCoin.ToString();
    }
}
