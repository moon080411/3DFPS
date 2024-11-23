using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropedWeapon : MonoBehaviour
{
    [SerializeField]GunData myData;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out WeaponStorage weaponStorage))
        {
            weaponStorage.WeaponAdd(myData);
        }
    }
}
