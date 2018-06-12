using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour {

    private Rigidbody2D body;
    private Collider2D[] colliders;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        colliders = GetComponentsInChildren<Collider2D>();
       
    }

    // Update is called once per frame
    void Update () {
        if (body.velocity.y > 0)
        {
            getup();
        }
        else
        {
            getdown();
        }
    }
    void getup()
    {
        foreach (Collider2D child in colliders)
        {
            child.isTrigger = true;
        }
    }
    void getdown()
    {
        foreach (Collider2D child in colliders)
        {
            child.isTrigger = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        getdown();

        //Debug.Log("触发器结束:" + other.gameObject.name);
    }

}
