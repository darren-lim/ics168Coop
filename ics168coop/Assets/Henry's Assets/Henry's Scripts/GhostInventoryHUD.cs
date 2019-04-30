using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostInventoryHUD : InventoryHUDBase
{
    public Inventory ghostInventory;

    public override void Start()
    {
        ghostInventory.ItemAdded += InventoryScript_ItemAdded;
        ghostInventory.ItemSwapped += InventoryScript_ItemSwapped;
        ghostInventory.ItemRemoved += InventoryScript_ItemRemoved;
        ghostInventory.ItemDropped += InventoryScript_ItemDropped;
    }

    public override void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Image image = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        //Debug.LogFormat("The image is {0}", image);

        if (!image.enabled)
        {
            image.enabled = true;
            image.sprite = e.myItem.Image;
        }
    }

    public void InventoryScript_ItemSwapped(object sender, InventoryEventArgs e)
    {
        Image image = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();

        if(image != null)
        {
            image.enabled = false;
            image.sprite = null;
        }
    }

    public void InventoryScript_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Image image = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        if(image.enabled)
        {
            image.enabled = false;
            image.sprite = null;
        }
    }

    public void InventoryScript_ItemDropped(object sender, InventoryEventArgs e)
    {
        Debug.Log("Droppin G's Item");
    }
}
