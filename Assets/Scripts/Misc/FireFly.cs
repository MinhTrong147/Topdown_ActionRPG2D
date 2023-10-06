using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireFly : MonoBehaviour
{
    [SerializeField] private GameObject fireFlyPrefab;
    [SerializeField] private int intensityDivider = 1;   
    private ParticleSystem _particleSystem;
    private List<GameObject> Light = new List<GameObject>();
    private ParticleSystem.Particle[] particles;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
    }
    private void Update()
    {
        int count = _particleSystem.GetParticles(particles);

        while (Light.Count < count)
            Light.Add(Instantiate(fireFlyPrefab, _particleSystem.transform));

        bool worldSpace = (_particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World);
        
        for (int i = 0; i < Light.Count; i++)
        {
            if (i < count)
            {
                if (worldSpace)
                    Light[i].transform.position = particles[i].position;
                    
                else
                Light[i].transform.localPosition = particles[i].position;                   
                Light[i].SetActive(true);
            }            
            else
            {
                Light[i].SetActive(false);
            }
            Light[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = (particles[i].remainingLifetime / intensityDivider);
        }
    }
}
