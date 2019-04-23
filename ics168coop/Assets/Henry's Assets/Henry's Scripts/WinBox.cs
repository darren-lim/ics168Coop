using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
    private GameObject winText;

    private void Awake()
    {
        winText = GameObject.Find("Win Text");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player 2"))
        {
            winText.GetComponent<Canvas>().enabled = true;
        }
    }

}
