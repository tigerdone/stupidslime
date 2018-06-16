using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class begin : MonoBehaviour {

    public GameObject Attack;
    public GameObject move;
    public GameObject jump;

    private bool is_begin = false;
    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 10);
        move.GetComponent<move>().enabled = false;
        jump.GetComponent<jump>().enabled = false;
        Attack.GetComponent<attack>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time>9&&!is_begin)
        {
            is_begin = true;
            move.GetComponent<move>().enabled = true;
            jump.GetComponent<jump>().enabled = true;
            Attack.GetComponent<attack>().enabled = true;
        }
        

    }

}
