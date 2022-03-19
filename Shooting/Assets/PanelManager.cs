using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
   public void TurnOffPanel()
    {
        FindObjectOfType<PanelManager>().gameObject.SetActive(false);
    }
}
