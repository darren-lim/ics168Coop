using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int mSLOT = 1;

    [SerializeField]
    public List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemSwapped;

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count <= mSLOT)
        {
            CircleCollider2D collider = (item as MonoBehaviour).GetComponent<CircleCollider2D>();
            if(collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickup();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
                //if(ItemSwapped != null)
                //{
                //    ItemAdded(this, new InventoryEventArgs(item));
                //}
            }
        }
    }

    public void SwapItem(IInventoryItem item)
    {
        mItems.Remove(item);
        item.OnSwap();

        CircleCollider2D collider = (item as MonoBehaviour).GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            //collider.enabled = false;
            mItems.Clear();
            mItems.Add(item);
            item.OnPickup();
            if(ItemAdded != null)
            {
                ItemSwapped(this, new InventoryEventArgs(item));
                ItemAdded(this, new InventoryEventArgs(item));
            }
        }
            //if (mItems.Contains(item))
            //{
            //    mItems.Remove(item);

            //    item.OnSwap();

            //    CircleCollider2D collider = (item as MonoBehaviour).GetComponent<CircleCollider2D>();

            //    if(collider != null)
            //    {
            //        collider.enabled = true;
            //    }
            //    if(ItemSwapped != null)
            //    {
            //        ItemSwapped(this, new InventoryEventArgs(item));
            //    }
            //}
        }
}