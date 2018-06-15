using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour {

    private Rigidbody2D rig;
    private SpriteRenderer Sprites;
    public Sprite the_sprite;

    public score get_num_master;

    //private La Sprites;
    private float direction = 1;
    private float the_time = 0;

    private GameObject stair;

    private bool contral = false;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        Sprites = GetComponent<SpriteRenderer>();
        //the_sprite = Resources.Load("../spirit/d_monster", typeof(Sprite)) as Sprite;
        get_num_master = GameObject.FindGameObjectWithTag("text").GetComponent<score>();
        the_time = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (stair != null)
        {
            monster_contral();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Sprites = other.GetComponent =
        //Debug.Log("monster:OnTriggerEnter2D");
        //object_in = true;
        if(other.tag == "bullet")
        {
            rig.velocity = new Vector2(0, 0);
            Destroy(other.gameObject);
            Sprites.sprite = the_sprite;
            gameObject.layer = LayerMask.NameToLayer("UI");
            get_num_master.num_master++;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            rig.velocity = new Vector2(0, 0);
            Destroy(other.gameObject);
            Sprites.sprite = the_sprite;
            gameObject.layer = LayerMask.NameToLayer("UI");
            get_num_master.num_master++;

        }
        if (other.gameObject.tag == "Player")
        {
            rig.velocity = new Vector2(0, 0);
            //Destroy(other.gameObject);
            //Sprites.sprite = the_sprite;
            //gameObject.layer = LayerMask.NameToLayer("UI");
        }
        if (!contral&&other.gameObject.tag == "stair")
        {
            contral = true;
            stair = other.gameObject;
            //if (Mathf.Abs(transform.position.x - other.gameObject.transform.position.x) > 7f && (Time.time - the_time) > 0.1)
            //{
            //    direction = -1 * direction;
            //    rig.velocity = new Vector2(10 * direction, 0);
            //    the_time = Time.time;
            //}
        }

    }
    void monster_contral()
    {
        if (Mathf.Abs(transform.position.x - stair.transform.position.x) > 7f && (Time.time - the_time) > 0.4)
        {
            direction = -1 * direction;
            rig.velocity = new Vector2(10 * direction, 0);
            the_time = Time.time;
        }
    }
}
