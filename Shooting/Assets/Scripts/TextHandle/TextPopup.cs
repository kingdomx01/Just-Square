using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    public static void CreatePopup(GameObject text,string content,Transform target)
    {
        GameObject textObject = Instantiate(text,target.transform.position,Quaternion.identity);
        textObject.GetComponent<RectTransform>().anchoredPosition = target.transform.position;
        textObject.GetComponent<TMP_Text>().text = content;
    }
}
