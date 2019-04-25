using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_EnemyScript : MonoBehaviour
{
    public float Speed;
    public GameObject Ghost;

    public bool isStunned = false;
    public float StunTime = 2f;
    public float MaxStunTime = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ghost = GameObject.FindGameObjectWithTag("Player 1");
        if (Ghost != null && !isStunned)
        {
            transform.position = Vector2.MoveTowards(transform.position, Ghost.GetComponent<Transform>().position, Speed * Time.deltaTime);
        }
        else if (isStunned)
        {
            StunTime -= Time.deltaTime;
            if(StunTime <= 0)
            {
                isStunned = false;
                StunTime = MaxStunTime;
            }
        }

    }

    public void Stun()
    {
        if (!isStunned)
        {
            isStunned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player 1")
        {
            //deal damage
            //get pushed away
        }
    }
}
