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

    public void Hold(ItemComponent item, Vector3 eulerAngleOffset)
    {
        heldItem = item;
        item.Equip(heldItemPosition, Vector3.zero, eulerAngleOffset);
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
