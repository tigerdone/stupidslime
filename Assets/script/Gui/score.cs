using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    //public GameObject GO;

    public num_stair num_Stair;
    public attack Attack;

    private int box_num_master = 0;

    private Text the_score;

    public int num_attack = 0;


    //外部改变num_master
    public int num_master = 0;

    private int Count = 0;
    private int all_score;
    //private float the_time;
    // Use this for initialization
    void Start()
    {
        the_score = this.GetComponent<Text>();
        //the_time = Time.time;
    }

    void Update()
    {
        up_date();
    }

    void add()
    {
        the_score.text = "score:" + all_score.ToString();
        //"score" +
    }
    void up_date()
    {
        if (Count != num_Stair.stair_th || box_num_master != num_master|| Attack.attack_num != num_attack)
        {
            Count = num_Stair.stair_th;
            num_attack = Attack.attack_num;
            box_num_master = num_master;

            all_score = Count * 10+ num_master*30 + num_attack*(-15);
            add();
        }
        
    }
    //void check_death()
    //{
    //    if (true)
    //    {

    //    }
    //}

}
