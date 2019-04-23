using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInventory : InventoryBase
{
    private const int ghostSlot = 1;

    public List<IInventoryItem> ghostItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public override void AddItem(IInventoryItem item)
    {
        if (ghostItems.Count < ghostSlot)
        {
            CircleCollider2D collider = (item as MonoBehaviour).GetComponent<CircleCollider2D>();
            Debug.LogFormat("Collider is {0}", collider);
            if (collider.enabled)
            {
                collider.enabled = false;
                ghostItems.Add(item);
                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
