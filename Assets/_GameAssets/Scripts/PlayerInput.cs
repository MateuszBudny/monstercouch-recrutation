using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private SceneOpener mainMenuSceneOpener;

    public void OnMove(CallbackContext callbackContext)
    {
        Vector2 inputVector = callbackContext.ReadValue<Vector2>();
        characterController.SetMovementInput(inputVector);
    }

    public void OnExit(CallbackContext callbackContext)
    {
        mainMenuSceneOpener.OpenGivenScene();
    }
}
