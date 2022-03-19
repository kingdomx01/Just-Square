using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HandleItemCollected : MonoBehaviour
{
    enum type
    {
        coin,
        item
    }
    private GameObject player;
    [SerializeField] private GameObject textCoinReceiver;
    [SerializeField] private string name;
    [SerializeField] private type chooseType;
    [Header("ID for item")]
    [SerializeField] private int ID;
    [Header("ScripTableObject")]
    [SerializeField] private ItemStats itemStats;
    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
    }
    private void Update()
    {
        if (player == null) return;
        if (Vector2.Distance(player.transform.position, transform.position) < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 8 * Time.deltaTime);
            GetComponent<Rigidbody2D>().isKinematic = true;
            if (Vector2.Distance(player.transform.position, transform.position) < 0.2f)
            {
                HandleItem();
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    private void HandleItem()
    {
        GameObject textGameObject = Instantiate(textCoinReceiver, transform.position, Quaternion.identity);
        textGameObject.GetComponent<TMP_Text>().text = "+" + name;
        GetComponent<Collider2D>().isTrigger = true;
        switch (chooseType)
        {
            case type.coin:
                FindObjectOfType<GameManager>().AmountOfCoin++;
                GameManager.Instance.AmountOfCoin++;
                break;
            case type.item:

                FindObjectOfType<HandleItemStats>().GetComponent<HandleItemStats>().StatIncrease(itemStats, 1);
                FindObjectOfType<Player>().GetComponent<Player>().IncreaseHealth = true;
                var store = new Store();
                if (Save.Instance.itemCollected.Any(x => x.ID == ID) == true)
                {
                    store = Save.Instance.itemCollected.Find(x => x.ID == ID);
                    store.stack++;
                    int index = Save.Instance.itemCollected.IndexOf(Save.Instance.itemCollected.Find(x => x.ID == ID));
                    Save.Instance.itemCollected[index] = store;
                }
                else
                { 
                    store.SetItem(ID, name, true, 1, itemStats);
                    Save.Instance.itemCollected.Add(store);
                }
                FindObjectOfType<UI_Item_Collected>().UpdateAmountOfItemUI(ID);
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
