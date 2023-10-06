using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool GettingKnockBack{get; private set;}
    [SerializeField] private float knockBackTime = 0.2f;    
    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void GetKnockBack(Transform damageAble, float KnockBackThrust){
        GettingKnockBack = true;
        Vector2 differece = (transform.position - damageAble.position ).normalized * KnockBackThrust*rb2d.mass;
        rb2d.AddForce( differece, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    private IEnumerator KnockRoutine(){
        yield return new WaitForSeconds(knockBackTime);
        rb2d.velocity = Vector2.zero;
        GettingKnockBack = false;
    }
}
