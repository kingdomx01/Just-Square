using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleItemStats : MonoBehaviour
{
    [SerializeField] private CharacterStats data;
    private float health;
    public float Health { get { return health; } }
    private int armor;
    private float speed;
    public float Speed { get { return speed; } }
    private int stack;
    public void Awake()
    {
        health = data.Health;
        armor = data.Armor;
        speed = data.Speed;
    }
    public void Start()
    {
        foreach (Store item in Save.Instance.itemCollected)
        {
            StatIncrease(item.itemStats, item.stack);
        }
    }
    public void StatIncrease(ItemStats itemStats, int stack)
    {
        int healthIncreaseTemp = Mathf.FloorToInt(health * (itemStats.PercentHeath / 100) * stack);
        health += healthIncreaseTemp;
        int speedIncreaseTemp = Mathf.FloorToInt(speed * (itemStats.PercentSpeed / 100) * stack);
        speed += speedIncreaseTemp;
    }
}
