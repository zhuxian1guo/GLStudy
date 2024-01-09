//using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
// using static UnityEditor.Progress;
// using Unity.VisualScripting;

enum PORT
{
    OIL_TREATMENT_OVERVIEW,
    GAS_TREATMENT_OVERVIEW,
    WATER_TREATMENT_OVERVIEW,
    ELECTRIC_BOOSTER_PUMP,
    ELECTRIC_DEBOOSTER_PUMP,
    ELECTRIC_DEHYDRATION,
    ELECTRIC_STRIPPING_PREHEATER,
    ONE_LEVEL_101A,
    ONE_LEVEL_101B,
    ONE_LEVEL_102B,
    TWO_LEVEL_102A,
    SEAWATER_COOLER,
}

enum Device_Type
{
    SDV,     //   SDV 阀门
    V,         //   分离器
    TV,       //  
    T,
    LV,
    PV,
    point,
}

enum YCL
{

}

public enum DataImportType
{
    TEMP,
    DATA2UI
}

public class SystemPoint
{
    /// <summary>
    /// 
    /// </summary>
    public List<string> Point { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<Vector3> Position { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<string> Device { get; set; }
}

#region 分类数据
public class POINT
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }

    public Double real { get; set; }


    public Double calc { get; set; }


    public string valveOpening { get; set; }


    public string setValue { get; set; }


    public string P { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public float I { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public float D { get; set; }


    public string mode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string HH { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string H { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string L { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string LL { get; set; }
    /// <summary>
    /// 
    /// </summary>
    /// 
    public string status { get; set; }
     
    public string unit { get; set; }
    /// <summary>
    /// 
    /// </summary>

    public Double progress { get; set; }
}

public class POINT_PARENT
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<POINT> data { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool alarm { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string alarmInfo { get; set; }
}

#endregion

#region  Common Data

public class LIC
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }

    public Double real { get; set; }


    public Double calc { get; set; }


    public string valveOpening { get; set; }


    public string setValue { get; set; }


    public string P { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public float I { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public float D { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string HH { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string H { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string L { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string LL { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string unit { get; set; }
    /// <summary>
    /// 
    /// </summary>

    public Double progress { get; set; }
}

public class AlarmInfo
{
}
#endregion

#region data
public class PT7113
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double real { get; set; }
    /// <summary>
    /// 
    /// </summary>

    public long YourAttributeFunction { get; set; }

    public double calc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double valveOpening { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int setValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double P { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double I { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double D { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string mode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double HH { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double H { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int L { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double LL { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string unit { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double progress { get; set; }
}

public class PV7111A
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double real { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double calc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string valveOpening { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string setValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string P { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double I { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double D { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string mode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double HH { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double H { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double L { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double LL { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string unit { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double progress { get; set; }
}

public class LTC7113A
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double real { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string calc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string valveOpening { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string setValue { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string P { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double I { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double D { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string mode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string HH { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string H { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string L { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string LL { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string unit { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public double progress { get; set; }
}

public class OIL_TREATMENT_OVERVIEW
{
    public PT7113 PT7113 { get; set; }
}

public class Root
{
    /// <summary>
    /// 
    /// </summary>
    public OIL_TREATMENT_OVERVIEW OIL_TREATMENT_OVERVIEW { get; set; }
}
#endregion


public class DataMgr : MonoBehaviour
{
    public  DataImportType dataImportType = DataImportType.DATA2UI;
    public List<string>  List_YCLDeviceid=  new List<string>();
    public List<string>  List_InterfaceName = new List<string>();

    public   LIC LTC7113A = new LIC();
    public   LIC LIC7111A =  new LIC();
    public   LIC LIC7112A =  new LIC();
    public   LIC LIC7112B =  new LIC();

    #region 生命流程
    public static DataMgr _instance;
    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
         ReadJson();
    }
    #endregion

    public string s = null;
    string s1 = null;
    public void ReadJson() {

        #region 无效代码
        #region txt
        //TextAsset data = Resources.Load("data") as TextAsset;
        //s = data.text;                          //
        //UIMgr.instance.ClearLog();     //
        #endregion

        #region   data
        //TextAsset data = Resources.Load("data") as TextAsset;
        //s = data.text;  //
        //UIMgr.instance.ClearLog();   //
        //testData();
        #endregion
        #endregion

        Point_Pocess();  //读取txt生成点位
        TextAsset data = Resources.Load(PortName.ToString()) as TextAsset;
        //TextAsset data = Resources.Load("Oilson") as TextAsset;
        s = data.text;
        UIMgr.instance.ClearLog();
        //DataProcess_Common(s);
    }

    public void ReadJson(string Name) {
            TextAsset data = Resources.Load(Name) as TextAsset;
            s = data.text;
            UIMgr.instance.ClearLog();
    }

    public void ParseJson2Data(string json) {
        UIMgr.instance.ClearLog();
        JsonData jsdata = JsonMapper.ToObject(json);

        //V101A    
        List<LIC> V101ALIC = new List<LIC>();
        List<LIC> V101BLIC = new List<LIC>();
        JsonData LIC7111A = JsonMapper.ToObject(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101A"]["data"]["LIC7111A"].ToJson());
        JsonData LIC7112A = JsonMapper.ToObject(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101A"]["data"]["LIC7112A"].ToJson());

        UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "�豸����:" + "V-101A");
        UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "����:" + LIC7111A["name"]);
        UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "Һ��߶�:" + LIC7111A["real"]);
        UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "Һ��ٷֱ�:" + LIC7111A["progress"]);

        UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "����:" + LIC7112A["name"]);
        UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "Һ��߶�:" + LIC7112A["real"]);
        UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "Һ��ٷֱ�:" + LIC7112A["progress"]);

        //V101B    
        UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "�豸����:" + "V-101B");
        Debug.LogWarning(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101B"]["data"]["LIC7112B"].ToJson());
        JsonData LIC7112B = JsonMapper.ToObject(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101B"]["data"]["LIC7112B"].ToJson());
        UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "����:" + LIC7112B["name"]);
        UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "Һ��߶�:" + LIC7112B["real"]);
        UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "Һ��ٷֱ�:" + LIC7112B["progress"]);
    }

    public void ShowUITEMP() {
        ParseJson2Data(s);
    }

    public void testData()
    {
        JsonData jsdata = JsonMapper.ToObject(s);
        List<Transform> lista = UIMgr.instance.List_DataDeviceMarker;
        List<string> listb = DataMgr._instance.List_YCLDeviceid;
        Debug.LogWarning("List_DataDeviceMarker "+ lista.Count);
        Debug.LogWarning("List_YCLDeviceid" + listb.Count);

        for (int i = 0; i < UIMgr.instance.List_DataDeviceMarker.Count; i++)
        {
            for (int j = 0; j < DataMgr._instance.List_YCLDeviceid.Count; j++)
            {
                if (lista[i].GetComponent<DataLoader>().Deviceid == listb[j])
                {
                    Debug.LogWarning("设备id"+lista[i].GetComponent<DataLoader>().Deviceid);
                    if (jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["type"].ToString() == "V")
                    {
                        Debug.Log("OIL_TREATMENT_OVERVIEW");
                        if (lista[i].GetComponent<DataLoader>().Deviceid == "V-101A")
                        {
                            Debug.Log("V-101A������-LTC7113A����");
                            LIC7112A = JsonMapper.ToObject<LIC>(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101A"]["data"]["LIC7112A"].ToJson());
                            LIC7111A = JsonMapper.ToObject<LIC>(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101A"]["data"]["LIC7111A"].ToJson());
                            Debug.LogWarning(LIC7112A.progress);
                        }
                        if (lista[i].GetComponent<DataLoader>().Deviceid == "V-101B")
                        {
                            Debug.Log("V-101B������--LIC7112B����");
                            LIC7112B=  JsonMapper.ToObject<LIC>(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101B"]["data"]["LIC7112B"].ToJson());
                            Debug.LogWarning(LIC7112B.progress);
                        }
                    }
                }
            }
        }
    }

    #region 数据处理OLD
    public   List<POINT>  List_P_YCLData = new List<POINT>();
    public   List<POINT>  List_P_YCL_V101AData = new List<POINT>(); 
    public   List<POINT>  List_P_YCL_V101BData = new List<POINT>(); 
    public   List<POINT>  List_P_YCL_P101AData = new List<POINT>(); 
    public void Data_Process(string json)
    {
        JsonData jsdata = JsonMapper.ToObject(s);

        #region   
        List_P_YCLData.Clear();
        List_P_YCL_V101AData.Clear();
        List_P_YCL_V101BData.Clear();
        List_P_YCL_P101AData.Clear();
        JsonData ycldata = jsdata[List_InterfaceName[0]];

        //V-101A
        Debug.Log("V101A:" + ycldata["V-101A"]["data"].Count);
        for (int i = 0; i < ycldata["V-101A"]["data"].Count; i++)
        {
             POINT New_P=  JsonMapper.ToObject<POINT>(ycldata["V-101A"]["data"][i].ToJson());
             List_P_YCLData.Add(New_P);
             List_P_YCL_V101AData.Add(New_P);
        }

        //V-101B
        Debug.Log("V101B:" + ycldata["V-101B"]["data"].Count);
        for (int i = 0; i < ycldata["V-101B"]["data"].Count; i++)
        {
            POINT New_P = JsonMapper.ToObject<POINT>(ycldata["V-101B"]["data"][i].ToJson());
            List_P_YCLData.Add(New_P);
            List_P_YCL_V101BData.Add(New_P);
        }

        // P-101A
        Debug.Log("P101A:" + ycldata["V-101B"]["data"].Count);
        for (int i = 0; i < ycldata["P-101A"]["data"].Count; i++)
        {
            POINT New_P = JsonMapper.ToObject<POINT>(ycldata["P-101A"]["data"][i].ToJson());
            List_P_YCLData.Add(New_P);
            List_P_YCL_P101AData.Add(New_P);
        }
        #endregion

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="json"></param>
    public void Data_Process1(string json)
    {
        JsonData jsdata = JsonMapper.ToObject(json);

        #region   油处理数据
        List_P_YCLData.Clear();
        List_P_YCL_V101AData.Clear();
        List_P_YCL_V101BData.Clear();
        List_P_YCL_P101AData.Clear();
        JsonData ycldata = jsdata[List_InterfaceName[0]];

        //V-101A
        Debug.Log("-V101A:" + ycldata["V-101A"]["data"].Count);
        for (int i = 0; i < ycldata["V-101A"]["data"].Count; i++)
        {
            POINT New_P = JsonMapper.ToObject<POINT>(ycldata["V-101A"]["data"][i].ToJson());
            List_P_YCLData.Add(New_P);
            List_P_YCL_V101AData.Add(New_P);
        }

        //V-101B
        Debug.Log("V101B:" + ycldata["V-101B"]["data"].Count);
        for (int i = 0; i < ycldata["V-101B"]["data"].Count; i++)
        {
            POINT New_P = JsonMapper.ToObject<POINT>(ycldata["V-101B"]["data"][i].ToJson());
            List_P_YCLData.Add(New_P);
            List_P_YCL_V101BData.Add(New_P);
        }

        // P-101A
        Debug.Log("P101A:" + ycldata["V-101B"]["data"].Count);
        for (int i = 0; i < ycldata["P-101A"]["data"].Count; i++)
        {
            POINT New_P = JsonMapper.ToObject<POINT>(ycldata["P-101A"]["data"][i].ToJson());
            List_P_YCLData.Add(New_P);
            List_P_YCL_P101AData.Add(New_P);
        }
        #endregion

    }
    #endregion

    #region 数据处理
    #region 
    //TextAsset data = Resources.Load(json) as TextAsset;
    //s = data.text;
    //public List<string>  List_YCLDeviceid =  new List<string>();
    #endregion

    [SerializeField]
     PORT PortName = PORT.ELECTRIC_DEBOOSTER_PUMP;
    [SerializeField]
    List<string> List_OilPort= new List<string>();
    [SerializeField]
    List<string> List_WaterPort = new List<string>();
    [SerializeField]
    List<string> List_GasPort = new List<string>();

    List<POINT> List_OilData_Point = new List<POINT>();
    List<POINT_PARENT> List_OilData_PV = new List<POINT_PARENT>();
    List<POINT_PARENT> List_OilData_T = new List<POINT_PARENT>();
    List<POINT_PARENT> List_OilData_V = new List<POINT_PARENT>();
    List<POINT_PARENT> List_OilData_SDV = new List<POINT_PARENT>();
    List<POINT_PARENT> List_OilData_TV = new List<POINT_PARENT>();
    List<POINT_PARENT> List_OilData_LV = new List<POINT_PARENT>();

    List<POINT> List_WaterData_Point = new List<POINT>();
    List<POINT_PARENT> List_WaterData_PV = new List<POINT_PARENT>();
    List<POINT_PARENT> List_WaterData_T = new List<POINT_PARENT>();
    List<POINT_PARENT> List_WaterData_V = new List<POINT_PARENT>();

    #region Common处理
    public void DataProcess_Common(string s)
    {

        JsonData jsdata = JsonMapper.ToObject(s);

        #region 油处理
        foreach (var item in List_OilPort)
        {
            if (jsdata.ContainsKey(item))
            {
                int count = jsdata[item].Count;
                for (int i = 0; i < count; i++)
                {
                    JsonData jsd = jsdata[item];
                    Debug.LogWarning(jsd[i]["name"] + "||" + jsd[i]["type"]);

                    //Point
                    if (jsd[i]["type"].ToString() == "point")
                    {
                        //检测当前有无这个Point的数据
                        bool isHAVE = false;
                        for (int j = 0; j < List_OilData_Point.Count; j++)
                        {
                            if (jsd[i]["name"].ToString() == List_OilData_Point[j].name)
                            {
                                Debug.LogWarning("已存在该数据");
                                List_OilData_Point[j] = JsonMapper.ToObject<POINT>(jsd[i].ToJson());
                                isHAVE = true;
                            }
                        }

                        if (isHAVE == false)
                        {
                            Debug.LogWarning("未存在该数据");
                            List_OilData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));
                        }

                    }

                    #region 其他类型
                    
                    //查找其他类型的POINT
                    if (jsd[i]["type"].ToString() != "point")
                    {
                        Debug.LogWarning("非POINT类型:"+jsd[i]["data"].ToJson());
                        List<POINT>  List_tmpP= JsonMapper.ToObject<List<POINT>>(jsd[i]["data"].ToJson());

                        for (int xx = 0; xx < jsd[i]["data"].Count; xx++)
                        {
                            bool isHAVE1 = false;
                            for (int x = 0; x < List_OilData_Point.Count; x++)
                            {
                                if (jsd[i]["data"][xx]["name"].ToString() == List_OilData_Point[x].name)
                                {
                                    Debug.LogWarning("已存在该数据");
                                    List_OilData_Point[x] = JsonMapper.ToObject<POINT>(jsd[i]["data"][xx].ToJson());
                                    //List_OilData_Point[j] = JsonMapper.ToObject<POINT>(jsd[i].ToJson());
                                    isHAVE1 = true;
                                }
                            }
                            if (isHAVE1 == false)
                            {
                                Debug.LogWarning("未存在该数据");
                                List_OilData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i]["data"][xx].ToJson()));
                            }
                        }             
                    }

                    #region  TODO细化类型
                    ////T
                    //if (jsd[i]["type"].ToString() == "T")
                    //{
                    //    List_OilData_T.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    ////PV
                    //if (jsd[i]["type"].ToString() == "PV")
                    //{
                    //    List_OilData_PV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    ////V
                    //if (jsd[i]["type"].ToString() == "V")
                    //{
                    //    List_OilData_V.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    ////TV
                    //if (jsd[i]["type"].ToString() == "TV")
                    //{
                    //    List_OilData_TV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    ////SDV
                    //if (jsd[i]["type"].ToString() == "SDV")
                    //{
                    //    //Debug.LogWarning("SDVSDV");
                    //    List_OilData_SDV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    ////LV
                    //if (jsd[i]["type"].ToString() == "LV")
                    //{
                    //    List_OilData_LV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}
                    #endregion
                    #endregion

                }
            }
        }
        Debug.LogWarning("油处理_Point数量:" + List_OilData_Point.Count);
        Debug.LogWarning("油处理_PV数量:" + List_OilData_PV.Count);
        Debug.LogWarning("油处理_V数量:" + List_OilData_V.Count);
        Debug.LogWarning("油处理_LV数量:" + List_OilData_LV.Count);
        Debug.LogWarning("油处理_T数量:" + List_GasData_T.Count);
        Debug.LogWarning("油处理_SDV数量:" + List_OilData_SDV.Count);
        Debug.LogWarning("油处理_TV数量:" + List_OilData_TV.Count);
        #endregion

        #region 水处理
        foreach (var item in List_WaterPort)
        {
            if (jsdata.ContainsKey(item))
            {
                int count = jsdata[item].Count;
                for (int i = 0; i < count; i++)
                {
                    JsonData jsd = jsdata[item];
                    Debug.LogWarning(jsd[i]["name"]);

                    //Point
                    //if (jsd[i]["type"].ToString() == "point")
                    //{
                    //    List_WaterData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));
                    //}

                    //Point
                    if (jsd[i]["type"].ToString() == "point")
                    {
                        // 检测当前有无这个Point的数据
                        bool isHAVE = false;
                        for (int j = 0; j < List_WaterData_Point.Count; j++)
                        {
                            if (jsd[i]["name"].ToString() == List_WaterData_Point[j].name)
                            {
                                Debug.LogWarning("已存在该水数据");
                                List_WaterData_Point[j] = JsonMapper.ToObject<POINT>(jsd[i].ToJson());
                                isHAVE = true;
                            }
                        }

                        if (isHAVE == false)
                        {
                            Debug.LogWarning("未存在该水数据");
                            List_WaterData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));
                        }
                    }






                    //T
                    if (jsd[i]["type"].ToString() == "T")
                    {
                        List_WaterData_T.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    }

                    //PV
                    if (jsd[i]["type"].ToString() == "PV")
                    {
                        List_WaterData_PV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    }

                    //V
                    if (jsd[i]["type"].ToString() == "V")
                    {
                        List_WaterData_V.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    }

                    ////TV
                    //if (jsd[i]["type"].ToString() == "TV")
                    //{
                    //    List_GasData_V.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    ////SDV
                    //if (jsd[i]["type"].ToString() == "SDV")
                    //{
                    //    //Debug.LogWarning("SDVSDV");
                    //    List_OilData_SDV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    ////LV
                    //if (jsd[i]["type"].ToString() == "LV")
                    //{
                    //    List_OilData_LV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}
                }
            }
        }
        Debug.LogWarning("水处理_Point数量:" + List_WaterData_Point.Count);
        Debug.LogWarning("水处理_PV数量:" + List_WaterData_PV.Count);
        Debug.LogWarning("水处理_V数量:" + List_WaterData_V.Count);
        Debug.LogWarning("水处理_T数量:" + List_WaterData_T.Count);
        #endregion

        #region 气处理
        foreach (var item in List_GasPort)
        {
            if (jsdata.ContainsKey(item))
            {
                int count = jsdata[item].Count;
                for (int i = 0; i < count; i++)
                {
                    JsonData jsd = jsdata[item];
                    Debug.LogWarning(jsd[i]["name"]);

                    //Point
                    if (jsd[i]["type"].ToString() == "point")
                    {
                        List_GasData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));

                            // 检测当前有无这个Point的数据
                            bool isHAVE = false;
                            for (int j = 0; j < List_GasData_Point.Count; j++)
                            {
                                if (jsd[i]["name"].ToString() == List_GasData_Point[j].name)
                                {
                                    Debug.LogWarning("已存在该水数据");
                                    List_GasData_Point[j] = JsonMapper.ToObject<POINT>(jsd[i].ToJson());
                                    isHAVE = true;
                                }
                            }

                            if (isHAVE == false)
                            {
                                Debug.LogWarning("未存在该水数据");
                                List_GasData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));
                            }
                    }

                    //T
                    if (jsd[i]["type"].ToString() == "T")
                    {
                        List_GasData_T.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    }

                    //PV
                    if (jsd[i]["type"].ToString() == "PV")
                    {
                        List_GasData_PV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    }

                    //V
                    if (jsd[i]["type"].ToString() == "V")
                    {
                        List_GasData_V.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    }

                    #region TV
                    //TV
                    //if (jsd[i]["type"].ToString() == "TV")
                    //{
                    //    List_OilData_TV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    //SDV
                    //if (jsd[i]["type"].ToString() == "SDV")
                    //{
                    //    Debug.LogWarning("SDVSDV");
                    //    List_OilData_SDV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}

                    //LV
                    //if (jsd[i]["type"].ToString() == "LV")
                    //{
                    //    List_OilData_LV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                    //}
                    #endregion

                }
            }
        }
        Debug.LogWarning("气处理_Point数量:" + List_GasData_Point.Count);
        Debug.LogWarning("气处理_PV数量:" + List_GasData_PV.Count);
        Debug.LogWarning("气处理_V数量:" + List_GasData_V.Count);
        Debug.LogWarning("气处理_T数量:" + List_GasData_T.Count);
        #endregion

        Debug.LogWarning("DataMgr--数据处理完毕");
        Debug.LogWarning("将数据赋值给UI");
        UIMgr.instance.Data2UI_Point(List_OilData_Point);
        UIMgr.instance.Data2UI_Point(List_WaterData_Point);
        UIMgr.instance.Data2UI_Point(List_GasData_Point);
    }
    #endregion


    #region     单系统数据处理
        
    #region 数据处理_油处理
        /*   //油处理数据
        LIC LTC7113A = new LIC();
        public void testData()
        {
            JsonData jsdata = JsonMapper.ToObject(s);
            LTC7113A = JsonMapper.ToObject<LIC>(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101A"]["data"]["LTC7113A"].ToJson());
            Debug.LogWarning("序列化数据:");
            Debug.LogWarning(LTC7113A.calc);
            Debug.LogWarning(LTC7113A.real);

            //// 获取deviceid
            //foreach (var a in UIMgr.instance.List_DataDeviceMarker) {


            //        if (a.GetComponent<DataLoader>().Deviceid== "PT7113")
            //        {
            //            a.GetComponent<DataLoader>().json = jsdata["OIL_TREATMENT_OVERVIEW"]["PT7113"]["real"].ToString();
            //            a.GetComponent<DataLoader>().SetData();
            //        }
            //}

            List<Transform> lista = UIMgr.instance.List_DataDeviceMarker;
            List<string> listb = DataMgr._instance.List_YCLDeviceid;
            for (int i = 0; i < UIMgr.instance.List_DataDeviceMarker.Count; i++)
            {
                for (int j = 0; j < DataMgr._instance.List_YCLDeviceid.Count; j++)
                {
                    if (lista[i].GetComponent<DataLoader>().Deviceid == listb[j])
                    {
                        if (jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["type"].ToString() == "point")
                        {
                            lista[i].GetComponent<DataLoader>().GetComponent<DataLoader>().json = jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["real"].ToString();
                            lista[i].GetComponent<DataLoader>().GetComponent<DataLoader>().json2 = jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["calc"].ToString();
                            lista[i].GetComponent<DataLoader>().GetComponent<DataLoader>().SetData();
                        }
                        if (jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["type"].ToString() == "separator")
                        {
                            Debug.Log("这是分离器数据!");
                            if (lista[i].GetComponent<DataLoader>().Deviceid == "V-101A")
                            {
                                Debug.Log("V-101A分离器-LTC7113A");
                                JsonMapper.ToObject<LIC>(jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["data"]["LTC7113A"].ToJson());
                            }

                            if (lista[i].GetComponent<DataLoader>().Deviceid == "V-101B")
                            {
                                Debug.Log("V-102A分离器数据-LIC7111A/LIC7112B");
                                JsonMapper.ToObject<LIC>(jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["data"]["LIC7111A"].ToJson());
                                JsonMapper.ToObject<LIC>(jsdata["OIL_TREATMENT_OVERVIEW"][lista[i].GetComponent<DataLoader>().Deviceid]["data"]["LIC7112B"].ToJson());
                            }

                        }
                    }
                }
            }

        }

        public void ParseJson2Data(string json)
        {
            UIMgr.instance.ClearLog();
            JsonData jsdata = JsonMapper.ToObject(json);

            //V101A    
            List<LIC> V101ALIC = new List<LIC>();
            List<LIC> V101BLIC = new List<LIC>();
            JsonData LTC7113A = JsonMapper.ToObject(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101A"]["data"]["LTC7113A"].ToJson());
            UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "名称:" + LTC7113A["name"]);
            UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "液面高度:" + LTC7113A["real"]);
            UIMgr.instance.JSSetValue(UIMgr.instance.V101A, "液面百分比:" + LTC7113A["progress"]);

            //V101B    
            Debug.LogWarning(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101B"]["data"]["LIC7111A"].ToJson());
            Debug.LogWarning(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101B"]["data"]["LIC7112B"].ToJson());
            JsonData LIC7111A = JsonMapper.ToObject(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101B"]["data"]["LIC7111A"].ToJson());
            JsonData LIC7112B = JsonMapper.ToObject(jsdata["OIL_TREATMENT_OVERVIEW"]["V-101B"]["data"]["LIC7112B"].ToJson());

            UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "名称:" + LIC7111A["name"]);
            UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "液面高度:" + LIC7111A["real"]);
            UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "液面百分比:" + LIC7111A["progress"]);

            UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "名称:" + LIC7112B["name"]);
            UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "液面高度:" + LIC7112B["real"]);
            UIMgr.instance.JSSetValue(UIMgr.instance.V101B, "液面百分比:" + LIC7112B["progress"]);
        }

        List<POINT> List_OilData_Point = new List<POINT>();
        List<POINT_PARENT> List_OilData_PV = new List<POINT_PARENT>();
        List<POINT_PARENT> List_OilData_T = new List<POINT_PARENT>();
        List<POINT_PARENT> List_OilData_V = new List<POINT_PARENT>();
        List<POINT_PARENT> List_OilData_SDV = new List<POINT_PARENT>();
        List<POINT_PARENT> List_OilData_TV = new List<POINT_PARENT>();
        List<POINT_PARENT> List_OilData_LV = new List<POINT_PARENT>();

        public void DataProcess_Oil(string json)
        {
            TextAsset data = Resources.Load(json) as TextAsset;
            s = data.text;
            JsonData jsdata = JsonMapper.ToObject(s);
            Debug.LogWarning("油处理数据:" + jsdata["OIL_TREATMENT_OVERVIEW"].Count);
            int count = jsdata["OIL_TREATMENT_OVERVIEW"].Count;
            for (int i = 0; i < count; i++)
            {
                JsonData jsd = jsdata["OIL_TREATMENT_OVERVIEW"];
                Debug.LogWarning(jsd[i]["name"]);

                //Point
                if (jsd[i]["type"].ToString() == "point")
                {
                    List_WaterData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));
                    Debug.Log(List_OilData_Point.Count);
                }

                //T
                if (jsd[i]["type"].ToString() == "T")
                {
                    List_OilData_T.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //PV
                if (jsd[i]["type"].ToString() == "PV")
                {
                    List_OilData_PV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //V
                if (jsd[i]["type"].ToString() == "V")
                {
                    List_OilData_V.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //TV
                if (jsd[i]["type"].ToString() == "TV")
                {
                    List_OilData_TV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //SDV
                if (jsd[i]["type"].ToString() == "SDV")
                {
                    List_OilData_SDV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //LV
                if (jsd[i]["type"].ToString() == "LV")
                {
                    List_OilData_LV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }
            }

            Debug.LogWarning("油处理_V数量:" + List_WaterData_V.Count);
            Debug.LogWarning("油处理_T数量:" + List_WaterData_T.Count);
            Debug.LogWarning("油处理_PV数量:" + List_WaterData_PV.Count);
            Debug.LogWarning("油处理_Point数量:" + List_WaterData_Point.Count);
        }

        #endregion

        #region  数据处理_水处理
        List<POINT> List_WaterData_Point = new List<POINT>();
        List<POINT_PARENT> List_WaterData_PV = new List<POINT_PARENT>();
        List<POINT_PARENT> List_WaterData_T = new List<POINT_PARENT>();
        List<POINT_PARENT> List_WaterData_V = new List<POINT_PARENT>();
        public void DataProcess_Water(string json)
        {
            TextAsset data = Resources.Load(json) as TextAsset;
            s = data.text;
            JsonData jsdata = JsonMapper.ToObject(s);
            Debug.LogWarning("水处理数据:" + jsdata["WATER_TREATMENT_OVERVIEW"].Count);
            int count = jsdata["WATER_TREATMENT_OVERVIEW"].Count;
            for (int i = 0; i < count; i++)
            {
                JsonData jsd = jsdata["WATER_TREATMENT_OVERVIEW"];
                Debug.LogWarning(jsd[i]["name"]);

                //Point
                if (jsd[i]["type"].ToString() == "point")
                {
                    List_WaterData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));
                    Debug.Log(List_WaterData_Point.Count);
                }

                //T
                if (jsd[i]["type"].ToString() == "T")
                {
                    List_WaterData_T.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //PV
                if (jsd[i]["type"].ToString() == "PV")
                {
                    List_WaterData_PV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //V
                if (jsd[i]["type"].ToString() == "V")
                {
                    List_WaterData_V.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }
            }

            Debug.LogWarning("水处理_V数量:" + List_WaterData_V.Count);
            Debug.LogWarning("水处理_T数量:" + List_WaterData_T.Count);
            Debug.LogWarning("水处理_PV数量:" + List_WaterData_PV.Count);
            Debug.LogWarning("水处理_Point数量:" + List_WaterData_Point.Count);
        }
        #endregion

        #region  数据处理_气处理 */
        List<POINT> List_GasData_Point = new List<POINT>();
        List<POINT_PARENT> List_GasData_PV = new List<POINT_PARENT>();
        List<POINT_PARENT> List_GasData_T = new List<POINT_PARENT>();
        List<POINT_PARENT> List_GasData_V = new List<POINT_PARENT>();
        public void DataProcess_Gas(string json)
        {
            TextAsset data = Resources.Load(json) as TextAsset;
            s = data.text;
            JsonData jsdata = JsonMapper.ToObject(s);
            Debug.LogWarning("水处理数据:" + jsdata["GAS_TREATMENT_OVERVIEW"].Count);
            int count = jsdata["GAS_TREATMENT_OVERVIEW"].Count;
            for (int i = 0; i < count; i++)
            {
                JsonData jsd = jsdata["GAS_TREATMENT_OVERVIEW"];
                Debug.LogWarning(jsd[i]["name"]);

                //Point
                if (jsd[i]["type"].ToString() == "point")
                {
                    List_GasData_Point.Add(JsonMapper.ToObject<POINT>(jsd[i].ToJson()));
                    Debug.Log(List_WaterData_Point.Count);
                }

                //T
                if (jsd[i]["type"].ToString() == "T")
                {
                    List_GasData_T.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //PV
                if (jsd[i]["type"].ToString() == "PV")
                {
                    List_GasData_PV.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }

                //V
                if (jsd[i]["type"].ToString() == "V")
                {
                    List_GasData_V.Add(JsonMapper.ToObject<POINT_PARENT>(jsd[i].ToJson()));
                }
            }

            Debug.LogWarning("气处理_V数量:" + List_GasData_V.Count);
            Debug.LogWarning("气处理_T数量:" + List_GasData_T.Count);
            Debug.LogWarning("气处理_PV数量:" + List_GasData_PV.Count);
            Debug.LogWarning("气处理_Point数量:" + List_GasData_Point.Count);
        }

    #endregion
    #endregion

    #endregion

    #region 点位处理--从resouce里读取文本进行GO生成
    public List<string> List_Show_Point=new List<string>();
    public List<string> List_Show_Device = new List<string>();
    public void Point_Pocess() {
        
        if (Resources.Load("OilPoint") != null) {
            TextAsset data1 = Resources.Load("OilPoint") as TextAsset;
            s1 = data1.text;
            SystemPoint SP = JsonMapper.ToObject<SystemPoint>(s1);
            Debug.LogWarning("点位数量:" + SP.Point.Count + "  点位0-Name: " + SP.Point[0]);
            Debug.LogWarning("设备数量:" + SP.Device.Count);
            //按类型生成UI
            UIMgr.instance.Shwo_SPUI(SP);
        }      
    }
    #endregion

}

