using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemComponent))]
[RequireComponent(typeof(ParticleSystem))]
public class SaltItem : MonoBehaviour
{
    [SerializeField] Vector3 targetLocalOrientation;
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
            saltParticles.Play();
        }
    }
}
