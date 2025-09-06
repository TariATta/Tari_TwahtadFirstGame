using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerHH : MonoBehaviour
{
    public static MyInputAction inputActions = new MyInputAction();
    public static event Action<InputActionMap> actionMapChange;
    void Start()
    {
        ToggleActionMap(inputActions.Player);
    }

    // Update is called once per frame
    public static void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
            return;

        inputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
}
