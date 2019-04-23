using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Living_Player : D_PlayerAbstract
{
    public float P2Speed = 5f;
    public float P2Jump = 5f;
    public float P2Health = 3f;

    Rigidbody2D rbody;

    public LayerMask GroundLayer;
    float jumpTime = 0f;
    float maxJump = 0.2f;

    //public string GoThroughTag = "PassThrough";
    //public LivingInventory livingInventory;
    //public GhostInventory ghostInventory;
    public Inventory livingInventory;
    public Inventory ghostInventory;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
    }

    protected override void Move()
    {
        if (Input.GetKey("d"))
        {
            //transform.Translate(Vector2.right * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(P2Speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        else if (Input.GetKey("a"))
        {
            //transform.Translate(Vector2.left * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(-P2Speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("w"))
        {
            //transform.Translate(Vector2.up * Time.deltaTime * P1Jump);
            if (base.CheckGround(GroundLayer) && jumpTime <= 0)
            {
                rbody.AddForce(new Vector2(0, P2Jump), ForceMode2D.Impulse);
                jumpTime = maxJump;
            }
        }
        if(Input.GetKeyDown("space"))
        {
            //Swap items
            //IInventoryItem item = livingInventory.mItems[0];
            ////go ahead and swap
            //livingInventory.SwapItem(item);
            //Inventory temp = livingInventory;
            //livingInventory = ghostInventory;
            //ghostInventory = temp;
            //IInventoryItem newItem = living
        }
        if (jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }
        //throw new System.NotImplementedException();
    }

    public override void TakeDamage(float dmg)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IInventoryItem item = collision.GetComponent<IInventoryItem>();
        if(item != null)
        {
            livingInventory.AddItem(item);
        }
    }
}
