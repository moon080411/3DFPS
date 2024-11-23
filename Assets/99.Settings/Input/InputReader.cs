using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Input;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{

    private Input _input;

    public Vector2 movement;
    public event Action<Vector2> OnMove;
    public event Action OnJumpKeyEvent;
    public event Action OnZoomKeyEvent;
    public event Action<bool> OnRunEvent;

    private void OnEnable()
    {
        if (_input == null)
        {
            _input = new Input();
        }
        _input.Player.SetCallbacks(this);
        _input.Player.Enable();

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) OnJumpKeyEvent?.Invoke();
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        OnMove?.Invoke(movement);
    }
    private void OnDisable()
    {
        _input.Player.Disable();
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        if(context.performed) OnZoomKeyEvent?.Invoke();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.performed) OnRunEvent?.Invoke(true);
        if(context.canceled) OnRunEvent?.Invoke(false);
    }
}
