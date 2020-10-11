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
        this.equippedArm.Drop();
        Throw();
    }

    public override void Dequip()
    {
        base.Dequip();
    }

    void Throw()
    {
        Vector3 camForward = (Camera.main.transform.parent.forward + Camera.main.transform.forward).normalized * aimForDistance;
        Vector3 throwVector = camForward * throwForce;

        this.rb.AddForce(throwVector);
    }
}
