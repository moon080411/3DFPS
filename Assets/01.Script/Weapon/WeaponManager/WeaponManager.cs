using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    private GameObject[] nowWeapon = new GameObject[2];

    private WeaponStorge _weaponStorge;

    public UnityEvent<Sprite> OnWeaponSwap;
    public UnityEvent OnMultipleWeapons;
    public UnityEvent OnWeaponPickUp;

    [SerializeField] private Transform _weaponTrans1;
    [SerializeField] private Transform _weaponTrans2;

    [SerializeField] private GunData _startGun;

    private void Awake()
    {
        _weaponStorge = new WeaponStorge();
        AddWeaponData(_startGun);
        SwapWeapon(_startGun);
    }

    public void ToggleWeaponVisibility(bool v)
    {
        if (v)
        {
            SwapWeapon(GetCurrentWeapon());
        }
        nowWeapon[0].SetActive(v);
        nowWeapon[1].SetActive(v);
    }
    public GunData GetCurrentWeapon()
    {
        return _weaponStorge.GetCurrentWeapon();
    }

    private void SwapWeapon(GunData weaponData)
    {
        if(nowWeapon != null)
        {
            Destroy(nowWeapon[0]);
            Destroy(nowWeapon[1]);
        }
        if (weaponData.isDouble)
        {
            nowWeapon[0] = Instantiate(weaponData.weapon[0]);
            nowWeapon[0].transform.position += _weaponTrans1.position;
            nowWeapon[0].transform.rotation = _weaponTrans1.transform.rotation;
            nowWeapon[0].transform.parent = _weaponTrans1;

            nowWeapon[1] = Instantiate(weaponData.weapon[1]);
            nowWeapon[1].transform.position += _weaponTrans2.position;
            nowWeapon[1].transform.rotation = _weaponTrans2.transform.rotation;
            nowWeapon[1].transform.parent = _weaponTrans2;
        }
        else
        {
            nowWeapon[0] = Instantiate(weaponData.weapon[0]);
            nowWeapon[0].transform.position += _weaponTrans1.position;
            nowWeapon[0].transform.rotation = _weaponTrans1.transform.rotation;
            nowWeapon[0].transform.parent = _weaponTrans1;
        }
        OnWeaponSwap?.Invoke(weaponData.weaponInfoSprite);
    }

    public void PickUpWeapon(GunData weaponData)
    {
        AddWeaponData(weaponData);
        OnWeaponPickUp?.Invoke();
    }
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SwapWeapon();
        }
    }
    private void AddWeaponData(GunData weaponData)
    {
        if (!_weaponStorge.AddWeaponData(weaponData))
        {
            return;
        }
        if (_weaponStorge.WeaponCount == 2)
        {
            OnMultipleWeapons?.Invoke();
        }
    }

    private void SwapWeapon()
    {
        if (_weaponStorge.WeaponCount <= 0) return;
        SwapWeapon(_weaponStorge.SwapWeapon());
    }
}
