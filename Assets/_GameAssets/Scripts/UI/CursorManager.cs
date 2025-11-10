using System;
using System.Collections;
using UnityEngine;

public class CursorManager : SingleBehaviour<CursorManager>
{
    [SerializeField]
    private CursorLockMode startingCursorLockMode = CursorLockMode.Locked;

    public CursorLockMode CurrentCursorLockMode
    {
        get => currentCursorLockMode;
        set
        {
            currentCursorLockMode = value;
            if(!noMouseMode)
            {
                Cursor.lockState = value;
            }
        }
    }

    private CursorLockMode currentCursorLockMode = CursorLockMode.Locked;
    private bool noMouseMode = false;

    private void Start()
    {
        CurrentCursorLockMode = startingCursorLockMode;
    }

    public void NoMouseMode(bool isUsingControllerOrKeyboard)
    {
        noMouseMode = isUsingControllerOrKeyboard;
        if(noMouseMode)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CurrentCursorLockMode;
        }
    }

    public void OnApplicationFocus(bool hasFocus)
    {
        if(hasFocus)
        {
            Cursor.lockState = CurrentCursorLockMode;
        }
    }
}
