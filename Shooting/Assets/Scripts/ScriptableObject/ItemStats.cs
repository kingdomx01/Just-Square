using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item Data", order = 51)]
public class ItemStats : ScriptableObject
{
    [SerializeField] private float percentHeath;
    [SerializeField] private int percentArmor;
    [SerializeField] private float percentSpeed;

    public float PercentHeath { get { return percentHeath; } }
    public int PercentArmor { get { return percentArmor; } }
    public float PercentSpeed { get { return percentSpeed; } }
}
