using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove : MonoBehaviour
{
    //偏移的速度
    public float speed = 1;
    //偏移的方向
    public Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //获取Render组件的材质引用,在得到材质引用的偏移属性，在进行每秒的偏移改变。
        GetComponent<Renderer>().material.mainTextureOffset += dir * Time.deltaTime * speed;
    }
}