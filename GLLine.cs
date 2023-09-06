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
    //ʹ��LINE_STRIP

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
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);  //��������˫��
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


    //ֻ����Ⱦ2D
    public void OnPostRender() {
        //CreateLineMaterial();
        //GL.LoadOrtho();//���û���2Dͼ��
        //GL.PushMatrix();

        //////�������µ����ϵ���                                   
        //GL.Begin(GL.LINES);
        //GL.Color(Color.red);
        //GL.Vertex(new Vector2(0, 0));
        //GL.Vertex(new Vector2(1, 1));
        //GL.End();

        ////�������ϵ����µ���                                                                                                         //
        //GL.Begin(GL.LINES);
        //GL.Color(Color.yellow);
        //GL.Vertex(new Vector2(0, 1));
        //GL.Vertex(new Vector2(1, 0));
        //GL.End();


        ////���������
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


    //������Ⱦ3D
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

        //// GL.TRIANGLE ������
        //DrawTriangle();

        //// GL.TRIANGLES �ı��� ����������
        //DrawTriangles();

        // ����������
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

    void OnGUI()//���й���GUI�Ļ���ֻ��д������������棬�������Խ��˽ű�������������壬��һ�����������
    {
        //string string_content = "��";
        //GUIStyle fontStyle = new GUIStyle();
        //fontStyle.normal.background = null;   //���ñ������
        //fontStyle.normal.textColor = Color.white;//����������ɫ
        //fontStyle.fontSize = 24;//�����С
        //Vector2 string_size = fontStyle.CalcSize(new GUIContent(string_content));//�������õ���ʽ����������ĳߴ�
        //GUI.Label(new Rect(0, 0, string_size.x, string_size.y), string_content, fontStyle);
    }
}