using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowCam : MonoBehaviour
{
    #region ����
    //���������
    public Transform followObject;
    //�������λ��
    Vector3 vector;

    #endregion

    #region ���淽��
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

    #region ˽�з���

    void ToFollow()
    {
        this.transform.position = followObject.position + vector;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, followObject.localEulerAngles.y, this.transform.localEulerAngles.z);
    }
    #endregion

}