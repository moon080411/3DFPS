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
        Physics.Raycast(myPos, AttackPos, out hit , distance , myEnemy);
        if(hit.transform.TryGetComponent(out IHitable hitable))
        {
            hitable.GetHit(damage);
        }
        else
        {

        }
        
    }
}
