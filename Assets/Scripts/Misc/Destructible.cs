using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class DestroyVFX : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    [SerializeField] private int Touching = 1;
    [SerializeField] private int currentInTouching;

          private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Weapons")) 
            {
                Instantiate(destroyVFX, transform.position, Quaternion.identity);
                currentInTouching++;

                if (currentInTouching >= Touching)
                {
                Instantiate(destroyVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
                }
            }
        }
}
