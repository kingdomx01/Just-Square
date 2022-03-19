using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject arm;
    private int _currentIDWeapon;
    public int CurrentIDWeapon { set { _currentIDWeapon = value; } }
    private GameObject weaponGameObject;
    private bool checkCurrentWeapon;
    public bool CheckCurrentWeapon { set { checkCurrentWeapon = value; } }
    private void Start()
    {
        _currentIDWeapon = Save.Instance.IdWeaponCurrent;
        HandleSwitchWeapon();
    }
    private void Update()
    {
        if (checkCurrentWeapon == true)
        {
            HandleSwitchWeapon();
            checkCurrentWeapon = false;
        }
    }

    private void HandleSwitchWeapon()
    {
        foreach (GameObject weapon in FindObjectOfType<GunObjectData>().GetComponent<GunObjectData>().Weapon)
        {
            if (weapon.GetComponent<Gun>().Data.ID == _currentIDWeapon)
            {
                weapon.transform.gameObject.SetActive(true);
                FindObjectOfType<RotationGun>().Gun = weapon;
                FindObjectOfType<Shooting>().ani = weapon.GetComponent<Animator>();
                FindObjectOfType<Shooting>().point = weapon.transform.GetChild(0);
                FindObjectOfType<Shooting>().WeaponData = weapon.GetComponent<Gun>().Data;
                Save.Instance.IdWeaponCurrent = _currentIDWeapon;
            }
            else
            {
                weapon.transform.gameObject.SetActive(false);
            }
        }
    }
}
