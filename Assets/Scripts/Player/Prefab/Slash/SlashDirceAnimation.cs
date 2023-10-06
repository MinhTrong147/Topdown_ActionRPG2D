using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashDirceAnimation : MonoBehaviour
{

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        DirceToMouse();
    }
    
        private void DirceToMouse(){
            
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = mousePos - playerScreenPoint;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        animator.SetFloat(AnimationStrings.Horizontal,direction.x);
        animator.SetFloat(AnimationStrings.Vertical,direction.y);
    }     
    
}
