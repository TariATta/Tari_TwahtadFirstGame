using UnityEngine;
using UnityEngine.InputSystem;

public class FuntimeControl : MonoBehaviour
{
    private MyInputAction myInputAction;
    private InputAction Move;

    private void Awake()
    {
        myInputAction = new MyInputAction();
    }

    private void OnEnable()
    {
        Move = myInputAction.Player.Move;
        Move.Enable();
    }

    private void OnDisable()
    {
        Move.Disable();
    }

    private void FixedUpdate()
    {
        Debug.Log("Movement Values " + Move.ReadValue<Vector2>());
    }
}
