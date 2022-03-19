using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelCredit;
    public void StartGame()
    {

        SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.audio[0]);
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    public void ButtonNotFunction()
    {
        SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.audio[0]);
    }
    public void CreaditButton()
    {
        SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.audio[0]);
        panelCredit.SetActive(true);

    }
    public void ExitGame()
    {
        SoundManager.Instance.audioSource.PlayOneShot(SoundManager.Instance.audio[0]);
        Application.Quit();
    }
}
