using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GarlicItem : ItemComponent
{
    public float throwForce = 25f;
    public float aimForDistance = 1f;

    [SerializeField] ParticleSystem garlicParticles;

    bool isBeingThrown = false;

    public override void Use()
    {
        this.equippedArm.Drop(this.transform.position + GetCameraForward());
        Throw();
    }

    void Throw()
    {
        Vector3 camForward = GetCameraForward() * aimForDistance;
        Vector3 throwVector = camForward * throwForce;

        this.rb.AddForce(throwVector);
        isBeingThrown = true;
    }

    Vector3 GetCameraForward()
    {
        return (Camera.main.transform.parent.forward + Camera.main.transform.forward).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isBeingThrown)
        {
            BreakApart();
            Monster monster = collision.collider.GetComponentInParent<Monster>();
            if (monster)
            {
                monster.Flee();
            }
        }
        else
        {
            isBeingThrown = false;
        }
    }

    void BreakApart()
    {
        if (this.garlicParticles)
        {
            this.garlicParticles.Play();
        }
        else
        {
            Debug.LogWarning("No particles set!");
        }
        isBeingThrown = false;
    }
}
