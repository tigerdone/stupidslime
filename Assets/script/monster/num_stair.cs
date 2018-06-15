using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class num_stair : MonoBehaviour {

    public int stair_th = 0;

    //public get_grass get_Grass;

    private GameObject stair;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "stair")
        {
            //int i = get_Grass.stairs.Count - 1;

            //stair = get_Grass.stairs[i] as GameObject;
            stair_th = (int)(transform.position.y/10);
            //Debug.Log("stair");
            //if (other.gameObject.transform.position.y == stair.transform.position.y)
            //{
            //    stair_th = i;
            //}
        }
        
    }
}
