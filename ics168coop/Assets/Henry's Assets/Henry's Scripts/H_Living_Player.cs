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
            transform.Translate(Vector2.right * Time.deltaTime * P2Speed);
            //rbody.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * P2Speed);
        }
        
        else if (Input.GetKey("a"))
        {
            transform.Translate(Vector2.left * Time.deltaTime * P2Speed);
            //rbody.AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * P2Speed);
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
        if (Input.GetKeyDown("left shift"))
        {
            Debug.Log("Swapping Items");
            IInventoryItem ghostItem, livingItem;
            int ghostSize = ghostInventory.mItems.Count;
            int livingSize = livingInventory.mItems.Count;
            if (ghostSize != 0 && livingSize != 0)
            {
                Debug.Log("Both Inventories were full");
                ghostItem = ghostInventory.mItems[0];
                livingItem = livingInventory.mItems[0];
                livingInventory.SwapItem(ghostItem);
                ghostInventory.SwapItem(ghostItem);
            }
            if (ghostSize != 0 && livingSize == 0)
            {
                Debug.Log("living Inventory was empty before switching");
                ghostItem = ghostInventory.mItems[0];
                livingInventory.SwapItem(ghostItem);
                ghostInventory.RemoveItem(ghostItem);
            }
            if (ghostSize == 0 && livingSize != 0)
            {
                Debug.Log("Ghost Inventory was empty before switching");
                livingItem = livingInventory.mItems[0];
                ghostInventory.SwapItem(livingItem);
                livingInventory.RemoveItem(livingItem);
            }
            if (ghostSize == 0 && livingSize == 0)
            {
                Debug.Log("Both Inventories are empty");
            }
        }
        if (Input.GetKeyDown("left ctrl"))
        {
            Debug.Log("Living Player is dropping their item");
            IInventoryItem livingItem;
            int livingSize = livingInventory.mItems.Count;

            if (livingSize != 0)
            {
                livingItem = livingInventory.mItems[0];
                //Instantiate(livingItem);
                livingInventory.RemoveItem(livingItem);
            }
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
