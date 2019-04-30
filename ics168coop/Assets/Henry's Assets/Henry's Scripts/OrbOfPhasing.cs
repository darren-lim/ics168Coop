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
            Reaper.changeSpeed(1.4f);
        }
    }

    public void OnSwap()
    {
    }

    public void OnDrop(Vector3 newPosition)
    {
        Debug.Log("HEREEEEEEEE");
        Transform myT = gameObject.GetComponent<Transform>();
        myT.position = newPosition;
        gameObject.SetActive(true);
        myT.GetComponent<CircleCollider2D>().enabled = true;

        //Instantiate(gameObject, newPosition, Quaternion.identity);

        Reaper = GameObject.FindObjectOfType(typeof(D_EnemyScript)) as D_EnemyScript;
        if (Reaper != null)
        {
            Reaper.changeSpeed(-1.4f);
        }
    }
}
