using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsetr_ai : MonoBehaviour {

    public GameObject monster;
    public GameObject bron_monster;
    //public GameObject slime;

    public float h = 1f;

    private Rigidbody2D rig;

    private float direction = 1;
    private float the_time = 1;


    private GameObject the_monster;

    private bool have_master = false;

    // Use this for initialization
    void Start () {

        //rig = GetComponent<Rigidbody2D>();
        //rig.velocity = new Vector2(10*direction, 0);
        //slime = gameObject.FindGameObjectWithTag("");
    }
	
	// Update is called once per frame
	void Update () {
        if(the_monster != null)
        {
            monster_contral();
        }
        //init_monster();
    }
    //void Oncoli

    void monster_contral()
    {
        if(Mathf.Abs(transform.position.x - the_monster.transform.position.x) > 7f&&(Time.time - the_time)>0.1)
        {
            direction = -1 * direction;
            rig.velocity = new Vector2(10 * direction, 0);
            the_time = Time.time;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //other.SpriteRenderer = 
        //Debug.Log("monsetr_ai:OnTriggerEnter2D");
    }

    void init_monster()
    {
        //if (!have_master&&transform.position.y - slime.transform.position.y < 15)
        if (!have_master)
        {
            have_master = true;
            direction = Random.value;
            //Debug.Log(direction);
            if (direction > 0.6)
            {
                if (direction > 0.8)
                {
                    direction = -1;
                }
                Instantiate(bron_monster,
                    new Vector3(transform.position.x, transform.position.y + h + 1, transform.position.z - 1),
                    Quaternion.identity);

                the_monster = Instantiate(monster,
                    new Vector3(transform.position.x, transform.position.y + h, transform.position.z + 1),
                    Quaternion.identity);

                //Debug.Log(transform.position.y + h);
                rig = the_monster.GetComponent<Rigidbody2D>();
                rig.velocity = new Vector2(10 * direction, 0);

            }
            the_time = Time.time;

        }
    }

}

