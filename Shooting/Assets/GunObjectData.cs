using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunObjectData : MonoBehaviour
{
    [SerializeField] private List<GameObject> weapon = new List<GameObject>();
    public List<GameObject> Weapon
    {
        get { return weapon; }
    }
}
