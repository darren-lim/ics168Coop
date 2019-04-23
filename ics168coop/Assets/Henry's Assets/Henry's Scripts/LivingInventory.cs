using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingInventory : InventoryBase
{
    private const int livingInventory = 1;

    public List<IInventoryItem> livingItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public override void AddItem(IInventoryItem item)
    {
        if (livingItems.Count < livingInventory)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                livingItems.Add(item);
                item.OnPickup();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
