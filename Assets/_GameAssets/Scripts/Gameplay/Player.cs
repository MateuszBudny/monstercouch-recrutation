using UnityEngine;

public class Player : Character
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemyCollided))
        {
            enemyCollided.HitByPlayer();
        }
    }
}
