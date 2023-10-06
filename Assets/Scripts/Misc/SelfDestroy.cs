using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDetroy : MonoBehaviour
{

    private ParticleSystem ps;

    private void Awake() {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update(){
        if(ps && !ps.IsAlive()){
            DestroySeftAnimEvents();
        }
    }
    private void DestroySeftAnimEvents(){
    Destroy(gameObject);
    }
}
