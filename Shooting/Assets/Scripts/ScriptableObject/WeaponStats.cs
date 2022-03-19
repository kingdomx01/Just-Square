using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon Data", order = 51)]
public class WeaponStats : ScriptableObject
{
    public enum TypeGun
    { 
        Rifle,
        Shotgun
    }
    [SerializeField] private int iD;
    [SerializeField] private string name;
    [SerializeField] private int damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float ratioCritDamage;
    [SerializeField] private TypeGun typeGun;
    [SerializeField] private int price;
    [SerializeField] private bool bought;
    [SerializeField] private GameObject weapon;

    public int ID { set { iD= value; } get { return iD; } }
    public string Name { get { return name; } }
    public int Damage { get { return damage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float RatioCritDamage { get { return ratioCritDamage; } }
    public TypeGun _TypeGun { get { return typeGun; } }

    public int Price { get { return price; } }
    public bool Bought { set { bought = value; } }
    public GameObject Weapon { get { return weapon; } }
}
