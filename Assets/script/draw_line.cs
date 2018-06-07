using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw_line : MonoBehaviour {

    public move the_move;

    public Material material;

    public Transform origin;
    public Camera my_camera;


    private List<Vector3> lineInfo;
    //private List<Vector3> lineInfo2;
    // Use this for initialization
    void Start()
    {
        //初始化鼠标线段链表
        lineInfo = new List<Vector3>();

    }
    void FixedUpdate()
    {
        //Debug.Log(the_move.force);
        lineInfo = add_Info();

    }
    private void OnPostRender()
    {
        if (!material)
        {
            Debug.LogError("请给材质资源赋值");
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //lineInfo
            //Debug.Log(lineInfo.Count);

            material.SetPass(0);//设置该材质通道，0为默认值
            GL.LoadOrtho();//设置绘制2D图像
            GL.Begin(GL.LINES);//表示开始绘制，绘制类型为线段 
            for (int i = 0; i < lineInfo.Count - 1; i++)
            {
                Vector3 start = lineInfo[i];
                Vector3 end = lineInfo[i + 1];
                //绘制线段
                DrawLine(start.x, start.y, end.x, end.y);
                //GL.Vertex(lineInfo[i]);
                //Debug.Log(lineInfo[i]);

            }
            GL.End();
            //Debug.Log("ok");
        }
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    GL.LoadOrtho();//设置绘制2D图像
        //    GL.Begin(GL.LINES);//表示开始绘制，绘制类型为线段 
        //    DrawLine(0f, 0f, 0f, 0f);

        //    GL.End();
        //}
        
    }

    // Update is called once per frame
   
    private void DrawLine(float x1, float y1, float x2, float y2)
    {
        //绘制线段，需要将屏幕中某个点的像素坐标点除以屏幕宽或高
        //GL.Vertex(new Vector3(x1 / Screen.width, y1 / Screen.height, 0));// [ˈvɜ:ˌteks] 最高点；顶点
        //GL.Vertex(new Vector3(x2 / Screen.width, y2 / Screen.height, 0));
        GL.Vertex(new Vector3(x1, y1, 0));// [ˈvɜ:ˌteks] 最高点；顶点
        //GL.Vertex(new Vector3(x2, y2, 0));
    }

    //画线
    List<Vector3> add_Info()
    {
        lineInfo = new List<Vector3>();

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 position = origin.position;
            Vector3 position2;

            //Debug.Log(position);
            //Debug.Log(camera.WorldToScreenPoint(position));

            //Vector3 pos = cam.WorldToViewportPoint(Boy.position);

            int x = the_move.force;
            //Debug.Log(x);
            for (; x > 0;)
            {
                position2 = position;
                position2 = my_camera.WorldToScreenPoint(position2);
                position2 = my_camera.ScreenToViewportPoint(position2);

                lineInfo.Add(position2);
                x -= 100;
                position.y += 0.5f;

            }
        }
        return lineInfo;
    }

}
