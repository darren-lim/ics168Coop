using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden_Block : MonoBehaviour
{
    public GameObject[] hiddenObjects;
    public Inventory livingInventory;
    [SerializeField]
    public string itemToHave;

    bool can_show = false;
    bool is_shown = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject hidden in hiddenObjects) 
        {
            hidden.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!can_show && 
            livingInventory.GetComponent<Inventory>().mItems.Count > 0 &&
            livingInventory.GetComponent<Inventory>().mItems[0].Name == itemToHave) 
        {
            can_show = true;
            if (!is_shown)
            {
                foreach (GameObject hidden in hiddenObjects)
                {
                    hidden.SetActive(true);
                }
                is_shown = true;
            }
        }
    }
}
