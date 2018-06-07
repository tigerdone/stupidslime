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



    // Use this for initialization
    void Start () {
        //get_flower();

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
            }
            else
            {
                transform.position = new Vector3(transform.position.x,
                   bg2.transform.position.y+68f, transform.position.z);
            }
            transform.localScale = new Vector3(transform.localScale.x,
                transform.localScale.y * (-1), transform.localScale.z);
        }
       
    }

    void get_flower()
    {
        float x_position = 0;
        float y_position = 0;

        for (int i = 0; i < 4; i++)
        {
            x_position = Random.Range(-30, 30);
            y_position = Random.Range(-40, 40);
            Instantiate(flower1, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 3), Quaternion.identity);
            Instantiate(flower2, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 3), Quaternion.identity);
            Instantiate(flower3, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 3), Quaternion.identity);
            Instantiate(flower4, new Vector3(x_position + transform.position.x,
                y_position + transform.position.y, 3), Quaternion.identity);
    
        }
    }


}
