using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunAttack : MonoBehaviour
{
    [SerializeField] private LayerMask myEnemy;
    public void Shot(Vector3 myPos , Vector3 AttackPos ,float distance,int damage)
    {
        RaycastHit hit;
        Physics.Raycast(new Ray(myPos, AttackPos), out hit , distance , myEnemy);
        if (hit.collider == null)
        {
            Debug.Log("hit collider is null");
            return;
        }
        if(hit.transform.TryGetComponent(out IHitable hitable))
        {
            print("this has ihitable");
            hitable.GetHit(damage);
        }
        else
        {
            print("notthing");
        }
        
    }
}
