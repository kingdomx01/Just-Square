using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleEventBuyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //questionDialog = GameObject.Find("QuestionDialog").gameObject;
    }
    private void Update()
    {
       
    }
    //public void BuyItem()
    //{
    //    dialogGameObject = Instantiate(questionDialog,transform.position,Quaternion.identity);
    //    dialogGameObject.transform.SetParent(gameObject.transform.parent);
    //    dialogGameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    //    GetComponent<ShopItem>().ItemBuying = EventSystem.current.currentSelectedGameObject.gameObject;
    //}
    //public void NoAnswer()
    //{
    //    Destroy(dialogGameObject);
    //    GetComponent<ShopItem>().ItemBuying = null;
    //}
    public void BuyItem()
    {
        GetComponent<ShopWeapon>().BuyItem(EventSystem.current.currentSelectedGameObject.gameObject);   
    }
}
