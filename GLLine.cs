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
        //// 不同的Unity3D的版本，这段可能不同，具体只能从Unity3D的API抄下来，这是Unity4.x的设置
        ////lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        ////lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
        ////lineMaterial.SetPass(0);//只能这样设置材质，不能设置为其它材质，同时还是设置通道}
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

    void OnPostRender()//所有GL的绘制只能写在这个方法里面，并将此脚本赋予给主摄像机
    {
        CreateLineMaterial();
        lineMaterial.color = Color.yellow;
        lineMaterial.SetPass(0);  
        GL.LoadOrtho();//设置绘制2D图像

        //画从左下到右上的线                                   
        GL.Begin(GL.LINES);
        GL.Color(Color.red);
        GL.Vertex(new Vector2(0, 0));
        GL.Vertex(new Vector2(1, 1));
        GL.End();

        //画从左上到右下的线                                                                                                         //
        GL.Begin(GL.LINES);
        GL.Color(Color.yellow);
        GL.Vertex(new Vector2(0, 1));
        GL.Vertex(new Vector2(1, 0));
        GL.End();


        //画填充多边形
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

    void OnGUI()//所有关于GUI的绘制只能写在这个方法里面，不过可以将此脚本赋予给其它物体，不一定是主摄像机
    {
        string string_content = "线";
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = null;   //设置背景填充
        fontStyle.normal.textColor = Color.white;//设置字体颜色
        fontStyle.fontSize = 24;//字体大小
        Vector2 string_size = fontStyle.CalcSize(new GUIContent(string_content));//根据设置的样式求得字体具体的尺寸
        GUI.Label(new Rect(0, 0, string_size.x, string_size.y), string_content, fontStyle);
    }
}