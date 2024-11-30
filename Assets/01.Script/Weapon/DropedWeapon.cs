using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedWeapon : MonoBehaviour
{
    [SerializeField]GunData myData;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<WeaponManager>())
        {
            WeaponManager weaponManager = other.GetComponentInParent<WeaponManager>();
            weaponManager.PickUpWeapon(myData);
            Destroy(gameObject);
        }
    }
}
