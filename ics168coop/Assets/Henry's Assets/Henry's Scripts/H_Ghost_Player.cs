using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Ghost_Player : D_PlayerAbstract
{
    public float P1Speed = 5f;
    public float P1Health = 3f;

    Rigidbody2D rbody;
    BoxCollider2D bcollider;

    public string GoThroughTag = "PassThrough";
    public Vector2 orginial_size;
    //float jumpTime = 0f;
    //float maxJump = 0.2f;

    //public GhostInventory ghostInventory;
    //public LivingInventory livingInventory;
    public Inventory ghostInventory;
    public Inventory livingInventory;

    public SceneManagerScript scene;
    public GameObject gotext;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        bcollider = this.GetComponent<BoxCollider2D>();
        orginial_size = new Vector2(bcollider.size.x, bcollider.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        rbody.velocity = rbody.velocity * 0.96f;
        rbody.angularVelocity = rbody.angularVelocity * 0.96f;
    }
    protected override void Move()
    {
        if (Input.GetKey("right"))
        {
            //transform.Translate(Vector2.right * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(P1Speed * Time.deltaTime, 0), ForceMode2D.Impulse);

        }
        else if (Input.GetKey("left"))
        {
            //transform.Translate(Vector2.left * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(-P1Speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey("up"))
        {
            //transform.Translate(Vector2.up * Time.deltaTime * P1Jump);
            rbody.AddForce(new Vector2(0, P1Speed * Time.deltaTime), ForceMode2D.Impulse);
        }
        else if (Input.GetKey("down"))
        {
            rbody.AddForce(new Vector2(0, -P1Speed * Time.deltaTime), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("right shift"))
        {
            //Swap Items
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
        if (Input.GetKeyDown("right ctrl"))
        {
            Debug.Log("Ghost Player is dropping their item");
            IInventoryItem ghostItem;
            int ghostSize = livingInventory.mItems.Count;

            if (ghostSize != 0)
            {
                ghostItem = ghostInventory.mItems[0];
                ghostInventory.RemoveItem(ghostItem);
            }
        }
        //if (jumpTime > 0)
        //{
        //    jumpTime -= Time.deltaTime;
        //}
        //throw new System.NotImplementedException();
    }

    public override void TakeDamage(float dmg)
    {
        P1Health--;
        Debug.Log("OW");
        if(P1Health <=0)
        {
            scene = GameObject.FindObjectOfType(typeof(SceneManagerScript)) as SceneManagerScript;
            scene.GameOver();
            gotext = GameObject.Find("GameOver Text");
            gotext.GetComponent<Canvas>().enabled = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogFormat("Collided with {0}", collision.name);
        IInventoryItem triggerItem;
        if (collision.CompareTag("Item"))
        {
            triggerItem = collision.GetComponent<IInventoryItem>();
            ghostInventory.AddItem(triggerItem);
        }
        //Debug.LogFormat("Item is {0}", item);
    }
}
