using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehavior : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;
    [SerializeField]
    HealthManager healthManager;
    bool destroyed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!destroyed)
        {
        particle.Play();
        healthManager.OnBuildingDestroyed();
        destroyed = true;
        }
    }
}
