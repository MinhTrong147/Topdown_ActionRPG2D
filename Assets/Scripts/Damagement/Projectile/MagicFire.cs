using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicFire : MonoBehaviour
{
    [SerializeField] private float fireGrowTime = 2f;
    private bool isGrowing = true;
    private float fireRange;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        FireFaceMouse();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Indestructible>()&&!other.isTrigger)
        {
            isGrowing = false;
        }
    }
    public void UpdateFireRange(float fireRange)
    {
        this.fireRange = fireRange;
        StartCoroutine(IncreaseLaserLengthRoutine());
    }

    private IEnumerator IncreaseLaserLengthRoutine()
    {
        float timePassed = 0f;

        while (spriteRenderer.size.x < fireRange && isGrowing)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / fireGrowTime;

            // sprite 
            spriteRenderer.size = new Vector2(Mathf.Lerp(1f, fireRange, linearT), 1f);

            // collider
            capsuleCollider2D.size = new Vector2(Mathf.Lerp(1f, fireRange, linearT), capsuleCollider2D.size.y);
            capsuleCollider2D.offset = new Vector2((Mathf.Lerp(1f, fireRange, linearT)) / 2, capsuleCollider2D.offset.y);

            yield return null;
        }

        StartCoroutine(GetComponent<SpriteFade>().SlowFadeRoutine());
    }
    private void FireFaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = transform.position - mousePosition;

        transform.right = -direction;
    }
}
