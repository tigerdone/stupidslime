using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour {

    private Rigidbody2D rig;
    private SpriteRenderer Sprites;
    public Sprite the_sprite;

    //private La Sprites;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        Sprites = GetComponent<SpriteRenderer>();
        //the_sprite = Resources.Load("../spirit/d_monster", typeof(Sprite)) as Sprite;
    }

    // Update is called once per frame
    void Update () {
		
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
        }
    }
}
