using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage;
    public string PlayerTag;

    // Start is called before the first frame update
    void Start()
    {
        if (damage <= 0.0)
        {
            damage = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            other.gameObject.GetComponent<H_Living_Player>().TakeDamage(damage);
        }
    }
}
