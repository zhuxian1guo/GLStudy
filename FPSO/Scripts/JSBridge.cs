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

        //�ӿ����� new �ӿ�����
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
            //��ʾ��ť
            SJBQ.gameObject.SetActive(true);
            UIMgr.instance.SwitchLevelClick(7);
        }
        else if (SysName == "All") {
            //��������
            if (UIMgr.instance.IsShowDM == true) {
                UIMgr.instance.SwitchLevelClick(12);
            }
            //���ذ�ť
            SJBQ.gameObject.SetActive(false);

           //�л���ȫ��Ч��
            UIMgr.instance.SwitchLevelClick(9);
        }
    }
}
