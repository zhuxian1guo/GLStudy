 using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using Unity.VisualScripting;

public class DataLoader : MonoBehaviour
{
    public string Deviceid;  
    public string json;
    public string json2;

    public List<string> List_data = new List<string>();
    public List<POINT> List_P_Data=new List<POINT>();
    public POINT Poinfo1 = new POINT();
    private void Start()
    {
        
    }

    public void JoinUIDataList() {
        StartCoroutine(yieldJoinDataList());
    }

    IEnumerator  yieldJoinDataList() {
        yield return new WaitForSeconds(0.1f);
        UIMgr.instance.List_DataDeviceMarker.Add(this.transform);

        foreach (var t in GetComponentsInChildren<Transform>(true))
        {
            if (t.name == "Name")
            {
                Debug.LogWarning("显示Name");
                t.GetComponent<TextMeshProUGUI>().text = Deviceid;
            }

            if (t.name == "01")
            {
                Debug.LogWarning("显示01数据");
                t.transform.gameObject.SetActive(true);
                if (Poinfo1.name!=null) {
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = Poinfo1.real.ToString("F2") + "   " + "<color=green>" + Poinfo1.unit + "</color>";
                }
            }
            if (t.name == "02")
            {
                Debug.LogWarning("隐藏02数据");
                t.transform.gameObject.SetActive(false);
            }
        }
    }

    public void SetData() {
        foreach (var t in GetComponentsInChildren<Transform>(true))
        { 
            if (t.name=="01") {
                print(t.name);
                t.GetChild(0).GetComponent<TextMeshProUGUI>().text = json;
            }
            if (t.name == "02")
            {
                print(t.name);
                t.GetChild(0).GetComponent<TextMeshProUGUI>().text = json2;
            }
        }
    }

    public void SetListData()
    {
        Debug.Log("UI数据::"+JsonMapper.ToJson(List_P_Data[0]));
        foreach (var t in GetComponentsInChildren<Transform>(true))
        {
            //Debug.Log("名称::"+t.name);
            if (t.name == "Name")
            {
                t.GetComponent<TextMeshProUGUI>().text = Deviceid;
            }

            if (t.name == "01")
            {
                if (List_P_Data.Count>0) {
                    print("设置01的txt");
                    t.transform.gameObject.SetActive(true); 
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text =  "液位名称:"+ List_P_Data[0].name+"   "+ "液位高度:" + Math.Round(List_P_Data[0].progress * 100, 1)  /* string.Format("%.2f", List_P_Data[0].progress * 100)*/ + List_P_Data[0].unit;  /* JsonMapper.ToJson(List_P_Data[0])*/
                }       
            }
            if (t.name == "02")
            {
                if (List_P_Data.Count > 1)
                {
                    t.transform.gameObject.SetActive(true);
                    Debug.LogWarning(List_P_Data[1].progress+"@@@@@@@@@@@@");
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = "液位名称:" + List_P_Data[1].name + "   " + "液位高度:" + Math.Round(List_P_Data[1].progress * 100, 1) + List_P_Data[0].unit;
                }
                else{
                    t.gameObject.SetActive(false);
                }
            }
        }
    }

    public void SetListData(POINT  Poinfo)
    {
        // Debug.Log("UI数据::" + JsonMapper.ToJson(List_P_Data[0]));
        foreach (var t in GetComponentsInChildren<Transform>(true))
        {
            //Debug.Log("名称::"+t.name);
            if (t.name == "Name")
            {
                t.GetComponent<TextMeshProUGUI>().text = Deviceid;
            }
            if (t.name == "01")
            {
                    print("设置01的txt");
                    t.transform.gameObject.SetActive(true);
                //    if (Poinfo.unit== "kPa") {
                //    t.GetChild(0).GetComponent<TextMeshProUGUI>().text =/* "压强:" + */ Poinfo.real .ToString("F2")+ "   " /*+ "液位高度:" + Math.Round(Poinfo.progress * 100, 1)*/+ "<color=green>" +Poinfo.unit + "</color>"; 
                //    }
                Debug.Log("Label类型:"+Deviceid.Substring(0, 2));
                if (Deviceid.Substring(0, 2) == "LV" || Deviceid.Substring(0, 2) == "PV")
                {
                    string Mode = "M";
                  
                    if (Poinfo.mode == "manual")
                    {
                        Mode= "M";
                    }
                    if (Poinfo.mode == "auto")
                    {
                        Mode = "A";
                    }
         
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<color=yellow>" + Mode + "</color>" + "   " + Poinfo.valveOpening + "<color=green>" + "%" + "</color>";

                }
                else if (Deviceid.Substring(0, 3) == "SDV")
                {
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<color=yellow>" + "阀门状态" + "</color>" +  Poinfo.status;  
                }
                else  {
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = Poinfo.real.ToString("F2") + "   " + "<color=green>" + Poinfo.unit + "</color>";
                }
                     
            }
            if (t.name == "02")
            {
                //if (List_P_Data.Count > 1)
                //{
                //    t.transform.gameObject.SetActive(true);
                //    Debug.LogWarning(List_P_Data[1].progress + "@@@@@@@@@@@@");
                //    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = "液位名称:" + List_P_Data[1].name + "   " + "液位高度:" + Math.Round(List_P_Data[1].progress * 100, 1) + List_P_Data[0].unit;
                //}
                //else
                //{
                    t.gameObject.SetActive(false);
                //}
            }
        }
    }


    #region SetDeviceid
    public void JoinSetDeviceid()
    {
        StartCoroutine(yieldSetDeviceid());
    }
    IEnumerator yieldSetDeviceid()
    {
        yield return new WaitForSeconds(0.1f);
        SetDeviceid();
    }
    public void SetDeviceid()
    {
        foreach (var t in GetComponentsInChildren<Transform>(true))
        {
            if (t.name == "Name")
            {
                t.GetComponent<TextMeshProUGUI>().text = Deviceid;
            }
            if (t.name == "01")
            {
                print("设置01的txt");
                t.transform.gameObject.SetActive(true);
                //    if (Poinfo.unit== "kPa") {
                //    t.GetChild(0).GetComponent<TextMeshProUGUI>().text =/* "压强:" + */ Poinfo.real .ToString("F2")+ "   " /*+ "液位高度:" + Math.Round(Poinfo.progress * 100, 1)*/+ "<color=green>" +Poinfo.unit + "</color>"; 
                //    }
                Debug.Log("Label类型:" /*+ Deviceid.Substring(0, 2)*/);
                if (Deviceid.Substring(0, 2) == "LV" || Deviceid.Substring(0, 2) == "PV")
                {
                    string Mode = "M";

                    if (Poinfo1.mode == "manual")
                    {
                        Mode = "M";
                    }
                    else if (Poinfo1.mode == "auto")
                    {
                        Mode = "A";
                    }

                    if (Poinfo1.valveOpening != null)
                    {
                        t.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<color=yellow>" + Mode + "</color>" + "   " + float.Parse(Poinfo1.valveOpening) * 100 + "<color=green>" + "%" + "</color>";
                    }
                }
                else if (Deviceid.Substring(0, 3) == "SDV")
                {
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<color=yellow>" + "阀门状态" + "</color>" + Poinfo1.status;
                }
                else
                {
                    t.GetChild(0).GetComponent<TextMeshProUGUI>().text = Poinfo1.real.ToString("F2") + "   " + "<color=green>" + Poinfo1.unit + "</color>";
                }
            }
            if (t.name == "02")
            {
                Debug.LogWarning("隐藏02数据");
                t.transform.gameObject.SetActive(false);
            }
        }
    }
    #endregion

}
