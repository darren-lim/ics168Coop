using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingLives : MonoBehaviour
{
    public GameObject living;
    public Text self_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        self_text.text = "Lives: " + living.GetComponent<H_Living_Player>().P2Health.ToString();
    }
}
