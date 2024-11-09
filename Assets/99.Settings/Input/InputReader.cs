using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Input;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{

    private Input _input;

    public Vector2 movement = Vector2.zero;
    public event Action<Vector2> OnMove;
    public event Action OnJumpKeyEvent;

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
}
