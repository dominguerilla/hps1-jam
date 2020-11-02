using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SaltItem : ItemComponent
{
    public float saltRadius = 1f;
    [SerializeField] Transform saltAreaCenter;
    ParticleSystem saltParticles;
    
    void Start()
    {
        saltParticles = GetComponent<ParticleSystem>();
    }

    public override void Use()
    {
        SpraySalt();
    }

    void SpraySalt()
    {
        saltParticles.Play();
        Collider[] colliders = Physics.OverlapSphere(saltAreaCenter.position, saltRadius);
        foreach (Collider col in colliders)
        {
            Monster monster = col.GetComponentInParent<Monster>();
            if (monster)
            {
                monster.Stun();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(saltAreaCenter.position, saltRadius);
    }
}
