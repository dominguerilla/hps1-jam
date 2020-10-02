using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] Transform heldItemPosition;

    ItemComponent heldItem;

    public Transform GetItemPosition()
    {
        return heldItemPosition;
    }

    public void Hold(ItemComponent item)
    {
        heldItem = item;
        item.Freeze();
        item.transform.SetParent(heldItemPosition);
        item.transform.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        if (heldItem)
        {
            heldItem.transform.SetParent(null);
            heldItem.Unfreeze();
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
