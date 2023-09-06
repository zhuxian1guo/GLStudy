using UnityEngine;
using System.Collections;
public class GLLine : MonoBehaviour
{
    public static Material lineMaterial;
    static void CreateLineMaterial()
    {
        ////  lineMaterial = Material.Instantiate(lineMaterial);
        //lineMaterial = new Material(Shader.Find("Custom/wzygl"));
        //lineMaterial.color = Color.yellow;
        ////lineMaterial = new Material("Shader \"Lines/Colored Blended\" {" + "SubShader { Pass { " + "    Blend SrcAlpha OneMinusSrcAlpha " + "    ZWrite Off Cull Off Fog { Mode Off } " + "    BindChannels {" + "      Bind \"vertex\", vertex Bind \"color\", color }" + "} } }");
        //// ��ͬ��Unity3D�İ汾����ο��ܲ�ͬ������ֻ�ܴ�Unity3D��API������������Unity4.x������
        ////lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        ////lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
        ////lineMaterial.SetPass(0);//ֻ���������ò��ʣ���������Ϊ�������ʣ�ͬʱ��������ͨ��}
        ///
        Shader shader = Shader.Find("Hidden/Internal-Colored");
        lineMaterial = new Material(shader);
        lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        // Turn on alpha blending
        lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        // Turn backface culling off
        lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        // Turn off depth writes
        lineMaterial.SetInt("_ZWrite", 0);
    }

    void OnPostRender()//����GL�Ļ���ֻ��д������������棬�����˽ű�������������
    {
        CreateLineMaterial();
        lineMaterial.color = Color.yellow;
        lineMaterial.SetPass(0);  
        GL.LoadOrtho();//���û���2Dͼ��

        //�������µ����ϵ���                                   
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(new Vector2(0, 0));
        GL.Vertex(new Vector2(1, 1));
        GL.End();

        //�������ϵ����µ���                                                                                                         //
        GL.Begin(GL.LINES);
        GL.Color(Color.yellow);
        GL.Vertex(new Vector2(0, 1));
        GL.Vertex(new Vector2(1, 0));
        GL.End();


        //���������
        GL.Begin(GL.QUADS);
        GL.Color(Color.green);
        GL.Vertex(new Vector2(0.1f, 0.1f));
        GL.Vertex(new Vector2(0.1f, 0.2f));
        GL.Vertex(new Vector2(0.2f, 0.2f));
        GL.Vertex(new Vector2(0.2f, 0.1f));
        GL.End();


        //GL.Begin(GL.QUADS);
        //GL.Color(Color.yellow);
        //GL.Vertex(new Vector2(0.0f, 0.0f));
        //GL.Vertex(new Vector2(0f, 0.5f));
        //GL.Vertex(new Vector2(1f, 1f));
        //GL.Vertex(new Vector2(1f, 0.0f));
        //GL.End();

    }

    void OnGUI()//���й���GUI�Ļ���ֻ��д������������棬�������Խ��˽ű�������������壬��һ�����������
    {
        string string_content = "��";
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = null;   //���ñ������
        fontStyle.normal.textColor = Color.white;//����������ɫ
        fontStyle.fontSize = 24;//�����С
        Vector2 string_size = fontStyle.CalcSize(new GUIContent(string_content));//�������õ���ʽ����������ĳߴ�
        GUI.Label(new Rect(0, 0, string_size.x, string_size.y), string_content, fontStyle);
    }
}