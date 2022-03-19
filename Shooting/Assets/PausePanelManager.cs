using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelManager : MonoBehaviour
{
    public void Update()
    {
        Time.timeScale = 0;
        FindObjectOfType<Player>().GetComponentInChildren<RotationGun>().enabled = false;
        FindObjectOfType<Player>().GetComponent<Shooting>().enabled = false;
    }
    public void BackButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<Player>().GetComponentInChildren<RotationGun>().enabled = true;
        FindObjectOfType<Player>().GetComponent<Shooting>().enabled = true;
    }
    public void ExitAndSaveButton()
    {
        Save.Instance.SaveMethod();
        Application.Quit();
    }
}
