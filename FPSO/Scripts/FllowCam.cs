using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCam : MonoBehaviour
{
    #region 参数
    //跟随的物体
    public Transform followObject;
    //跟随的三位数
    Vector3 vector;

    #endregion

    #region 常规方法
    // Use this for initialization
    void Start()
    {
        vector = this.transform.position - followObject.position;
    }

    private void LateUpdate()
    {
        ToFollow();
    }
    #endregion

    #region 私有方法

    void ToFollow()
    {
        this.transform.position = followObject.position + vector;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, followObject.localEulerAngles.y, this.transform.localEulerAngles.z);
    }
    #endregion

}