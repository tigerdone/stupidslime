using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

    public GameObject slime;
    public GameObject arrow;

    private float add_x = 5f;
    private float add_y = 7f;
    private GameObject the_arrow;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        draw_arrow();
    }
    void draw_arrow()
    {
        Vector3 rotation = new Vector3(0, 0, 60);
        Quaternion RanRota = Quaternion.Euler(rotation);

        Vector3 test3;
        Vector3 test4;



        if (Input.GetMouseButtonDown(0))
        {
            the_arrow = Instantiate(arrow, new Vector3(slime.transform.position.x + add_x,
                slime.transform.position.y + add_y, slime.transform.position.z),
                RanRota);
            test3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Debug.Log("test3_mousePosition" + test3);
            //Debug.Log("slime.transform.position" + slime.transform.position);

            test4 = new Vector3(slime.transform.position.x, slime.transform.position.y-5, slime.transform.position.z);
            Debug.Log(GetAngle(test4, test3));

        }
        //if (Input.GetMouseButton(0))
        //{

        //    RanRota = Quaternion.Euler(rotation);
        //    the_arrow.transform.rotation = RanRota;
        //}
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(the_arrow);
        }

        //if (Input.GetMouseButtonDown(1))
        //    Debug.Log("Pressed secondary button.");


        //if (Input.GetMouseButtonDown(2))
        //    Debug.Log("Pressed middle click.");
    }

    private float GetAngle(Vector3 a, Vector3 b)
    {
        b.x -= a.x;
        b.y -= a.y;

        float deltaAngle = 0;
        if (b.x == 0 && b.y == 0)
        {
            return 0;
        }
        else if (b.x > 0 && b.y > 0)
        {
            deltaAngle = 0;
        }
        else if (b.x > 0 && b.y == 0)
        {
            return 90;
        }
        else if (b.x > 0 && b.y < 0)
        {
            deltaAngle = 180;
        }
        else if (b.x == 0 && b.y < 0)
        {
            return 180;
        }
        else if (b.x < 0 && b.y < 0)
        {
            deltaAngle = -180;
        }
        else if (b.x < 0 && b.y == 0)
        {
            return -90;
        }
        else if (b.x < 0 && b.y > 0)
        {
            deltaAngle = 0;
        }

        float angle = Mathf.Atan(b.x / b.y) * Mathf.Rad2Deg + deltaAngle;
        return angle;
    }
}
