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
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        knockBack = GetComponent<KnockBack>();

    }

    private void FixedUpdate() {
        if(knockBack.GettingKnockBack){
            return;
        }
        rb2d.MovePosition(rb2d.position + moveDirce *(moveSpeed *Time.deltaTime));
    }

    public void MovePoint(Vector2 target)
    {
        moveDirce = target;
    }
}
