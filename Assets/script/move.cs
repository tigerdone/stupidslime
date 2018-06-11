using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public Rigidbody2D rig;
    public Transform origin;
    public int MaxSpeed = 10;
    public int Moveforce = 80;
    public int force = 500;
    public Animator anim;

    public int add_force = 2500;

    private float time1 = 0;
    private float time2 = 0;
    private bool fail = false;

    void Start()
    {


    }


    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            time1 = Time.time;
        }



        
    }

    void Update()
    {
        move_control();
        position_limite();
     
    }

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

                //force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 0.8f) - 0.1) * 2500) + 5000;

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

                force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 0.8f) - 0.1) * 2500) + 5000;

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

            time1 = Time.time;
          
        }

        if (Input.GetKey(KeyCode.Space) && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            time2 = Time.time;

            anim.SetBool("getforce", true);
            anim.SetBool("move", false);

            force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 0.8f) - 0.1) * 2500) + 5000;
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

            force = (int)((Mathf.Clamp(time2 - time1, 0.1f, 0.8f) - 0.1) * 2500) + 5000;

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
       

    }

    void position_limite()
    {
       
        if (rig.position.x > 51)
        {
            rig.position = new Vector2(51, rig.position.y);
        }
        if (rig.position.x < -37.8f)
        {
            rig.position = new Vector2(-37.8f, rig.position.y);
        }
    }

}

