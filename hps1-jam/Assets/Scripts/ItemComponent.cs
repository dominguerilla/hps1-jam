using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ItemComponent : MonoBehaviour
{
    public UnityEvent onEquip = new UnityEvent();
    public UnityEvent onDequip = new UnityEvent();

    [SerializeField] Vector3 targetLocalOrientation;

    /// <summary>
    /// Does the player have to hold down Mouse button to keep a grip on this item?
    /// </summary>
    public bool isTemporary;

    Rigidbody rb;
    bool isEquipped;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        if (isEquipped)
        {
            whileEquipped();
        }
    }

    /// <summary>
    /// Called on every frame the Item is equipped.
    /// </summary>
    public virtual void whileEquipped() { }

    public void Equip()
    {
        Freeze();
        Orient();
        isEquipped = true;
        onEquip.Invoke();
    }

    public void Dequip()
    {
        Unfreeze();
        isEquipped = false;
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
    void Orient()
    {
        this.transform.localEulerAngles = targetLocalOrientation;
    }
}
