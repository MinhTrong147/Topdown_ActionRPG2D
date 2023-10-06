using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterControl : Singleton<CharacterControl>
{

    [SerializeField] private float moveSpeed = 2f; 
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private Transform SlashAnimDirce;

    private PlayerControl playerControl;
    private Vector2 movement;
    private Rigidbody2D rb2d;
    private Animator animator;
    private bool isDashing = false;
    private float startingMoveSpeed;

    protected override void Awake() {
        base.Awake();
        
        playerControl = new PlayerControl();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start() {
        playerControl.Combat.Dash.performed +=_=>Dash();
        startingMoveSpeed = moveSpeed;
    }
    private void OnEnable() {
        playerControl.Enable();      
      
    }
    private void Update() {
        PlayerInput();
 
    }
    private void FixedUpdate() {
            FlipDirceMouse();
            Move();       
    }

    public Transform GetTransformSlashAnimDirce(){
        return SlashAnimDirce;
    }
    private void PlayerInput(){
        movement = playerControl.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat(AnimationStrings.MoveX, movement.x);
        animator.SetFloat(AnimationStrings.MoveY, movement.y);
    }

    private void Move(){
        rb2d.MovePosition(rb2d.position + movement * (moveSpeed * Time.deltaTime));
    }

    private void FlipDirceMouse(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePos - playerScreenPoint;
        direction.Normalize();
        // // Flip the object horizontally based on the direction
        // if (direction.x < 0)
        // {
        //     transform.localScale = new Vector3(-1, 1, 1);
        // }
        // else if (direction.x > 0)
        // {
        //     transform.localScale = new Vector3(1, 1, 1);
        // }
        animator.SetFloat(AnimationStrings.Horizontal,direction.x);
        animator.SetFloat(AnimationStrings.Vertical,direction.y);
    }
    private void Dash(){
        if(!isDashing){   
        isDashing = true;
        moveSpeed *= dashSpeed;
        trailRenderer.emitting = true;
        StartCoroutine(EndDashRoutine());
        }
    }
    private IEnumerator EndDashRoutine(){
        float dashTime= .2f;
        float dashCD = .5f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = startingMoveSpeed;
        trailRenderer.emitting=false;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    }

}

