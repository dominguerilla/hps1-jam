using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GarlicItem : ItemComponent
{
    public float throwForce = 25f;
    public float aimForDistance = 1f;


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
    }

    Vector3 GetCameraForward()
    {
        return (Camera.main.transform.parent.forward + Camera.main.transform.forward).normalized;
    }
}
