using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Data", order = 51)]
public class EnemyStats : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private int coinDrop;
    [Tooltip("Is this a melee character?")]
    [SerializeField] private bool meleeEnemy;
    [Tooltip("Is this a boss ?")]
    [SerializeField] private bool bossEnemy;
    [SerializeField] private bool dropItem;
    [SerializeField] private float itemDropRate;
    [SerializeField] private List<GameObject> itemDrop;

    public int Health { get { return health; }set { health = value; } }
    public int Damage { get { return damage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float AttackRange { get { return attackRange; } }
    public bool MeleeEnemy { get { return meleeEnemy; } }
    public bool BossEnemy { get { return bossEnemy; } }
    public int CoinDrop { get { return coinDrop; } }

    public bool DropItem { get { return dropItem; } }
    public float ItemDropRate { get { return itemDropRate; } }

    public List<GameObject> ItemDrop { get { return itemDrop; } }
}
