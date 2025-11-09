using UnityEngine;

public class Character : MonoBehaviour
{
    public void SetMovementInput(Vector2 inputVector)
    {
        // Handle player movement input
        Debug.Log($"Movement Input Received: {inputVector}");
    }
}
