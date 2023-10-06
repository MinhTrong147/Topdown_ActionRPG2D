using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
public MonoBehaviour CurrentActiveWeapon { get; private set; }

    private PlayerControl playerControl;

    private bool attackButtonDown, isAttacking = false;


    protected override void Awake() {
        base.Awake();

        playerControl = new PlayerControl();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void Start()
    {
        playerControl.Combat.Attack.started += _ => StartAttacking();
        playerControl.Combat.Attack.canceled += _ => StopAttacking();
    }

    private void Update() {
        Attack();
    }

    public void NewWeapon(MonoBehaviour newWeapon) {
        CurrentActiveWeapon = newWeapon;
    }

    public void WeaponNull() {
        CurrentActiveWeapon = null;
    }

    public void ToggleIsAttacking(bool value) {
        isAttacking = value;
    }

    private void StartAttacking()
    {
        attackButtonDown = true;
    }

    private void StopAttacking()
    {
        attackButtonDown = false;
    }

    private void Attack() {
        if (attackButtonDown && !isAttacking) {
            isAttacking = true;
            (CurrentActiveWeapon as IWeapon).Attack();
        }
    }
}