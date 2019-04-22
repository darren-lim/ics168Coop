using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughBlock : MonoBehaviour
{
    public string allowTag = "Player 1";

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(allowTag)) 
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
