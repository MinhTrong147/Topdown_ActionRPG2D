using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material FlashMat;
    [SerializeField] private float restorDefaultMatTime = .2f;

    private Material defaultMaterial;
    private SpriteRenderer spriteRenderer;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }
    public IEnumerator FlashRoutine(){
        spriteRenderer.material = FlashMat;
        yield return new WaitForSeconds(restorDefaultMatTime);
        spriteRenderer.material = defaultMaterial;
    }

    public float GetRestoreMatTime(){
        return restorDefaultMatTime;
    }
}