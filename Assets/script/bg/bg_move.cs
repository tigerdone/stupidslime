using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_move : MonoBehaviour
{

    public float ScaleY = 0.8f;

    //public Tr


    public Transform player;       // Reference to the player's transform.
    //private float increment = 0f; //增量
    private float per_position = 0f; //前一位置坐标


    // Use this for initialization
    void Start()
    {
        per_position = player.position.y;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        Trackbg();
    }


    void Trackbg()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetY = transform.position.y;
        //float targetY = transform.position.y;

        targetY = transform.position.y - (player.position.y - per_position) * ScaleY;
        //targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        per_position = player.position.y;
        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(transform.position.x,targetY, transform.position.z);
    }
}
