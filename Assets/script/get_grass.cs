using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_grass : MonoBehaviour {

    public GameObject grass;
    public GameObject slime;
    //public GameObject wall;


    public int count = 0;
    public int count_wall = 0;

    public float interval = 10f;
    //public float interval_wall = 68f;

    public float nast_grass_y = 35.4f;
    //public float nast_wall_y = 78.9f;



    private float last_slime_position;
    //private float last_wall_position;
    // Use this for initialization
    void Start () {
        last_slime_position = slime.transform.position.y;
        //last_wall_position = last_slime_position;
    }
	
	// Update is called once per frame
	void Update () {
        add_count();
        init_grass();
        //init_wall();
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
            Instantiate(grass, new Vector3(x_position, nast_grass_y, 3), Quaternion.identity);
            count--;
            nast_grass_y += 10;

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
}
