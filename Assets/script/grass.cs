﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass : MonoBehaviour {

    private GameObject slime;
    private float start_time;


    // Use this for initialization
    void Start () {
        start_time = Time.time;
        slime = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        check();

    }
    void check()
    {
        if(Time.time - start_time > 2)
        {
            if (Mathf.Abs(transform.position.y - slime.transform.position.y) > 30)
            {
                //Debug.Log("OK");
                Destroy(this.gameObject);
            }
            start_time = Time.time;
        }
    }

}
