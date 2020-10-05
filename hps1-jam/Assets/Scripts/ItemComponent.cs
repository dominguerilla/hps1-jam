using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ItemComponent : MonoBehaviour
{
    public UnityEvent onEquip = new UnityEvent();
    public UnityEvent onDequip = new UnityEvent();

    /// <summary>
    /// Does the player have to hold down Mouse button to keep a grip on this item?
    /// </summary>
    public bool isTemporary;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    public void Equip()
    {
        Freeze();
        onEquip.Invoke();
    }

    public void Dequip()
    {
        Unfreeze();
        onDequip.Invoke();
    }
    void Freeze()
    {
        rb.isKinematic = true;
    }

    void Unfreeze()
    {
        rb.isKinematic = false;
    }
}
