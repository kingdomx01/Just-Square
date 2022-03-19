using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int amountOfCoin;
    public int AmountOfCoin { get { return amountOfCoin; }set { amountOfCoin = value; } }

    // True to load game
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject continueText;
    [SerializeField] private GameObject panelPauseGame;
    // point to Spawn weapon;
    // Weapon

    //-------------
    private bool toggle = false;
    public bool GameOver = false;
    private float waitTime = 1;
    private void Awake()
    {
        panelPauseGame.SetActive(false);
        panelGameOver.SetActive(false);
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }      
    }
    private void Start()
    {
        amountOfCoin = Save.Instance.GetCoin();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPauseGame.SetActive(!toggle);
            if(toggle == false)
            {
                Time.timeScale = 0;
            }
            else { Time.timeScale = 1; }
            FindObjectOfType<Player>().GetComponentInChildren<RotationGun>().enabled = toggle;
            FindObjectOfType<Player>().GetComponent<Shooting>().enabled = toggle;
            toggle = !toggle;
        }
        Save.Instance.gameData.coin = amountOfCoin; //Bug
        if (GameOver == true)
        {
            continueText.gameObject.SetActive(false);
            waitTime -= Time.deltaTime;
            panelGameOver.SetActive(true);
            if (waitTime <= 0)
            {
                continueText.gameObject.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    waitTime = 1;   
                    StartCoroutine(SwitchScreen());
                }
            }
        }
    }
    public void SetCoin(int coin)
    {
        amountOfCoin = coin;
    }
    // To Save
    public int GetCoin()
    {
        return amountOfCoin;
    }
    IEnumerator SwitchScreen()
    {
        yield return new WaitForSeconds(1);
        panelGameOver.SetActive(false);
        GameOver = false;
        SceneManager.LoadScene(sceneName: "Lobby");
    }
}
