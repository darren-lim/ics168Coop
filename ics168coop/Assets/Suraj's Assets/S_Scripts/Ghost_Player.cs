using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Player : D_PlayerAbstract
{
    public float P2Speed = 5f;
    public float P2Jump = 5f;
    public float P2Health = 3f;

    Rigidbody2D rbody;
    BoxCollider2D bcollider;

    public LayerMask GroundLayer;
    public string GoThroughTag = "PassThrough";
    public Vector2 orginial_size;
    //float jumpTime = 0f;
    //float maxJump = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        bcollider = this.GetComponent<BoxCollider2D>();
        orginial_size = new Vector2 (bcollider.size.x, bcollider.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
    }

    protected override void Move()
    {
        if (Input.GetKey("right"))
        {
            //transform.Translate(Vector2.right * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(P2Speed * Time.deltaTime, 0), ForceMode2D.Impulse);
           
        }
        else if (Input.GetKey("left"))
        {
            //transform.Translate(Vector2.left * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(-P2Speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("up"))
        {
            //transform.Translate(Vector2.up * Time.deltaTime * P1Jump);
            //if (base.CheckGround(GroundLayer) && jumpTime <= 0)
            //{
                rbody.AddForce(new Vector2(0, P2Jump), ForceMode2D.Impulse);
                //jumpTime = maxJump;
            //}
        }
        if (Input.GetKeyDown("down"))
        {
            rbody.AddForce(new Vector2(0, -P2Jump), ForceMode2D.Impulse);
        }
        //if (jumpTime > 0)
        //{
        //    jumpTime -= Time.deltaTime;
        //}
        //throw new System.NotImplementedException();
    }

    public override void TakeDamage(float dmg)
    {
        throw new System.NotImplementedException();
    }
}
