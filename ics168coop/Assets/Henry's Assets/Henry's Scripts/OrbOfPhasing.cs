using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbOfPhasing : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get { return "OrbOfPhasing"; }
    }

    public Sprite mImage;

    public Sprite Image
    {
        get { return mImage; }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public void OnSwap()
    {
    }
}
