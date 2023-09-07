using UnityEngine;
using System.Collections;
using static GLline2;

public enum DrawingType
{
    DRAW_CIRCLE,
    DRAW_TRIANGLE,
    DRAW_TRINAGLES,
    DRAW_CUBE,
    DRAW_PIC
}

public class GLLine : MonoBehaviour
{
    #region Para
    public DrawingType type = DrawingType.DRAW_CIRCLE;
    public int circleRadius = 3;
    public bool _bRotate = false;
    private bool oldCulling;
    public int circleCount = 6;
    public int lineCount = 100;
    public float radius = 3.0f;
    public int triangleSize = 2;
    public int quadSize = 2;
    #endregion

    #region 材质设置
    private Material _shapeMaterial;
    //static Material lineMaterial;
    private void SetMaterialPass()
    {
        if (_shapeMaterial == null)
        {
            _shapeMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
        }

        _shapeMaterial.SetPass(0);

        _shapeMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //开启单面双面
    }


    //static void CreateLineMaterial()
    //{
    //    if (!lineMaterial)
    //    {
    //        // simple colored things.  //  Hidden/Internal-Colored
    //        //Shader shader = Shader.Find("Universal Render Pipeline/Lit");
    //        Shader shader = Shader.Find("Unlit/Color");
    //        lineMaterial = new Material(shader);
    //        lineMaterial.hideFlags = HideFlags.HideAndDontSave;

    //        //lineMaterial.SetColor("_BaseColor",Color.blue);  //开启单面双面

    //        // Turn on alpha blending
    //        lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
    //        lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

    //        // Turn backface culling off
    //        lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //开启单面双面
    //        // Turn off depth writes
    //        lineMaterial.SetInt("_ZWrite", 0);
    //    }
    //}
    #endregion

    #region 渲染生命周期
    //public void OnPreRender()
    //{
    //    //oldCulling = GL.invertCulling;
    //    //GL.invertCulling = false;
    //}

    //只能渲染2D
    //public void OnPostRender()
    //{
    //    //CreateLineMaterial();
    //    //GL.LoadOrtho();//设置绘制2D图像
    //    //GL.PushMatrix();

    //    //////画从左下到右上的线                                   
    //    //GL.Begin(GL.LINES);
    //    //GL.Color(Color.red);
    //    //GL.Vertex(new Vector2(0, 0));
    //    //GL.Vertex(new Vector2(1, 1));
    //    //GL.End();

    //    ////画从左上到右下的线                                                                                                         //
    //    //GL.Begin(GL.LINES);
    //    //GL.Color(Color.yellow);
    //    //GL.Vertex(new Vector2(0, 1));
    //    //GL.Vertex(new Vector2(1, 0));
    //    //GL.End();


    //    ////画填充多边形
    //    //GL.Begin(GL.QUADS);
    //    //GL.Color(Color.green);
    //    //GL.Vertex(new Vector2(0.1f, 0.1f));
    //    //GL.Vertex(new Vector2(0.1f, 0.2f));
    //    //GL.Vertex(new Vector2(0.2f, 0.2f));
    //    //GL.Vertex(new Vector2(0.2f, 0.1f));
    //    //GL.End();


    //    //GL.End();
    //    //GL.PopMatrix();
    //}

    //可以渲染3D
    #region MYCode

    //void OnRenderObject()
    //{
    //    Debug.Log("设置材质!");
    //    //CreateLineMaterial();
    //    SetMaterialPass();

    //    lineMaterial.SetPass(0);

    //    GL.PushMatrix();
    //    GL.MultMatrix(transform.localToWorldMatrix);


    //    // Draw lines
    //    //GL.Begin(GL.LINES);
    //    //for (int i = 0; i < lineCount; ++i)
    //    //{
    //    //    float a = i / (float)lineCount;
    //    //    float angle = a * Mathf.PI * 2;
    //    //    // Vertex colors change from red to green
    //    //    GL.Color(new Color(a, 1 - a, 0, 0.8F));
    //    //    // One vertex at transform position
    //    //    GL.Vertex3(0, 0, 0);
    //    //    // Another vertex at edge of circle
    //    //    GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
    //    //}
    //    //GL.End();



    //    //GL.QUADS
    //    //GL.Begin(GL.QUADS);
    //    //GL.Color(Color.yellow);
    //    //GL.Vertex(new Vector2(3f, 3f));
    //    //GL.Vertex(new Vector2(3f, 4f));
    //    //GL.Vertex(new Vector2(4f, 4f));
    //    //GL.Vertex(new Vector2(4f, 3f));
    //    //GL.End();


    //    //// GL.LINE_STRIP
    //    //DrawCircle();

    //    //// GL.TRIANGLE 三角形
    //    //DrawTriangle();

    //    //// GL.TRIANGLES 四边形 两个三角形
    //    //DrawTriangles();

    //    // 绘制立方体
    //    DrawCube2();

    //    //绘制图片
    //    DrawPic();

    //    GL.PopMatrix();
    //}
    #endregion

    private void OnRenderObject()
    {
        SetMaterialPass();

        GL.PushMatrix();
        GL.MultMatrix(transform.localToWorldMatrix);
        switch (type)
        {
            case DrawingType.DRAW_CIRCLE:
                DrawCircle();
                break;
            case DrawingType.DRAW_TRIANGLE:
                DrawTriangle();
                break;
            case DrawingType.DRAW_TRINAGLES:
                DrawTriangles();
                break;
            case DrawingType.DRAW_CUBE:
                DrawCube();
                break;
            case DrawingType.DRAW_PIC:
                DrawPic();
                break;
        }
        GL.PopMatrix();
    }

    //void OnGUI()//所有关于GUI的绘制只能写在这个方法里面，不过可以将此脚本赋予给其它物体，不一定是主摄像机
    //{
    //    //string string_content = "线";
    //    //GUIStyle fontStyle = new GUIStyle();
    //    //fontStyle.normal.background = null;   //设置背景填充
    //    //fontStyle.normal.textColor = Color.white;//设置字体颜色
    //    //fontStyle.fontSize = 24;//字体大小
    //    //Vector2 string_size = fontStyle.CalcSize(new GUIContent(string_content));//根据设置的样式求得字体具体的尺寸
    //    //GUI.Label(new Rect(0, 0, string_size.x, string_size.y), string_content, fontStyle);
    //}

    private void Update()
    {
        if (_bRotate)
        {
            transform.RotateAround(transform.position, Vector3.up, 0.6f);
        }
    }
    #endregion

    #region 渲染方法

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


    //画立方体
    private void DrawCube2()
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


    //画图片
    public Material _materialPic;//画图所使用的Pic
    public float _PicSize = 5.0f;

    private void DrawPic()
    {
        if (_materialPic == null)
        {
            return;
        }
        _materialPic.SetPass(0);
        _materialPic.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //开启单面双面
        GL.PushMatrix();
        GL.Begin(GL.QUADS);

        GL.Color(Color.yellow);
        GL.TexCoord2(0, 0);
        GL.Vertex3(-_PicSize, -_PicSize, 0);
        GL.TexCoord2(0, 1);
        GL.Vertex3(-_PicSize, _PicSize, 0);
        GL.TexCoord2(1, 1);
        GL.Vertex3(_PicSize, _PicSize, 0);
        GL.TexCoord2(1, 0);
        GL.Vertex3(_PicSize, -_PicSize, 0);

        GL.End();
        GL.PopMatrix();

    }
    #endregion
}