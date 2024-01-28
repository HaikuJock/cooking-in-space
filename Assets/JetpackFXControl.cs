using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFXControl : MonoBehaviour
{
    private ParticleSystem leftJetPack;
    private ParticleSystem righJetPack;

    // Start is called before the first frame update
    void Start()
    {
        var particleSystems = gameObject.GetComponents<ParticleSystem>();

        Debug.LogWarning("particles" + particleSystems.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
