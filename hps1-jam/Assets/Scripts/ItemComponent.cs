using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemComponent : MonoBehaviour
{
    /// <summary>
    /// Does the player have to hold down Mouse button to keep a grip on this item?
    /// </summary>
    public bool isTemporary;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }
    public void Freeze()
    {
        if (rb)
        {
            rb.isKinematic = true;
        }
    }

    public void Unfreeze()
    {
        if (rb)
        {
            rb.isKinematic = false;
        }
    }
}
