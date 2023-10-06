using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject magicFire;
    [SerializeField] private Transform magicFireSpawnPoint;

    private Animator animator;

    readonly int AttackHash = Animator.StringToHash(AnimationStrings.Attack);

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        animator.SetTrigger(AttackHash);
    }

    public void SpawnStaffProjectileAnimEvent()
    {
        GameObject newLaser = Instantiate(magicFire, magicFireSpawnPoint.position, Quaternion.identity);
        newLaser.GetComponent<MagicFire>().UpdateFireRange(weaponInfo.weaponRange);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
