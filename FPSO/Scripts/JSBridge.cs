using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JSBridge : MonoBehaviour
{
    public TextMeshProUGUI temptext;
    public static JSBridge _instance;
    // Start is called before the first frame update

    private void Awake()
    {
        _instance = this; 
    }
    void Start()
    {
    }

    public void GetID(string  name) {
        temptext.text= name;
    }

    public void SetData(string json)
    {
        //DataMgr._instance.ParseJson2Data(json);  tempUI
        //DataMgr._instance.Data_Process1(json);

        //old
        //UIMgr.instance.JSBrige(json);

        //接口数据 new 接口数据
        DataMgr._instance.DataProcess_Common(json);
    }

    public void  SetJson(string json)
    {
        //DataMgr._instance.ParseJson2Data(json);  tempUI
        //DataMgr._instance.Data_Process1(json);
        UIMgr.instance.JSBrige(json);
    }

    [SerializeField]
    Transform SJBQ;
    public void ChangeSys(string SysName) {
        if (SysName == "Oil")
        {
            SJBQ.gameObject.SetActive(true);
            UIMgr.instance.SwitchLevelClick(6);
        }
        else if (SysName == "Water")
        {
            SJBQ.gameObject.SetActive(true);
            UIMgr.instance.SwitchLevelClick(8);
        }
        else if (SysName == "Gas")
        {
            //显示按钮
            SJBQ.gameObject.SetActive(true);
            UIMgr.instance.SwitchLevelClick(7);
        }
        else if (SysName == "All") {
            //隐藏数据
            if (UIMgr.instance.IsShowDM == true) {
                UIMgr.instance.SwitchLevelClick(12);
            }
            //隐藏按钮
            SJBQ.gameObject.SetActive(false);

           //切换到全船效果
            UIMgr.instance.SwitchLevelClick(9);
        }
    }
}
