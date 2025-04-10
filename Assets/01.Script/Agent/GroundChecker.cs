using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGround = false;
    [SerializeField] private Vector3 CheckerBoxSize;
    [SerializeField] private LayerMask ground;
    private void Update()
    {
        GroundCheck();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, CheckerBoxSize);
        
        Gizmos.color = Color.white;

    }
    private bool GroundCheck()
    {
        return isGround =  Physics.OverlapBox(transform.position,CheckerBoxSize,transform.rotation, ground).Length > 0;
    }
}
