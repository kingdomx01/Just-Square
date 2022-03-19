using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
struct Item
{
    public Sprite imageItem;
    public WeaponStats weaponStats;
}

public class ShopWeapon : MonoBehaviour
{
    [SerializeField] private int coin;
    [SerializeField] private GameObject itemBuying;
    public GameObject ItemBuying { set { itemBuying = value; }get { return itemBuying; } }
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private TMP_Text notification;
    [SerializeField]  List<Item> itemUI = new List<Item>();
    [SerializeField] private List<GameObject> itemGameObject = new List<GameObject>();
    [SerializeField] private List<WeaponStats> weaponList = new List<WeaponStats>();
    private List<int> weaponBought = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        coin = GameManager.Instance.AmountOfCoin;
        notification.text = "";
        for (int i =0;i < itemUI.Count;i++)
        {
            GameObject itemPanelGameobject = Instantiate(itemPanel);
            itemPanelGameobject.transform.SetParent(gameObject.transform,false);
            itemPanelGameobject.name = i.ToString();
            itemPanelGameobject.GetComponent<ItemUI>().DamageText.text = "Damage : " + itemUI[i].weaponStats.Damage.ToString();
            itemPanelGameobject.GetComponent<ItemUI>().SpeedShootText.text = "Speed : " + itemUI[i].weaponStats.AttackSpeed.ToString();
            itemPanelGameobject.GetComponent<ItemUI>().RatioCritDamageText.text = "Crit : " + itemUI[i].weaponStats.RatioCritDamage.ToString() + "%";
            itemPanelGameobject.GetComponent<ItemUI>().NameItem.text = itemUI[i].weaponStats.Name.ToString();
            if (Save.Instance.weaponHasOwned[i].hasOwned == true)
            {
                itemPanelGameobject.GetComponent<ItemUI>().PriceText.text = "Equip";
                weaponBought.Add(i);
            }
            else
            {
                itemPanelGameobject.GetComponent<ItemUI>().PriceText.text = "Price : " + itemUI[i].weaponStats.Price.ToString();
            }
            itemPanelGameobject.GetComponent<ItemUI>().ImageItem.sprite = itemUI[i].imageItem;
            itemGameObject.Add(itemPanelGameobject);
            weaponList.Add(itemUI[i].weaponStats);
        }
    }
    public void BuyItem(GameObject itemBuy)
    {
        itemBuying = itemBuy;
        for (var i =0;i < weaponList.Count;i++)
        {
            if (weaponList[i].ID.ToString() == itemBuy.name) //TODO: change by ID
            {
                if (Save.Instance.weaponHasOwned[i].hasOwned == false)
                {
                    if (coin > weaponList[i].Price)
                    {
                        notification.text = "Buy " + weaponList[i].Name + " successfully";
                        weaponList[i].Bought = true;
                        itemGameObject[i].GetComponent<ItemUI>().PriceText.text = "Equip";
                        weaponBought.Add(i);
                        Save.Instance.gameData.SetWeapon(i, itemBuy.name, true);//bug
                        GameManager.Instance.AmountOfCoin -= weaponList[i].Price;
                    }
                    else
                    {
                        notification.text = "You're still have " + Mathf.Abs(coin - weaponList[i].Price) + " coin to buy it";
                    }
                }
                else
                {
                    foreach (int weapon in weaponBought)
                    {
                        if (weapon != Int32.Parse(itemBuy.name))
                        {
                            itemGameObject[weapon].GetComponent<ItemUI>().PriceText.text = "Equip";
                        }
                        else
                        {
                            SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.audio[4]);
                            itemGameObject[weapon].GetComponent<ItemUI>().PriceText.text = "Equipped";
                        }
                    }
                    FindObjectOfType<WeaponManager>().CurrentIDWeapon = Int32.Parse(itemBuy.name);
                    FindObjectOfType<WeaponManager>().CheckCurrentWeapon = true;
                }
            }
        }
    }
}
