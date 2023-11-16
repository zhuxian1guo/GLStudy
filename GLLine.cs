using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
using static UnityEditorInternal.ReorderableList;
//using static GLline2;

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


    [SerializeField]
    Light LG;
    void Start() {
            GetTargetRelatPos(GameObject.Find("Root").transform, this.transform);
            Light light =  LG;
            light.type = LightType.Directional;
            light.color = Color.white;
            light.intensity = 1.0f;
            light.shadows = LightShadows.Soft;
            light.shadowStrength = 0.7f;
            light.shadowBias = 0.05f;
            light.shadowNormalBias = 0.4f;
            light.shadowNearPlane = 0.1f;
            light.renderMode = LightRenderMode.ForcePixel;
            light.cullingMask = 1 << LayerMask.NameToLayer("Default");
           // light.useOcclusionCulling = true;
            light.useShadowMatrixOverride = true;
            light.bounceIntensity = 0;
            light.lightmapBakeType = LightmapBakeType.Realtime;
            light.flare = null;

    }

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

    #region     �任
    public Transform targetPos;
    public Transform centerPos;
    public Vector3 GetTargetRelatPos(Transform targetPos1, Transform centerPos1)
    {
        Vector3 result = new Vector3(0, 0, 0);
        Vector3 v3 = targetPos1.position - centerPos1.position;
        result.x = Vector3.Dot(v3, centerPos1.right);
        result.y = Vector3.Dot(v3, centerPos1.up);
        result.z = Vector3.Dot(v3, centerPos1.forward);
        return result;
    }

    public void OnDrawGizmos()
    {
        // ��ɫС�����
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(centerPos.position, 0.1f);
        Gizmos.DrawSphere(targetPos.position, 0.1f);

        // ���긨���߻���
        Gizmos.color = Color.red;      //X
        Gizmos.DrawLine(centerPos.position, centerPos.position + centerPos.right * 10);
        Gizmos.color = Color.green;   //y
        Gizmos.DrawLine(centerPos.position, centerPos.position + centerPos.up * 10);
        Gizmos.color = Color.blue;     //Z
        Gizmos.DrawLine(centerPos.position, centerPos.position + centerPos.forward * 10);

        //��������
        Gizmos.color = Color.yellow;  //ָ����
        Gizmos.DrawLine(centerPos.position, targetPos.position);
        Vector3 v3 = GetTargetRelatPos(targetPos, centerPos);

        //���߻��� ��������ͶӰ������Ĵ���
        Gizmos.color = Color.white;
        Gizmos.DrawLine(targetPos.position, centerPos.position + v3.x * centerPos.right);
        Gizmos.DrawLine(targetPos.position, centerPos.position + v3.y * centerPos.up);
        Gizmos.DrawLine(targetPos.position, centerPos.position + v3.z * centerPos.forward);

        //С�����
        Gizmos.DrawSphere(centerPos.position + v3.x * centerPos.right, 0.1f);
        Gizmos.DrawSphere(centerPos.position + v3.y * centerPos.up, 0.1f);
        Gizmos.DrawSphere(centerPos.position + v3.z * centerPos.forward, 0.1f);

        //Debug
        Debug.Log(GetTargetRelatPosFirst(targetPos, centerPos));

        // ����         
        //Scale-- - Rotate--Translate
        Debug.LogWarning("���ž���");
        Debug.Log(Matrix4x4.Scale(centerPos.localScale));

        Debug.LogWarning("����ת�þ���");

        Debug.Log(Matrix4x4.Scale(centerPos.localScale).inverse);
        Debug.Log(centerPos.worldToLocalMatrix);//?????

        Debug.LogWarning("��ת����");
        // ��ת��������Ҫ3x3���󣬸þ����¼�˶��󱾵����������������ĵ�λ��������centerPos.Right��centerPos.Up�Լ�centerPos.Forward���������������
        Debug.Log(Matrix4x4.Rotate(centerPos.rotation));

        // ����
        Debug.Log(centerPos.right);
        Debug.Log(centerPos.up);
        Debug.Log(centerPos.forward);

        //��ת����ת�ò���
        Debug.LogWarning("��תת�þ���");
        Debug.Log(Matrix4x4.Transpose(Matrix4x4.Rotate(centerPos.rotation)));


        Debug.LogWarning("λ�ƾ���");
        Debug.Log(Matrix4x4.Translate(centerPos.position));

        //��ת����ת�ò���
        Debug.LogWarning("λ��ת�þ���");
        Debug.Log(Matrix4x4.Translate(centerPos.position).inverse);


        Debug.LogWarning("����˷�1");
        Matrix4x4 trsOne = Matrix4x4.TRS(centerPos.position, centerPos.rotation, centerPos.localScale);
        Debug.Log(trsOne);

        Debug.LogWarning("����˷�2---T*R*S");
        Matrix4x4 trsTwo = Matrix4x4.Translate(centerPos.position) * Matrix4x4.Rotate(centerPos.rotation) * Matrix4x4.Scale(centerPos.localScale);
        Debug.Log(trsTwo);

        Debug.LogWarning("����˷�---ת�þ���---S*R*T");
        Matrix4x4 trsThree = Matrix4x4.Scale(centerPos.localScale).inverse * Matrix4x4.Transpose(Matrix4x4.Rotate(centerPos.rotation)) * Matrix4x4.Translate(centerPos.position).inverse;
        Debug.Log(trsThree);

        Debug.LogWarning("����˷�---ת�þ���---S*R*T");
        Matrix4x4 m4 = centerPos.worldToLocalMatrix * Matrix4x4.Scale(centerPos.localScale);
        Debug.Log(m4);
        //return m4.MultiplyPoint3x4(targetPos.position);
    }


    #region ���ֽ���ת��Ϊ�������ķ���
    //��һ�֣�
    public Vector3 GetTargetRelatPosFirst(Transform targetPos, Transform centerPos)
    {
        return centerPos.InverseTransformPoint(targetPos.position);
    }
    //�ڶ��֣�
    public Vector3 GetTargetRelatPosSencond(Transform targetPos, Transform centerPos)
    {
        Matrix4x4 m4 = centerPos.worldToLocalMatrix;
        return m4.MultiplyPoint3x4(targetPos.position);
    }
    //�����֣�
    public Vector3 GetTargetRelatPosThird(Transform targetPos, Transform centerPos)
    {
        Vector4 v4 = new Vector4(targetPos.position.x, targetPos.position.y, targetPos.position.z, 1);
        return centerPos.worldToLocalMatrix * v4;

    }
    #endregion




    #endregion

<<<<<<< HEAD
=======
    #region BRDF

    #endregion
>>>>>>> 328c3e78ab30438b4ed7b226a5b53b1c4bb716e3
}