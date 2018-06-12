using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_move1 : MonoBehaviour {

    public GameObject bg1;
    public GameObject bg2;
    public GameObject slime;

    public GameObject flower1;
    public GameObject flower2;
    public GameObject flower3;
    public GameObject flower4;

    //private GameObject flowerclone1;
    //private GameObject flowerclone2;
    //private GameObject flowerclone3;
    //private GameObject flowerclone4;

    private ArrayList flowerclone1 = new ArrayList();
    private ArrayList flowerclone2 = new ArrayList();
    private ArrayList flowerclone3 = new ArrayList();
    private ArrayList flowerclone4 = new ArrayList();



    // Use this for initialization
    void Start () {
        get_flower();

    }

    // Update is called once per frame
    void Update () {
        change();
    }
    void change()
    {
        if (slime.transform.position.y - transform.position.y > 150)
        {
            if (bg1.transform.position.y > bg2.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, 
                    bg1.transform.position.y + 68f, transform.position.z);

                move_flower();

                //flowerclone1.transform.position = new Vector3(flowerclone1.transform.position.x,
                //    flowerclone1.transform.position.y + 136f, flowerclone1.transform.position.z);

                //flowerclone2.transform.position = new Vector3(flowerclone2.transform.position.x,
                //    flowerclone2.transform.position.y + 136f, flowerclone2.transform.position.z);

                //flowerclone3.transform.position = new Vector3(flowerclone3.transform.position.x,
                //    flowerclone3.transform.position.y + 136f, flowerclone3.transform.position.z);

                //flowerclone4.transform.position = new Vector3(flowerclone4.transform.position.x,
                //    flowerclone4.transform.position.y + 136f, flowerclone4.transform.position.z);

            }
            else
            {
                transform.position = new Vector3(transform.position.x,
                   bg2.transform.position.y+68f, transform.position.z);
                move_flower();


            }

            transform.localScale = new Vector3(transform.localScale.x,
                transform.localScale.y * (-1), transform.localScale.z);
        }
       
    }

    void get_flower()
    {
        float x_position = 0;
        float y_position = 0;

        for (int i = 0; i < 3; i++)
        {
            x_position = Random.Range(-30, 30);
            y_position = Random.Range(-32, 32);
            flowerclone1.Add(Instantiate(flower1, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 4), Quaternion.identity));

            x_position = Random.Range(-30, 30);
            y_position = Random.Range(-32, 32);
            flowerclone2.Add(Instantiate(flower2, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 4), Quaternion.identity));

            x_position = Random.Range(-30, 30);
            y_position = Random.Range(-32, 32);
            flowerclone3.Add(Instantiate(flower3, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 4), Quaternion.identity));

            x_position = Random.Range(-30, 30);
            y_position = Random.Range(-32, 32);
            flowerclone4.Add(Instantiate(flower4, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 4), Quaternion.identity));
    
        }
    }
    void move_flower()
    {
        //float x_position = 0;
        //float y_position = 0;


        foreach (GameObject item in flowerclone1)
        {
            //x_position = Random.Range(-30, 30);
            //y_position = Random.Range(-32, 32);
            item.transform.position = new Vector3(item.transform.position.x,
                item.transform.position.y + 204f, item.transform.position.z);
        }
        foreach (GameObject item in flowerclone2)
        {
            //x_position = Random.Range(-30, 30);
            //y_position = Random.Range(-32, 32);
            item.transform.position = new Vector3(item.transform.position.x,
                item.transform.position.y + 204f, item.transform.position.z);
        }
        foreach (GameObject item in flowerclone3)
        {
            //x_position = Random.Range(-30, 30);
            //y_position = Random.Range(-32, 32);
            item.transform.position = new Vector3(item.transform.position.x,
                item.transform.position.y + 204f, item.transform.position.z);
        }
        foreach (GameObject item in flowerclone4)
        {
            //x_position = Random.Range(-30, 30);
            //y_position = Random.Range(-32, 32);
            item.transform.position = new Vector3(item.transform.position.x,
                item.transform.position.y + 204f, item.transform.position.z);
        }
    }

}
