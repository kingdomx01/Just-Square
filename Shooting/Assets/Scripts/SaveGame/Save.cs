using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private static Save instance = null;
    public static Save Instance { get { return instance;}set { instance = value; } }
    public GameData gameData;
    public int coin;
    public int IdWeaponCurrent;
    public List<Store> itemCollected = new List<Store>();
    public Store[] weaponHasOwned;
    private void Awake()
    {
        // prevent multiple initialization 
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else { Destroy(gameObject); }

        // Load 
        LoadData();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameData.coin = GameManager.Instance.GetCoin();
            GameDataManager.SaveMethod(gameData);
            Debug.Log("Save successful !");
        }
    }
    void OnApplicationQuit()
    {
        SaveMethod();
    }
    public int GetCoin()
    {
        return coin;
    }
    public void SaveMethod()
    {
        gameData.item = itemCollected;
        gameData.weapon = weaponHasOwned;
        gameData.IdWeaponCurrent = IdWeaponCurrent;
        GameDataManager.SaveMethod(gameData);
        Debug.Log("Save successful !");
    }
    private void LoadData()
    {
        gameData = GameDataManager.LoadMethod();
        coin = gameData.coin; // BUG   
        IdWeaponCurrent = gameData.IdWeaponCurrent;
        weaponHasOwned = new Store[gameData.weapon.Length];
        itemCollected = gameData.item;
        weaponHasOwned = gameData.weapon;
    }
}
