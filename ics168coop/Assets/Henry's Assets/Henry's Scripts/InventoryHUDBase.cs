using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUDBase : MonoBehaviour
{
    //public virtual Inventory myInventory;

    public virtual void Start()
    {
        //myInventory.ItemAdded += InventoryScript_ItemAdded;
    }

    public virtual void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        /*
                Transform InventoryCanvas = transform.Find("InventoryCanvas");
                foreach (Transform slot in InventoryCanvas)
                {
                    Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

                    if (!image.enabled)
                    {
                        image.enabled = true;
                        image.sprite = e.myItem.Image;

                        break;
                    }
                }*/
    }
}
