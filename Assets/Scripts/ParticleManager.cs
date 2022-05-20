using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleSystem particle;

    void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    public  void StartParticle(Vector3 pos)
    {
        particle.transform.position = pos;
        particle.Play();
    }
    public  void DisableParticle()
    {
       // particle.SetActive(false);
    }

    void Update()
    {
        
    }
}
