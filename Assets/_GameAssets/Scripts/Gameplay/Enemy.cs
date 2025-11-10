using System;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color deadColor = Color.gray;

    public bool IsAlive => enabled;
    public Player Player { get; set; }

    private void Update()
    {
        Move();
    }

    private void OnDisable()
    {
        controller.SetMovementInput(Vector2.zero);
    }

    private void Move()
    {
        controller.SetMovementInput(transform.position - Player.transform.position);
    }

    public void HitByPlayer()
    {
        TryToDie();
    }

    private void TryToDie()
    {
        if(!IsAlive)
            return;

        ChangeColorToDead();
        enabled = false; // disable on death so it isn't moving and for optimization purposes
    }

    private void ChangeColorToDead()
    {
        spriteRenderer.color = deadColor;
    }
}
