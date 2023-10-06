using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float HealthBegin = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private GameObject attackEffectVFXPrefab;
    [SerializeField] private float knockBackThurst = 15f;
    private float CurrentHealth;
    private KnockBack knockBack;
    private Flash flash;
    private void Awake(){
        knockBack = GetComponent<KnockBack>();
        flash = GetComponent<Flash>();
    }
    private void Start() {
        CurrentHealth = HealthBegin;
    }

    public void TakeDamage(float damage){
        CurrentHealth -= damage ;
        knockBack.GetKnockBack(CharacterControl.Instance.transform, knockBackThurst);
        StartCoroutine(flash.FlashRoutine());
        Instantiate(attackEffectVFXPrefab, transform.position, Quaternion.identity);
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine(){
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    private void DetectDeath(){
        if(CurrentHealth <=0){
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
