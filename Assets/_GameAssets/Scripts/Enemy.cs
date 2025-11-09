using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color deadColor = Color.gray;

    public bool IsAlive => enabled;

    public void HitByPlayer()
    {
        TryToDie();
    }

    private void TryToDie()
    {
        if(!IsAlive)
            return;

        ChangeColorToDead();
        enabled = false; // disable on death for optimization purposes
    }

    private void ChangeColorToDead()
    {
        spriteRenderer.color = deadColor;
    }
}
