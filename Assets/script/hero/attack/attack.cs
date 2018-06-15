using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

    public GameObject slime;
    public GameObject arrow;
    
    public GameObject Bubble;
    public Animator anim;
    public float bullet_force = 1000f;

    public int attack_num =  0;

    private float add_x = 0f;
    private float add_y = 0f;

    private GameObject the_arrow;
    private GameObject the_Bubble;

    private float angle;



    // Use this for initialization
    void Start () {
        //Debug.Log("Sin:" + Mathf.Sin(30/ Mathf.Rad2Deg));

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
        //Vector3 test4;
        float distance = 0;
        float add_scale = 0;
        Vector3 mousePosition = new Vector3(0, 0, 60);


        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetTrigger("attack_prepare");

            test3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle = GetAngle(slime.transform.position, test3);

            distance = (slime.transform.position - test3).sqrMagnitude;
            distance = Mathf.Clamp(distance, 240f, 540f);
            add_scale = (distance - 240) / 300 * 0.24f + 0.36f;

            //Debug.Log(distance);
            rotation = new Vector3(0, 0, 90-angle);
            RanRota = Quaternion.Euler(rotation);

            the_arrow = Instantiate(arrow, new Vector3(slime.transform.position.x,
                slime.transform.position.y, slime.transform.position.z),
                RanRota);

            the_arrow.transform.localScale = new Vector3(add_scale, 
                the_arrow.transform.localScale.y, the_arrow.transform.localScale.z);

        }
        if (Input.GetMouseButton(0))
        {
            if (true)
            {
                test3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                angle = GetAngle(slime.transform.position, test3);
                //Debug.Log(angle);
                rotation = new Vector3(0, 0, 90 - angle);
                RanRota = Quaternion.Euler(rotation);
                the_arrow.transform.rotation = RanRota;
                the_arrow.transform.position = slime.transform.position;
                mousePosition = Input.mousePosition;

                distance = (slime.transform.position - test3).sqrMagnitude;
                distance = Mathf.Clamp(distance, 240f, 540f);
                add_scale = (distance - 240) / 300 * 0.24f + 0.36f;

                bullet_force = (distance - 240) / 300 * 500f + 1500f;

                the_arrow.transform.localScale = new Vector3(add_scale,
                the_arrow.transform.localScale.y, the_arrow.transform.localScale.z);

            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            //anim.SetTrigger("attacked");
            anim.Play("attack", 0, 0);
            the_Bubble = Instantiate(Bubble, new Vector3(slime.transform.position.x + add_x,
               slime.transform.position.y + add_y, slime.transform.position.z),
               RanRota);
            //the_Bubble.rigidbody2D.AddForce(new Vector2(0, 100));
            attack_num++;
            getfouce(the_Bubble, angle+20);
            Destroy(the_arrow);

        }

        //if (Input.GetMouseButtonDown(1))
        //    Debug.Log("Pressed secondary button.");


        //if (Input.GetMouseButtonDown(2))
        //    Debug.Log("Pressed middle click.");
    }

    void getfouce(GameObject aa,float angle)
    {
        Rigidbody2D rig;
        rig = aa.GetComponent<Rigidbody2D>();

        //Debug.Log(Mathf.Sin(90 - angle));
        rig.AddForce(new Vector2(Mathf.Cos(90- angle/ Mathf.Rad2Deg) * bullet_force, 
            Mathf.Sin(90- angle/Mathf.Rad2Deg) * bullet_force));
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
