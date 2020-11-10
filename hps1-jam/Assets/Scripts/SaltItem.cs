﻿using System.Collections;
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
        int mask = 1;
        Collider[] colliders = Physics.OverlapSphere(saltAreaCenter.position, saltRadius, mask, queryTriggerInteraction: QueryTriggerInteraction.Ignore);
        foreach (Collider col in colliders)
        {
            Monster monster = col.GetComponentInParent<Monster>();
            if (monster)
            {
                Debug.Log($"Salting {col.gameObject}");
                monster.OnSalt();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(saltAreaCenter.position, saltRadius);
    }
}
