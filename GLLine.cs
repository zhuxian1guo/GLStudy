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

    #region ��������
    private Material _shapeMaterial;
    //static Material lineMaterial;
    private void SetMaterialPass()
    {
        if (_shapeMaterial == null)
        {
            _shapeMaterial = new Material(Shader.Find("Hidden/Internal-Colored"));
        }

        _shapeMaterial.SetPass(0);

        _shapeMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //��������˫��
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

    //        //lineMaterial.SetColor("_BaseColor",Color.blue);  //��������˫��

    //        // Turn on alpha blending
    //        lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
    //        lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

    //        // Turn backface culling off
    //        lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //��������˫��
    //        // Turn off depth writes
    //        lineMaterial.SetInt("_ZWrite", 0);
    //    }
    //}
    #endregion

    #region ��Ⱦ��������
    //public void OnPreRender()
    //{
    //    //oldCulling = GL.invertCulling;
    //    //GL.invertCulling = false;
    //}

    //ֻ����Ⱦ2D
    //public void OnPostRender()
    //{
    //    //CreateLineMaterial();
    //    //GL.LoadOrtho();//���û���2Dͼ��
    //    //GL.PushMatrix();

    //    //////�������µ����ϵ���                                   
    //    //GL.Begin(GL.LINES);
    //    //GL.Color(Color.red);
    //    //GL.Vertex(new Vector2(0, 0));
    //    //GL.Vertex(new Vector2(1, 1));
    //    //GL.End();

    //    ////�������ϵ����µ���                                                                                                         //
    //    //GL.Begin(GL.LINES);
    //    //GL.Color(Color.yellow);
    //    //GL.Vertex(new Vector2(0, 1));
    //    //GL.Vertex(new Vector2(1, 0));
    //    //GL.End();


    //    ////���������
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

    //������Ⱦ3D
    #region MYCode

    //void OnRenderObject()
    //{
    //    Debug.Log("���ò���!");
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

    //    //// GL.TRIANGLE ������
    //    //DrawTriangle();

    //    //// GL.TRIANGLES �ı��� ����������
    //    //DrawTriangles();

    //    // ����������
    //    DrawCube2();

    //    //����ͼƬ
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

    //void OnGUI()//���й���GUI�Ļ���ֻ��д������������棬�������Խ��˽ű�������������壬��һ�����������
    //{
    //    //string string_content = "��";
    //    //GUIStyle fontStyle = new GUIStyle();
    //    //fontStyle.normal.background = null;   //���ñ������
    //    //fontStyle.normal.textColor = Color.white;//����������ɫ
    //    //fontStyle.fontSize = 24;//�����С
    //    //Vector2 string_size = fontStyle.CalcSize(new GUIContent(string_content));//�������õ���ʽ����������ĳߴ�
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

    #region ��Ⱦ����

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

    //ʹ��TRIANGLES���л���������
    private void DrawTriangle()
    {
        GL.Begin(GL.TRIANGLES);
        //˳ʱ��
        GL.Color(Color.red);
        GL.Vertex3(-triangleSize, -triangleSize, 0);//����
        GL.Color(Color.green);
        GL.Vertex3(0, triangleSize, 0);//��     
        GL.Color(Color.blue);
        GL.Vertex3(triangleSize, -triangleSize, 0);//����
        GL.End();
    }


    //TRIANGLE_STRIP Ŀ�꣺���ö���
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

    //Ŀ�꣺Unity��������ϵ
    //����CUBE�Ĵ���
    private void DrawCube()
    {
        GL.Begin(GL.QUADS);

        //����
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

        //����
        GL.Color(Color.gray);
        GL.Vertex3(-quadSize, -quadSize, -quadSize);
        GL.Vertex3(-quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, -quadSize, -quadSize);


        //����
        GL.Color(Color.black);
        GL.Vertex3(-quadSize, quadSize, -quadSize);
        GL.Vertex3(quadSize, quadSize, -quadSize);
        GL.Vertex3(quadSize, quadSize, quadSize);
        GL.Vertex3(-quadSize, quadSize, quadSize);

        GL.End();
    }


    //��������
    private void DrawCube2()
    {
        GL.Begin(GL.QUADS);

        //����
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

        //����
        GL.Color(Color.gray);
        GL.Vertex3(-quadSize, -quadSize, -quadSize);
        GL.Vertex3(-quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, -quadSize, quadSize);
        GL.Vertex3(quadSize, -quadSize, -quadSize);


        //����
        GL.Color(Color.black);
        GL.Vertex3(-quadSize, quadSize, -quadSize);
        GL.Vertex3(quadSize, quadSize, -quadSize);
        GL.Vertex3(quadSize, quadSize, quadSize);
        GL.Vertex3(-quadSize, quadSize, quadSize);

        GL.End();
    }


    //��ͼƬ
    public Material _materialPic;//��ͼ��ʹ�õ�Pic
    public float _PicSize = 5.0f;

    private void DrawPic()
    {
        if (_materialPic == null)
        {
            return;
        }
        _materialPic.SetPass(0);
        _materialPic.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //��������˫��
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