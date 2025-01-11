using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cursor = UnityEngine.Cursor;

public class CamMove : MonoBehaviour
{
    [SerializeField] float turnSpeed = 10;
    private bool cursorIsLocked = false;

    private void Start()
    {
        CursorLockChenge();
    }
    private void Update()
    {
        Vector2 r = Pointer.current.delta.ReadValue();
        float rotationX = -r.y * turnSpeed * Time.deltaTime;
        float rotationY = r.x * turnSpeed * Time.deltaTime;

        Vector3 changedEuler = transform.eulerAngles;
        Vector3 changedParentEuler = transform.parent.eulerAngles;

        if (changedEuler.x > 180f) changedEuler.x -= 360f;

        changedEuler.x = Mathf.Clamp(changedEuler.x + rotationX, -53f, 72f);
        changedParentEuler.y += rotationY;

        
        transform.eulerAngles = changedEuler;
        transform.parent.eulerAngles = changedParentEuler;
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            CursorLockChenge();
        }
    }
    private void CursorLockChenge()
    {
        if(cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            cursorIsLocked = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            cursorIsLocked = true;
        }
    }
}
