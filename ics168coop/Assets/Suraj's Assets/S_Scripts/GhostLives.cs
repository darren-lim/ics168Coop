using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostLives : MonoBehaviour
{
    public GameObject ghost;
    public Text self_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        self_text.text = "Lives: " + ghost.GetComponent<H_Ghost_Player>().P1Health.ToString();
    }
}
