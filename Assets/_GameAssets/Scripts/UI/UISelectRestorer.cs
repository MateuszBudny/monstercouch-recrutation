using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UISelectRestorer : MonoBehaviour
{
    [SerializeField]
    private EventSystem eventSystem;

    public bool IsCurrentDeviceGamepadOrKeyboard => currentInputDevice is Gamepad || currentInputDevice is Keyboard;

    private InputDevice currentInputDevice;
    private InputDevice lastUsedDevice;
    private GameObject lastSelected;
    private double lastMouseUpdateTime;

    private void Update()
    {
        TryToSaveLastSelected();
        TryToResetSelected();
        CheckForDeviceChange();
    }

    private void TryToSaveLastSelected()
    {
        // save last selected if it exists (so the plyer is navigating with a keyboard or a controller)
        if(eventSystem.currentSelectedGameObject)
        {
            lastSelected = eventSystem.currentSelectedGameObject;
        }
    }

    private void TryToResetSelected()
    {
        if(currentInputDevice is Mouse)
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }

    private void CheckForDeviceChange()
    {
        if(InputSystem.GetDevice<Keyboard>().wasUpdatedThisFrame)
        {
            currentInputDevice = Keyboard.current;
        }
        // I don't know why, but Mouse.current.wasUpdatedThisFrame is always true, so I had to use this workaround
        else if(!Mathf.Approximately((float)Mouse.current.lastUpdateTime, (float)lastMouseUpdateTime))
        {
            lastMouseUpdateTime = Mouse.current.lastUpdateTime;
            currentInputDevice = Mouse.current;
        }
        else if(Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame)
        {
            currentInputDevice = Gamepad.current;
        }
        else
        {
            currentInputDevice = lastUsedDevice;
        }

        if(currentInputDevice != null && currentInputDevice != lastUsedDevice)
        {
            lastUsedDevice = currentInputDevice;
            CursorManager.Instance.NoMouseMode(IsCurrentDeviceGamepadOrKeyboard);
            ManageSelectedOnInputDeviceChanged();
        }
    }

    private void ManageSelectedOnInputDeviceChanged()
    {
        if(currentInputDevice is Keyboard || currentInputDevice is Gamepad)
        {
            // Restore last selected when switching to controller
            if(lastSelected != null && eventSystem.currentSelectedGameObject == null)
            {
                eventSystem.SetSelectedGameObject(lastSelected);
            }
        }
        else
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }
}
