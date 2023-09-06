using UnityEngine;
using System.Collections;
public class GLLine : MonoBehaviour
{
    public int circleCount = 6;
    public float circleRadius;
    public int lineCount = 100;
    public float radius = 3.0f;
    public int triangleSize = 2;
    public int quadSize = 2;
    //使用LINE_STRIP

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.  //  Hidden/Internal-Colored
            Shader shader = Shader.Find("Custom/wzyshader");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //开启单面双面
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    private bool oldCulling;
    public void OnPreRender()
    {
        oldCulling = GL.invertCulling;
        GL.invertCulling = false;
    }


    //只能渲染2D
    public void OnPostRender() {
        //CreateLineMaterial();
        //GL.LoadOrtho();//设置绘制2D图像
        //GL.PushMatrix();

        //////画从左下到右上的线                                   
        //GL.Begin(GL.LINES);
        //GL.Color(Color.red);
        //GL.Vertex(new Vector2(0, 0));
        //GL.Vertex(new Vector2(1, 1));
        //GL.End();

        ////画从左上到右下的线                                                                                                         //
        //GL.Begin(GL.LINES);
        //GL.Color(Color.yellow);
        //GL.Vertex(new Vector2(0, 1));
        //GL.Vertex(new Vector2(1, 0));
        //GL.End();


        ////画填充多边形
        //GL.Begin(GL.QUADS);
        //GL.Color(Color.green);
        //GL.Vertex(new Vector2(0.1f, 0.1f));
        //GL.Vertex(new Vector2(0.1f, 0.2f));
        //GL.Vertex(new Vector2(0.2f, 0.2f));
        //GL.Vertex(new Vector2(0.2f, 0.1f));
        //GL.End();


        //GL.End();
        //GL.PopMatrix();
    }


    //可以渲染3D
    void OnRenderObject()
    {
        CreateLineMaterial();
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);


        // Draw lines
        //GL.Begin(GL.LINES);
        //for (int i = 0; i < lineCount; ++i)
        //{
        //    float a = i / (float)lineCount;
        //    float angle = a * Mathf.PI * 2;
        //    // Vertex colors change from red to green
        //    GL.Color(new Color(a, 1 - a, 0, 0.8F));
        //    // One vertex at transform position
        //    GL.Vertex3(0, 0, 0);
        //    // Another vertex at edge of circle
        //    GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
        //}
        //GL.End();



        //GL.QUADS
        //GL.Begin(GL.QUADS);
        //GL.Color(Color.yellow);
        //GL.Vertex(new Vector2(3f, 3f));
        //GL.Vertex(new Vector2(3f, 4f));
        //GL.Vertex(new Vector2(4f, 4f));
        //GL.Vertex(new Vector2(4f, 3f));
        //GL.End();


        //// GL.LINE_STRIP
        //DrawCircle();

        //// GL.TRIANGLE 三角形
        //DrawTriangle();

        //// GL.TRIANGLES 四边形 两个三角形
        //DrawTriangles();

        // 绘制立方体
        DrawCube();

        GL.PopMatrix();
    }


    private void DrawCircle()
    {
        float angleDelta = 2 * Mathf.PI / circleCount;
        GL.Begin(GL.LINE_STRIP);
        for (int i = 0; i < circleCount + 1; i++)
        {
            float angle = angleDelta * i;
            float angleNext = angle + angleDelta;
            if (i % 2 == 0)
            {
                GL.Color(Color.red);
            }
            else
            {
                GL.Color(Color.green);
            }

            GL.Vertex3(Mathf.Cos(angle) * circleRadius, Mathf.Sin(angle) * circleRadius, 0);
        }
        GL.End();
    }




    //使用TRIANGLES进行绘制三角形
    private void DrawTriangle()
    {
        GL.Begin(GL.TRIANGLES);
        //顺时针
        GL.Color(Color.red);
        GL.Vertex3(-triangleSize, -triangleSize, 0);//左下
        GL.Color(Color.green);
        GL.Vertex3(0, triangleSize, 0);//上     
        GL.Color(Color.blue);
        GL.Vertex3(triangleSize, -triangleSize, 0);//右下
        GL.End();
    }


    //TRIANGLE_STRIP 目标：共用顶点
    private void DrawTriangles()
    {
        GL.Begin(GL.TRIANGLE_STRIP);
        GL.Color(Color.red);
        GL.Vertex3(-triangleSize, -triangleSize, 0);
        GL.Color(Color.green);
        GL.Vertex3(0, triangleSize, 0);
        GL.Color(Color.blue);
        GL.Vertex3(triangleSize, -triangleSize, 0);
        GL.Color(Color.yellow);
        GL.Vertex3(triangleSize, triangleSize, 0);
        GL.End();
    }

    //目标：Unity左手坐标系
    //绘制CUBE的代码
    private void DrawCube()
    {
        GL.Begin(GL.QUADS);

        //正面
        GL.Color(Color.red);
        GL.Vertex3(-quadSize, -quadSize, -quadSize);
        GL.Vertex3(quadSize, -quadSize, -quadSize);
        GL.Vertex3(quadSize, quadSize, -quadSize);
        GL.Vertex3(-quadSize, quadSize, -quadSize);

        GL.Color(Color.green);
        GL.Vertex3(-quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, quadSize, quadSize);
        GL.Vertex3(-quadSize, quadSize, quadSize);

        GL.Color(Color.blue);
        GL.Vertex3(quadSize, -quadSize, -quadSize);
        GL.Vertex3(quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, quadSize, quadSize);
        GL.Vertex3(quadSize, quadSize, -quadSize);

        GL.Color(Color.yellow);
        GL.Vertex3(-quadSize, -quadSize, -quadSize);
        GL.Vertex3(-quadSize, -quadSize, quadSize);
        GL.Vertex3(-quadSize, quadSize, quadSize);
        GL.Vertex3(-quadSize, quadSize, -quadSize);

        //底面
        GL.Color(Color.gray);
        GL.Vertex3(-quadSize, -quadSize, -quadSize);
        GL.Vertex3(-quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, -quadSize, -quadSize);


        //顶面
        GL.Color(Color.black);
        GL.Vertex3(-quadSize, quadSize, -quadSize);
        GL.Vertex3(quadSize, quadSize, -quadSize);
        GL.Vertex3(quadSize, quadSize, quadSize);
        GL.Vertex3(-quadSize, quadSize, quadSize);

        GL.End();
    }

    void OnGUI()//所有关于GUI的绘制只能写在这个方法里面，不过可以将此脚本赋予给其它物体，不一定是主摄像机
    {
        //string string_content = "线";
        //GUIStyle fontStyle = new GUIStyle();
        //fontStyle.normal.background = null;   //设置背景填充
        //fontStyle.normal.textColor = Color.white;//设置字体颜色
        //fontStyle.fontSize = 24;//字体大小
        //Vector2 string_size = fontStyle.CalcSize(new GUIContent(string_content));//根据设置的样式求得字体具体的尺寸
        //GUI.Label(new Rect(0, 0, string_size.x, string_size.y), string_content, fontStyle);
    }
}