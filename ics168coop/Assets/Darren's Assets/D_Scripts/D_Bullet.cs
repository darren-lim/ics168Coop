using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Bullet : MonoBehaviour
{
    public float BulletSpeed = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
        //maybe do velocity?
    }

    //if hit enemy, destroy itself, stun enemy
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            //stun enemy
            collider.GetComponent<D_EnemyScript>().Stun();
        }
        if(collider.gameObject.tag != "Player 2")
        {
            Destroy(this.gameObject);
        }
    }
}
