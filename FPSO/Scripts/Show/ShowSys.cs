using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_fm_Type {
    OIL_TREATMENT_OVERVIEW,
    Fm_b,
    Fm_d,
    Fm_e,
    Fm_g,
    Fm_h,
    Fm_qt
}

public class ShowSys : MonoBehaviour
{
    //fm_type
    public GameObject fm_b;
    public GameObject fm_d;
    public GameObject fm_e;
    public GameObject fm_g;
    public GameObject fm_h;
    public GameObject fm_qt;

    void Start()
    {
        InitIDFM();
        //SplitStr("sss,ss",null);
    }


    // Update is called once per frame
    void Update()
    {

    }

    #region  定位设备
    public void SetDesDev(Transform Dev, float dis)
    {
        //StartCoroutine(translateT(Dev, dis));
    }

    public void SetDesFM(Transform Dev, float Dis)
    {
        //StartCoroutine(translateT(Dev, Dis));
    }
    #endregion

    #region 该设备 读取id 生成阀门
    E_fm_Type fm_T = E_fm_Type.Fm_qt;
    public  Dictionary<string, string> Dic_IDDev=new Dictionary<string, string>();
    public void InitIDFM() {

            for (int j = 0; j <= this.transform.Find("FM").childCount - 1; j++)
            {
                Transform item = this.transform.Find("FM").GetChild(j);
                switch (item.name)
                {
                    case "fm_b":
                        Debug.Log(item.childCount);
                        for (int i = 0; i <= item.childCount - 1; i++)
                        {
                        string[] strarray = SplitStr(item.GetChild(i).name, null);
                            if (strarray[strarray.Length-1].Substring(0,1)=="#") {
                                    GameObject Cube = GameObject.Instantiate(fm_b);
                                    //GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                    Cube.transform.position = item.GetChild(i).transform.position;
                                    Cube.transform.parent = item.GetChild(i).transform;
                            }                 
                        }
                        break;

                        case "fm_d":
                        Debug.Log(item.childCount);
                        for (int i = 0; i <= item.childCount - 1; i++)
                        {
                            string[] strarray = SplitStr(item.GetChild(i).name, null);
                            if (strarray[strarray.Length - 1].Substring(0, 1) == "#")
                            {
                                GameObject Cube = GameObject.Instantiate(fm_d);
                                //GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                Cube.transform.position = item.GetChild(i).transform.position;
                                Cube.transform.parent = item.GetChild(i).transform;
                            }
                        }   
                        break;

                    case "fm_e":
                    Debug.Log(item.childCount);
                    for (int i = 0; i <= item.childCount - 1; i++)
                    {
                        string[] strarray = SplitStr(item.GetChild(i).name, null);
                        if (strarray[strarray.Length - 1].Substring(0, 1) == "#")
                        {
                            GameObject Cube = GameObject.Instantiate(fm_e);
                            //GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Cube.transform.position = item.GetChild(i).transform.position;
                            Cube.transform.parent = item.GetChild(i).transform;
                        }
                    }
                    break;

                    case "fm_g":
                    Debug.Log(item.childCount);
                    for (int i = 0; i <= item.childCount - 1; i++)
                    {
                        string[] strarray = SplitStr(item.GetChild(i).name, null);
                        if (strarray[strarray.Length - 1].Substring(0, 1) == "#")
                        {
                            GameObject Cube = GameObject.Instantiate(fm_g);
                            //GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Cube.transform.position = item.GetChild(i).transform.position;
                            Cube.transform.parent = item.GetChild(i).transform;
                        }
                    }
                    break;

                    case "fm_h":
                    Debug.Log(item.childCount);
                    for (int i = 0; i <= item.childCount - 1; i++)
                    {
                        string[] strarray = SplitStr(item.GetChild(i).name, null);
                        if (strarray[strarray.Length - 1].Substring(0, 1) == "#")
                        {
                            GameObject Cube = GameObject.Instantiate(fm_h);
                            //GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Cube.transform.position = item.GetChild(i).transform.position;
                            Cube.transform.parent = item.GetChild(i).transform;
                        }
                    }
                    break;

                    case "fm_qt":
                    Debug.Log(item.childCount);
                    for (int i = 0; i <= item.childCount - 1; i++)
                    {
                        string[] strarray = SplitStr(item.GetChild(i).name, null);
                        if (strarray[strarray.Length - 1].Substring(0, 1) == "#")
                        {
                            GameObject Cube = GameObject.Instantiate(fm_qt);
                            //GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            Cube.transform.position = item.GetChild(i).transform.position;
                            Cube.transform.parent = item.GetChild(i).transform;
                        }
                    }
                    break;

                }

            }


      
    }

    public string[] SplitStr(string sa, string TYPE) {
        //String sa = "开心,啊,啊";
        string[] strarray = null;
        strarray = sa.Split('_');
        Debug.Log("str长度" + strarray.Length);
        return strarray;
    }

    public void GetPoint() { 
        
    }

    #endregion

}
