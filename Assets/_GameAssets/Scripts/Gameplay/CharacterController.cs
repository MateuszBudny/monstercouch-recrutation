using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float movementForce = 5f;
    [SerializeField]
    private Rigidbody2D characterRigidbody2D;

    private Vector2 movementInput;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        characterRigidbody2D.AddForce(movementInput * movementForce * Time.deltaTime);
    }

    public void SetMovementInput(Vector2 inputVector)
    {
        // I prefer to save the input in the variable instead of moving the character instantly as the button is pressed, as it is easier to manage character functions invocation order in Update.
        movementInput = inputVector.normalized;
    }
}
