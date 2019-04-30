using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbOfPhasing : MonoBehaviour, IInventoryItem
{
    public D_EnemyScript Reaper;
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
        Reaper = GameObject.FindObjectOfType(typeof(D_EnemyScript)) as D_EnemyScript;
        if (Reaper != null)
        {
            Reaper.changeSpeed(2f);
        }
    }

    public void OnSwap()
    {
    }
}
