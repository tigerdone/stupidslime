using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_grass : MonoBehaviour {

    public GameObject grass;
    public GameObject slime;
    public GameObject monster;
    public GameObject bron_monster;

    public int score = 0;

    //public GameObject wall;

    public float h = 1f;

    private float direction = 1;


    public int count = 0;
    public int count_wall = 0;

    public float interval = 10f;
    //public float interval_wall = 68f;

    public float nest_grass_y = 35.4f;
    //public float nast_wall_y = 78.9f;

    public float far_stair = 60f;

    //private GameObject[] stairs;

    public GameObject the_monster;

    private GameObject box_monster;

    private Rigidbody2D rig;

    [HideInInspector]
    public ArrayList stairs = new ArrayList();

    private float last_slime_position;

    private int stair_num = 1;


    //private float last_wall_position;
    // Use this for initialization
    void Start () {
        //get_score = GameObject.FindGameObjectWithTag("aa");

        last_slime_position = slime.transform.position.y;
        //last_wall_position = last_slime_position;
    }
	
	// Update is called once per frame
	void Update () {
        add_count();
        init_grass();
        //init_wall();
        add_stair();
        bron_master();
    }

    void add_count()
    {
        if (slime.transform.position.y - last_slime_position > interval)
        {
            count++;
            last_slime_position = slime.transform.position.y;
        }
        //if (slime.transform.position.y - last_wall_position > interval_wall)
        //{
        //    count_wall++;
        //    last_wall_position = slime.transform.position.y;
        //}
    }
    void init_grass()
    {
        float x_position = 0;
        x_position = Random.Range(-15, 36);

        if (count > 0)
        {
            stairs.Add(Instantiate(grass, new Vector3(x_position, nest_grass_y, 3), Quaternion.identity));
            count--;
            nest_grass_y += 10;

        }
    }
    //void init_wall()
    //{

    //    if (count_wall > 0)
    //    {
    //        Instantiate(wall, new Vector3(7.2f, nast_wall_y, 5.28f), Quaternion.identity);
    //        count_wall--;
    //        nast_wall_y += 68;

    //    }
    //}
    void add_stair()
    {
        if(nest_grass_y - slime.transform.position.y < far_stair)
        {
            count++;
        }
    }
    void bron_master()
    {
        if(stair_num < stairs.Count)
        {
            box_monster = stairs[stair_num] as GameObject;
            if (box_monster.transform.position.y - slime.transform.position.y < 12)
            {
                direction = Random.value;

                if (direction > 0.6)
                {
                    //if (direction > 0.8)
                    //{
                    //    direction = -1;
                    //}
                    Instantiate(bron_monster,
                            new Vector3(box_monster.transform.position.x, 
                            box_monster.transform.position.y + h + 1, box_monster.transform.position.z - 1),
                            Quaternion.identity);

                    the_monster = Instantiate(monster,
                            new Vector3(box_monster.transform.position.x, 
                            box_monster.transform.position.y + h + 1, box_monster.transform.position.z + 1),
                            Quaternion.identity);
                    rig = the_monster.GetComponent<Rigidbody2D>();
                    rig.velocity = new Vector2(10* direction, 0);

                }
                stair_num++;

            }
        }
       
    }


}
