using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();
    void OnSwap();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        myItem = item;
    }

    public IInventoryItem myItem;
}
