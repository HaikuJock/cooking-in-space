using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class JetpackFXControl : MonoBehaviour
{
    private List<ParticleSystem> jetPackVFXs = new List<ParticleSystem>();
    private float emissionRate = 0f;
    private StarterAssetsInputs input;

    void Start()
    {
        var particleSystems = gameObject.GetComponentsInChildren<ParticleSystem>();

        foreach (var particleSystem in particleSystems) {
            if (particleSystem.name.StartsWith("Jetpack")) {
                jetPackVFXs.Add(particleSystem);
                particleSystem.Play();
                var emission = particleSystem.emission;
                emission.rateOverTime = 0f;
            }
        }

        input = GetComponent<StarterAssetsInputs>();
    }

    const float MaxParticleRate = 300f;
    const float ParticleEmissionLerpFactor = 10f;

    void Update()
    {
        float inputMagnitude = input.move == Vector2.zero ? 0f : input.analogMovement ? input.move.magnitude : 1f;

        emissionRate = Mathf.Lerp(emissionRate, inputMagnitude, Time.deltaTime * ParticleEmissionLerpFactor);
        
        foreach (var jetPack in jetPackVFXs) {
            var emission = jetPack.emission;

            emission.rateOverTime = emissionRate * MaxParticleRate;
        }
    }
}
