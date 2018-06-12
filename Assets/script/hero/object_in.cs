using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_in: MonoBehaviour {

    public bool the_object_in = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerExit2D(Collider2D other)
    {
        the_object_in = false;
    }
    void OnTriggerEnter2D()
    {
        the_object_in = true;
    }
}
