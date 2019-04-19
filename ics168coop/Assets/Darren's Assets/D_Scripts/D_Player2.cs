using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Player2 : D_PlayerAbstract
{
    public float P2Speed = 5f;
    public float P2Jump = 5f;
    public float P2Health = 3f;

    Rigidbody2D rbody;

    public LayerMask GroundLayer;
    float jumpTime = 0f;
    float maxJump = 0.2f;

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
}
