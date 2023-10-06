using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject animSlashPrefab;
    [SerializeField] private Transform weaponCollider;
    [SerializeField] private float swordAttackCD = .35f;
    [SerializeField] private float StopAttackAimCD = 5f;

    private Transform SlashAnimDirce;
    private GameObject animSlash;
    private Animator animator;
    private ActiveWeapon activeWeapon;
    private bool isAttackAnimRun = false;
    

    public void Awake() {
        animator = GetComponent<Animator>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        
    }
    public void Start() {
        SlashAnimDirce = CharacterControl.Instance.GetTransformSlashAnimDirce();
    }
    public void Update() {
       mouseFollowWithOffset();
    }


    public void Attack(){

        AttackDirection();
        animator.SetTrigger(AnimationStrings.Attack); 
        weaponCollider.gameObject.SetActive(true);  
        StartCoroutine(DecreaseSlashPerTime()); 
        animSlash=Instantiate(animSlashPrefab, SlashAnimDirce.position, quaternion.identity);
        animSlash.transform.parent = this.transform.parent;
        StartCoroutine(AttackCDRoutine());      
    }
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
    private void AttackDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePosition - playerScreenPoint;
        direction.Normalize();
        animator.SetFloat(AnimationStrings.Horizontal, direction.x);
        animator.SetFloat(AnimationStrings.Vertical, direction.y);
    }
    private IEnumerator AttackCDRoutine(){
        // isAttacking = true;
        yield return new WaitForSeconds(swordAttackCD);

    }
    public void FinishAttack(){
        if(!isAttackAnimRun){
            StartCoroutine(DecreaseSlashPerTime()); 
        }
        weaponCollider.gameObject.SetActive(false);
    }


    private IEnumerator DecreaseSlashPerTime()
    {
        float countdownTimer = StopAttackAimCD;
        isAttackAnimRun = false;
        while (countdownTimer > 0f)
        {
            countdownTimer -= Time.deltaTime;
            animator.SetFloat(AnimationStrings.SlashPerTime, countdownTimer);
            yield return null;
        }
        animator.SetFloat(AnimationStrings.SlashPerTime, 0f);
    }
    private void mouseFollowWithOffset(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(CharacterControl.Instance.transform.position);
        
        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
    } 
    //     public void SlashForwardState2() {
    //     animator.gameObject.transform.rotation = Quaternion.Euler(0, 180, 90);
    // }
    //     public void SlashBackState2() {
    //     animator.gameObject.transform.rotation = Quaternion.Euler(0, 180, -90);
    // }
    //     public void SlashLState2() {
    //     animator.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    // }
    //     public void SlashRState2() {
    //     animator.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    // }
}
