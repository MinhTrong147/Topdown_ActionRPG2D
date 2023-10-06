using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DestructibleAnim : MonoBehaviour
{

    [SerializeField] private int Touching = 5;
    [SerializeField] private int currentInTouching;
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private Transform animTransformVFX;
    private Animator animator;
    private GameObject animVFX;
    [SerializeField] private Collider2D colli2D;
    private void Awake() {
        animator = GetComponent<Animator>();   
        animator.SetBool(AnimationStrings.isAlive,true);
    }

          private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Weapons")) 
            {
                animVFX= Instantiate(destroyVFX, animTransformVFX.position, quaternion.identity);
                animVFX.transform.parent = transform.parent;
                currentInTouching++;

                if (currentInTouching >= Touching)
                {
                animator.SetBool(AnimationStrings.isAlive,false);
                Instantiate(destroyVFX, animTransformVFX.position, Quaternion.identity);  
                Destroy(colli2D);              
                }
            }
        }
}
