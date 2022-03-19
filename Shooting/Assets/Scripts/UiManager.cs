using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private void Awake()
    {   
        if (FindObjectOfType<UiManager>().transform.GetChild(0) != null) 
        {
            return;
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
