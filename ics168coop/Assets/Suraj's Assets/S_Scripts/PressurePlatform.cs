using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatform : MonoBehaviour
{
    public Vector3 maxPos;
    public Vector3 minPos;
    public float speed = 1.0f;
    public bool xAxisMove = false;
    public bool yAxisMove = true;
    public bool Xreversed = false;
    public bool Yreversed = false;

    [SerializeField]
    bool player_on = false;
    [SerializeField]
    Vector3 currPos;
    int XreverseFactor;
    int YreverseFactor;
    // Start is called before the first frame update
    void Start()
    {
        currPos = gameObject.transform.position;
        XreverseFactor = Xreversed ? -1 : 1;
        YreverseFactor = Yreversed ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_on == true &&
            (XreverseFactor*currPos.x < maxPos.x ||
             YreverseFactor*currPos.y < maxPos.y)) 
        {
            if (xAxisMove)
            {

                gameObject.transform.position += new Vector3(XreverseFactor*speed,0,0);
            }
            if (yAxisMove) 
            {
                gameObject.transform.position += new Vector3(0, YreverseFactor*speed, 0);
            }
        }
        else if (player_on == false &&
            (XreverseFactor*currPos.x > minPos.x ||
             YreverseFactor*currPos.y > minPos.y)) 
        {
            if (xAxisMove)
            {
                gameObject.transform.position -= new Vector3(XreverseFactor*speed, 0, 0);
            }
            if (yAxisMove)
            {
                gameObject.transform.position -= new Vector3(0, YreverseFactor*speed, 0);
            }
        }

        currPos = gameObject.transform.position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player 2") &&
            collision.rigidbody.velocity == Vector2.zero) 
        {
            player_on = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player 2"))
        {
            player_on = false;
        }
    }
}
