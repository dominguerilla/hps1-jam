using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemComponent))]
[RequireComponent(typeof(ParticleSystem))]
public class SaltItem : MonoBehaviour
{
    public float saltRadius = 1f;
    [SerializeField] Vector3 targetLocalOrientation;
    [SerializeField] Transform saltAreaCenter;
    ItemComponent itemComponent;
    bool isEquipped;
    ParticleSystem saltParticles;
    
    void Start()
    {
        itemComponent = GetComponent<ItemComponent>();
        saltParticles = GetComponent<ParticleSystem>();
        Setup();
    }

    void Setup()
    {
        itemComponent.onEquip.AddListener(Equip);
        itemComponent.onDequip.AddListener(Dequip);
    }

    void Equip()
    {
        isEquipped = true;
        Orient();
    }

    void Orient()
    {
        this.transform.localEulerAngles = targetLocalOrientation;
    }

    void Dequip()
    {
        isEquipped = false;
    }

    
    void Update()
    {
        if (isEquipped)
        {
            onEquipped();
        }
    }

    void onEquipped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpraySalt();
        }
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
