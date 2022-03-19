using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New type player", menuName = "Player Data", order = 51)]

public class CharacterStats : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int armor;
    [SerializeField] private float speed;
    // Property
    public int Health { get { return health; } }
    public int Armor { get { return armor; } }
    public float Speed { get { return speed; } }
}
