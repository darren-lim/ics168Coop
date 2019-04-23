using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingInventoryHUD : InventoryHUDBase
{
    public Inventory livingInventory;
    private GameObject blocker;

    private void Awake()
    {
        blocker = GameObject.Find("Blocker 1");
        Debug.LogFormat("Blocker {0}", blocker);
    }

    private void Update()
    {
        Image image = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        if(image != null)
        {
            blocker.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public override void Start()
    {
        livingInventory.ItemAdded += InventoryScript_ItemAdded;
        livingInventory.ItemSwapped += InventoryScript_ItemSwapped;
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

        if (image != null)
        {
            image.enabled = false;
            image.sprite = null;
        }
    }
}
