using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove : MonoBehaviour
{
    //ƫ�Ƶ��ٶ�
    public float speed = 1;
    //ƫ�Ƶķ���
    public Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //��ȡRender����Ĳ�������,�ڵõ��������õ�ƫ�����ԣ��ڽ���ÿ���ƫ�Ƹı䡣
        GetComponent<Renderer>().material.mainTextureOffset += dir * Time.deltaTime * speed;
    }
}