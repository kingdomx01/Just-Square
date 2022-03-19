using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Store{
    public int ID;
    public string name;
    public bool hasOwned;
    public int stack;
    public ItemStats itemStats;
    public void SetItem(int ID, string name, bool hasOwned, int stack,ItemStats itemStats)
    {
        this.ID = ID;
        this.name = name;
        this.hasOwned = hasOwned;
        this.stack = stack;
        this.itemStats = itemStats;
    }

}

public class GameData
{
    public int coin;
    public int IdWeaponCurrent;
    public List<Store> item;
    public Store[] weapon = new Store[8];
    public void SetWeapon(int ID, string name, bool hasOwned)
    {
        weapon[ID].ID = ID;
        weapon[ID].name = name;
        weapon[ID].hasOwned = hasOwned;
    }
}
