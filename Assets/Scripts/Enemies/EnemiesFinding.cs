using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemiesFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Vector2 moveDirce;
    private Rigidbody2D rb2d;
    private KnockBack knockBack;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        knockBack = GetComponent<KnockBack>();

    }

    private void FixedUpdate() {
        if(knockBack.GettingKnockBack){
            return;
        }
        rb2d.MovePosition(rb2d.position + moveDirce *(moveSpeed *Time.deltaTime));
        if (moveDirce.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void MovePoint(Vector2 target)
    {
        moveDirce = target;
    }
}
