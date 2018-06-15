using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {


    public GameObject the_camera;
    public GameObject[] tiers;
    public Rigidbody2D rig;

    public GameObject score;
    public GameObject death_font;

    //public bool bool_death = false;
    // Use this for initialization
    void Start () {
        the_camera = GameObject.FindGameObjectWithTag("MainCamera");
        tiers = GameObject.FindGameObjectsWithTag("tier");
        rig = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        v_death();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            get_death();
        }
    }
    void v_death()
    {
        if (rig.velocity.y < -70 )
        {
            //Debug.Log(rig.velocity.y+"death");
            get_death();
        }
    }
    void get_death()
    {
        //Debug.Log("death");
        Collider2D[] cols = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }
        GetComponent<move>().enabled = false;
        GetComponent<jump>().enabled = false;
        the_camera.GetComponent<camera_follow>().enabled = false;
        foreach (var item in tiers)
        {
            item.GetComponent<bg_move>().enabled = false;
        }
        //bool_death = true;

        score.transform.position = new Vector3(628, 246, 0);
        death_font.transform.position = new Vector3(641, 322, 0);

        //anim.SetTrigger("Die");
        //the_camera.enabled = false;
    }
}
