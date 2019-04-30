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
    bool isRespawning = false;

    public Vector3 InitPos;
    SpriteRenderer sRend;
    BoxCollider2D Box;

    // Start is called before the first frame update
    void Start()
    {
        InitPos = this.transform.position;
        sRend = this.GetComponent<SpriteRenderer>();
        Box = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Ghost = GameObject.FindGameObjectWithTag("Player 1");
        if (Ghost != null && !isStunned && !isRespawning)
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

    public void changeSpeed(float inc)
    {
        Speed += inc;
    }

    IEnumerator Respawn()
    {
        sRend.enabled = false;
        Box.enabled = false;
        //reposition
        Ghost = GameObject.FindGameObjectWithTag("Player 1");
        Vector2 ghostpos = new Vector2(Ghost.GetComponent<Transform>().position.x, Ghost.GetComponent<Transform>().position.z);
        transform.position = Random.insideUnitCircle * 7 + ghostpos;
        isRespawning = true;
        yield return new WaitForSeconds(2f);
        isRespawning = false;
        sRend.enabled = true;
        Box.enabled = true;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player 1")
        {
            //deal damage
            collision.GetComponent<H_Ghost_Player>().TakeDamage(1);
            //spawn new reaper
            StartCoroutine(Respawn());
        }
    }
}
