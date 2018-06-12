using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour {


    private Collider2D the_bubble;
    private Rigidbody2D rig;

    private bool object_in = true;
    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 3);
        the_bubble = GetComponent<Collider2D>();
        rig = GetComponent<Rigidbody2D>();
        the_bubble.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
        //OnTrigger2DExit();
        set_trigger();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        object_in = false;
    }
    void OnTriggerEnter2D()
    {
        object_in = true;
    }
    void set_trigger()
    {
        if (rig.velocity.y < 0 && !object_in && the_bubble.isTrigger)
        {
            the_bubble.isTrigger = false;

        }
        if (rig.velocity.y > 0 && !object_in && !the_bubble.isTrigger)
        {
            the_bubble.isTrigger = true;

        }
    }

}
