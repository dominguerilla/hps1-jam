using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] Transform heldItemPosition;

    ItemComponent heldItem;

    private void Awake()
    {
        if (!heldItemPosition)
        {
            heldItemPosition = transform;
        }
    }

    public Transform GetItemPosition()
    {
        return heldItemPosition;
    }

    public void Hold(ItemComponent item)
    {
        heldItem = item;
        item.transform.SetParent(heldItemPosition);
        item.transform.localPosition = Vector3.zero;
        item.Equip();
    }

    public void UseItem()
    {
        if (heldItem)
        {
            heldItem.Use();
        }
        else
        {
            Debug.LogError("Trying to use Item while Arm is empty!");
        }
    }

    public void Drop()
    {
        if (heldItem)
        {
            heldItem.transform.SetParent(null);
            heldItem.Dequip();
            heldItem = null;
        }
    }

    public void DropIfTemporary()
    {
        if (heldItem && heldItem.isTemporary)
        {
            Drop();
        }
    }

    public bool IsHoldingItem()
    {
        return heldItem != null;
    }
}
