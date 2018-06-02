using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public Rigidbody2D rig;
    public Transform origin;
    //public Transform bg1;
    //public Transform bg2;
    //public Transform bg3;
    //public Transform bg4;
    //public Transform mGroundCheck;

    public int MaxSpeed = 10;
    //public int FlySpeed = 20;

    public int Moveforce = 80;
    public int force = 500;
    //public float bgchangetimes = 1f;


    //animate
    public Animator anim;


    //private int dirc = 1;
    //private float bgchange = 1f;


    //time
    private float time1 = 0;
    private float time2 = 0;
    private bool fail = false;

    //private float dic_time1 = 0;
    //private float dic_time2 = 0;




    //private bool bFacerright = true;
    //private bool bJump = false;


    // Use this for initialization
    void Start()
    {
        //anim = GameObject.Find("slimeRed_0").GetComponent<Animator>();
        //mGroundCheck = transform.Find("GroundCheck");
        //Debug.Log("Vector2.down:" + Vector2.down);
        //Debug.Log("Vector2.right:" + Vector2.right);

    }


    void FixedUpdate()
    {
        //float fInput = 0;
        //float fInput = Input.GetAxis("Vertical");

        //控制移动
        //Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            time1 = Time.time;
        }





        //if (fInput * rigidBody.velocity.x < MaxSpeed)
        //{
        //    rigidBody.AddForce(Vector2.right * fInput * Moveforce);
        //}


        ////限制最大速度
        //if (Mathf.Abs(rigidBody.velocity.x) > MaxSpeed)
        //{
        //    rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * MaxSpeed, rigidBody.velocity.y);
        //}

        //if (fInput > 0 && !bFacerright)
        //{
        //    flip();
        //}
        //if (fInput < 0 && bFacerright)
        //{
        //    flip();
        //}



        //alive();


    }

    // Update is called once per frame
    void Update()
    {
        //dic_control();
        move_control();

    }

    //void flip()
    //{
    //    bFacerright = !bFacerright;
    //    Vector3 theScale = transform.localScale;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;

    //}
    void alive()
    {
        float step = 8 * Time.deltaTime;
        if (transform.position.y < -100)
        {
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, -1, 0), step);

        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        
    }
    void move_control()
    {

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        float fInput = 0;
        Vector3 theScale = transform.localScale;
        
        //行走控制
        if (Input.GetKeyUp(KeyCode.D))
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        //行走控制
        if (Input.GetKey(KeyCode.D))
        {
            if(!Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
            {
                MaxSpeed = 25;
            }
            else
            {
                MaxSpeed = 10;

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                time2 = Time.time;

                force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 1.6f) - 0.1) * 1500) + 5000;

            }
            else
            {
                fInput = 1;
                rigidBody.velocity = new Vector2(fInput * MaxSpeed, rigidBody.velocity.y);
                if (transform.localScale.x < 0)
                {
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
           
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (!Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
            {
                MaxSpeed = 25;
            }
            else
            {
                MaxSpeed = 10;

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                time2 = Time.time;

                force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 1.6f) - 0.1) * 1500) + 5000;

            }
            else
            {
                fInput = -1;
                rigidBody.velocity = new Vector2(fInput * MaxSpeed, rigidBody.velocity.y);
                if (transform.localScale.x > 0)
                {
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
            
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            time1 = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            //rig.AddForce(new Vector2(0, force));
            //rig.AddForce(Vector2.right* force);

            time1 = Time.time;
            anim.SetBool("getforce", true);
            anim.SetBool("move", false);

            //anim.SetBool("fly", false);

            //Debug.Log("time1:" + time1);
        }

        if (Input.GetKey(KeyCode.Space) && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            time2 = Time.time;

            force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 1.6f) - 0.1) * 1500) + 5000;
            //Debug.Log("aaa" + force);

        }
        if (Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            //anim.SetBool("stand", true);
            //anim.SetBool("fly", false);

        }

        if (Input.GetKeyUp(KeyCode.Space) && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            time2 = Time.time;

            force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 1.6f) - 0.1) * 1500) + 5000;

            if (Input.GetKey(KeyCode.DownArrow))
            {
                time2 = Time.time;
            }
            else
            {
                rig.AddForce(new Vector2(0, force));
            }

            anim.SetBool("getforce", false);
            anim.SetBool("move", true);

            //anim.SetBool("stand", false);
            //Debug.Log("aaa" + force);

            force = 5000;


            //rig.AddForce(Vector2.right* force);
            //Debug.Log("time2:" + time2);

        }
        if (Physics2D.Raycast(origin.position, Vector2.down, 0.1f) == false)
        {
            fail = true;
            //Debug.Log(fail);

        }
        if (fail && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            anim.Play("fail", 0, 0);
            fail = false;

        }
        //Debug.Log(fail);
        //瞬间移动
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    //判断方向
        //    if (transform.localScale.x > 0)
        //    {
        //        dirc = 1;
        //    }
        //    else
        //    {
        //        dirc = -1;
        //    }
        //    rig.AddForce(new Vector2(force * dirc, 0));
        //    //rig.AddForce(Vector2.right * force*3* dirc);

        //}


    }
    //void dic_control()
    //{
    //    if (Input.GetKeyUp(KeyCode.A) && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
    //    {
    //        dic_time1 = Time.time;
    //    }
    //    if (Input.GetKey(KeyCode.A) && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
    //    {
    //        dic_time1 = Time.time;
    //    }
    //    //if


    //}

}

