using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    // stats text
    [SerializeField] private int id;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text speedShootText;
    [SerializeField] private TMP_Text ratioCritDamageText;
    [SerializeField] private TMP_Text priceText;
    // infomation text
    [SerializeField] private Image imageItem;
    [SerializeField] private TMP_Text nameItem;
    [SerializeField] private Button button;
    [SerializeField] private bool isBought =false;
    private void Start()
    {
        button.onClick.AddListener(GetComponentInParent<HandleEventBuyItem>().BuyItem);
    }

    public TMP_Text DamageText { set { damageText = value; } get { return damageText; } }
    public TMP_Text SpeedShootText { set { speedShootText = value; } get { return speedShootText; } }
    public TMP_Text RatioCritDamageText { set { ratioCritDamageText = value; } get { return ratioCritDamageText; } }
    public TMP_Text PriceText { set { priceText = value; } get { return priceText; } }
    public Image ImageItem { set { imageItem = value; } get { return imageItem; } }
    public TMP_Text NameItem { set { nameItem = value; } get { return nameItem; } }
    public bool IsBought { set { isBought = value; } get { return isBought; } }
    public int ID { set { id = value; } get { return id; } }
}
