using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    #region ����
    public Camera ca;
    public Material MAT_GZ;

    public List<Transform> ListTV102 = new List<Transform>();
    public List<Transform> ListYcl = new List<Transform>();
    public List<RectTransform> ListYCL3DUI = new List<RectTransform>();
    public List<Transform> List_DataDeviceMarker = new List<Transform>();

    public Transform OilSys;
    public Transform GasSys;
    public Transform WaterSys;

    public Transform Oil_DM;
    public Transform Gas_DM;
    public Transform Water_DM;

    public bool isOpaque = true;
    public bool IsShowDM = false;
    #endregion

    #region ��������
    public static UIMgr instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //BtnClick_TestData();
            DataMgr._instance.ReadJson("Oiljson");
            DataMgr._instance.DataProcess_Common(DataMgr._instance.s);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            //BtnClick_TestData();
            DataMgr._instance.ReadJson("Waterjson");
            DataMgr._instance.DataProcess_Common(DataMgr._instance.s);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //BtnClick_TestData();
            DataMgr._instance.ReadJson("Gasjson");   
            DataMgr._instance.DataProcess_Common(DataMgr._instance.s);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //ȫ����ʾ
           JSBridge._instance. ChangeSys("All");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //��ʾ�ʹ���
            //ȫ����ʾ
            JSBridge._instance.ChangeSys("Oil");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //��ʾ������
            JSBridge._instance.ChangeSys("Gas");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //��ʾˮ����
            JSBridge._instance.ChangeSys("Water");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            //��ʾˮ����
            OilSys.gameObject.SetActive(false);
            GasSys.gameObject.SetActive(false);
            WaterSys.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //��ʾˮ����
            Debug.Log("��ʾˮϵͳ");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //��ʾ�ʹ���
            Debug.Log("��ʾ��ϵͳ");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //��ʾ������
            Debug.Log("��ʾ��ϵͳ");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
          
            GameMgr.Instance.SetDesDev(GameObject.Find("v-102jm").transform,50f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GameMgr.Instance.SetDesDev(GameObject.Find("v-102jm/FM/FPSO_fm_b_8k019*").transform, 5f);
        }
    }
    #endregion

    #region UI��ʾ����
    public void V102UIShow(bool isshow)
    {
        foreach (Transform t in ListTV102)
        {
            t.gameObject.SetActive(isshow);
        }
        foreach (Transform t in ListYcl)
        {
            t.gameObject.SetActive(!isshow);
        }
    }

    public void yclUIShow(bool isshow)
    {
        foreach (Transform t in ListYcl)
        {
            t.gameObject.SetActive(isshow);
        }
        foreach (Transform t in ListTV102)
        {
            t.gameObject.SetActive(!isshow);
        }
    }
    #endregion

    #region  BtnClick
    public void ButtonClick_GasLayerMove()
    {
        GameMgr.Instance.ShowGasLayer();
    }

    public void ButtonClick_DataJoin()
    {
        DataMgr._instance.testData();
    }

    public void InterBtnClick()
    {
        if (isOpaque == false)
        {
            CanvasPos.SetMaterialRenderingMode(MAT_GZ, CanvasPos.RenderingMode.Opaque);
            isOpaque = true;
        }
        else if (isOpaque == true)
        {
            CanvasPos.SetMaterialRenderingMode(MAT_GZ, CanvasPos.RenderingMode.Transparent);
            isOpaque = false;
        }
    }

    bool istm=false;
    public  List <Material>  List_MAT= new List<Material>() ;
    public void ChangeTM()
    {
        if (istm == false)
        {
            foreach (var item in List_MAT)
            {
                CanvasPos.SetMaterialRenderingMode(item, CanvasPos.RenderingMode.Fade);
            }
            istm = true;
        }
        else if (istm == true)
        {
            foreach (var item in List_MAT)
            {
                CanvasPos.SetMaterialRenderingMode(item, CanvasPos.RenderingMode.Opaque);
            }
            istm = false;
        }
    }

    public void ChangeTM(bool istm1)
    {
        if (istm1 == true)
        {
            foreach (var item in List_MAT)
            {
                CanvasPos.SetMaterialRenderingMode(item, CanvasPos.RenderingMode.Fade);
            }
        }
        else if (istm1 == false )
        {
            foreach (var item in List_MAT)
            {
                CanvasPos.SetMaterialRenderingMode(item, CanvasPos.RenderingMode.Opaque);
            }
        }
    }

    public void SwitchLevelClick(int id)
    {
        Debug.Log(id);
        int layer = 0;
        switch (id)
        {
            case 0:
                for (int i = 0; i < 32; i++)
                {
                    if (LayerMask.LayerToName(i) == "Oil")
                    {
                        layer = i;
                        Debug.Log(layer);
                        ca.cullingMask |= (1 << layer);  // ��x��
                        ca.cullingMask &= ~(1 << layer + 1); // �ر�x��  
                        ca.cullingMask &= ~(1 << layer + 2); // �ر�x��  
                        GameMgr.Instance.PipeColor.gameObject.SetActive(true);
                        GameMgr.Instance.ShowGasFM(false);
                        GameMgr.Instance.ShowOilFM(true);
                        GameMgr.Instance.ShowWaterFM(false);
                    }
                }
                break;

            case 1:
                for (int i = 0; i < 32; i++)
                {
                    if (LayerMask.LayerToName(i) == "Gas")
                    {
                        layer = i;
                        Debug.Log(layer);
                        ca.cullingMask |= (1 << layer);  // ��x��
                        ca.cullingMask &= ~(1 << layer + 1); // �ر�x��  
                        ca.cullingMask &= ~(1 << layer - 1); // �ر�x��  
                        GameMgr.Instance.PipeColor.gameObject.SetActive(true);
                        GameMgr.Instance.ShowGasFM(true);
                        GameMgr.Instance.ShowOilFM(false);
                        GameMgr.Instance.ShowWaterFM(false);
                    }
                }
                break;

            case 2:
                for (int i = 0; i < 32; i++)
                {
                    if (LayerMask.LayerToName(i) == "Water1")
                    {
                        layer = i;
                        Debug.Log(layer);
                        ca.cullingMask |= (1 << layer);  // ��x��
                        ca.cullingMask &= ~(1 << layer - 2); // �ر�x��  
                        ca.cullingMask &= ~(1 << layer - 1); // �ر�x��  
                        GameMgr.Instance.PipeColor.gameObject.SetActive(true);
                        GameMgr.Instance.ShowGasFM(false);
                        GameMgr.Instance.ShowOilFM(false);
                        GameMgr.Instance.ShowWaterFM(true);
                    }
                }
                break;

            case 3:
                GameMgr.Instance.ShowV102(false);
                break;

            case 4:
                int gaslayer;
                int Waterlayer;
                int Oillayer;
                for (int i = 0; i < 32; i++)
                {
                    if (LayerMask.LayerToName(i) == "Gas")
                    {
                        gaslayer = i;
                        ca.cullingMask |= (1 << gaslayer);  // ��x��
                    }
                    if (LayerMask.LayerToName(i) == "Oil")
                    {
                        Oillayer = i;
                        ca.cullingMask |= (1 << Oillayer);  // ��x��
                    }
                    if (LayerMask.LayerToName(i) == "Water1")
                    {
                        Waterlayer = i;
                        ca.cullingMask |= (1 << Waterlayer);  // ��x��
                    }
                }

                GameMgr.Instance.ShowGasFM(true);
                GameMgr.Instance.ShowOilFM(true);
                GameMgr.Instance.ShowWaterFM(true);

                GameMgr.Instance.PipeNormal.gameObject.SetActive(true);
                GameMgr.Instance.PipeColor.gameObject.SetActive(false);
                break;

            case 5:
                Debug.Log("��ʾ��ɫ����!");
                GameMgr.Instance.ShowColorLine();
                break;

            case 6:
                Debug.Log("OilBtn");
                Camera.main.GetComponent<CameraController>().target.DOMove(GameMgr.Instance.OilSystem.transform.position, 1f);
                GameMgr.Instance.ShowOilSys(true);
                GameMgr.Instance.ShowWaterSys(false);
                GameMgr.Instance.ShowGasSys(false);
                GameMgr.Instance.ShowOtherSys(false);          
                GameMgr.Instance.ShowTMSys(true,0);
                if (IsShowDM==true) {
                    OilSys.gameObject.SetActive(true);
                    GasSys.gameObject.SetActive(false);
                    WaterSys.gameObject.SetActive(false);
                }
                break;

            case 7:
                Debug.Log("gasBtn");
                Camera.main.GetComponent<CameraController>().target.DOMove(GameMgr.Instance.GasSystem.transform.position, 1f);
                GameMgr.Instance.ShowGasSys(true);
                GameMgr.Instance.ShowOilSys(false);
                GameMgr.Instance.ShowWaterSys(false);
                GameMgr.Instance.ShowOtherSys(false);
                GameMgr.Instance.ShowTMSys(true,1);

                if (IsShowDM == true)
                {
                    OilSys.gameObject.SetActive(false);
                    GasSys.gameObject.SetActive(true);
                    WaterSys.gameObject.SetActive(false);
                }
         
                break;

            case 8:
                Debug.Log("WaterBtn");
                Camera.main.GetComponent<CameraController>().target.DOMove(GameMgr.Instance.WaterSystem.transform.position, 1f);
                GameMgr.Instance.ShowWaterSys(true);
                GameMgr.Instance.ShowOilSys(false);
                GameMgr.Instance.ShowGasSys(false);
                GameMgr.Instance.ShowOtherSys(false);
                GameMgr.Instance.ShowTMSys(true,2);
                if (IsShowDM == true)
                {
                    OilSys.gameObject.SetActive(false);
                    GasSys.gameObject.SetActive(false);
                    WaterSys.gameObject.SetActive(true);
                }
                break;

            case 9:
                //ALL
                Camera.main.GetComponent<CameraController>().target.DOMove(GameMgr.Instance.OilSystem.transform.position, 1f);
                GameMgr.Instance.ShowOilSys(true);
                GameMgr.Instance.ShowWaterSys(true);
                GameMgr.Instance.ShowGasSys(true);
                GameMgr.Instance.ShowOtherSys(true);
                GameMgr.Instance.ShowTMSys(false,3);
                break;   

            //����PipeCol
            case 10:
                GameMgr.Instance.ShowColorLine1();
                ChangeTM();
                break;

            //�����豸��ǩ
            case 11:
                GameMgr.Instance.ShowDM();
                break;

            //�������ݱ�ǩ
            case 12:
                Show_DataMarker();
                break;

            //��ʾ�����豸
            case 13:
                GameMgr.Instance.ShowOilSys(false);
                GameMgr.Instance.ShowWaterSys(false);
                GameMgr.Instance.ShowGasSys(false);
                GameMgr.Instance.ShowOtherSys(false);
                GameMgr.Instance.ShowTMSys(true, 4);
                GameMgr.Instance.ShowXFSys(true);
                break;

            //��ʾ����ͨ��
            case 14:
                GameMgr.Instance.ShowOilSys(false);
                GameMgr.Instance.ShowWaterSys(false);
                GameMgr.Instance.ShowGasSys(false);
                GameMgr.Instance.ShowOtherSys(false);
                GameMgr.Instance.ShowTMSys(true, 4);
                GameMgr.Instance.ShowTSSys(true);
                break;

            //��ʾ�͹���COL
            case 15:
                GameMgr.Instance.ShowColorPipe_Type(0);

                break;

            //��ʾ������COL
            case 16:
                GameMgr.Instance.ShowColorPipe_Type(1);
                break;

            //��ʾˮ����COL
            case 17:
                GameMgr.Instance.ShowColorPipe_Type(2);
                break;

            //������ʾ��̬����
            case 18:
                GameMgr.Instance.ShowColorPipe_Type(2);
                break;
        }
    }

    public void BtnClick_TestData() {

        if (DataMgr._instance. dataImportType == DataImportType.TEMP)
        {
            DataMgr._instance.ShowUITEMP();       //�����ݸ�ʽ����tempUI
        }
        else
        {
            Debug.Log("UI����");
            //DataMgr._instance.testData();

            //���ݴ���
            DataMgr._instance.Data_Process("test");
            //����UI
            foreach (var a in List_DataDeviceMarker)
            {
                if (a!=null) {
                    if (a.GetComponent<DataLoader>().Deviceid == "V-101A")
                    {
                        Debug.Log("����UI V101A������");
                        List<string> List_String = new List<string>();
                        a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_V101AData;
                        a.GetComponent<DataLoader>().SetListData();
                    }
                    if (a.GetComponent<DataLoader>().Deviceid == "V-101B")
                    {
                        Debug.Log("����UI V101B������");
                        List<string> List_String = new List<string>();
                        a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_V101BData;
                        a.GetComponent<DataLoader>().SetListData(); 
                    }
                    if (a.GetComponent<DataLoader>().Deviceid == "P-101A")
                    {
                        Debug.Log("����UI P101A������");
                        List<string> List_String = new List<string>();
                        a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_P101AData;
                        a.GetComponent<DataLoader>().SetListData();
                    }
                }
            }
            //Marker��������json
        
        }

        

    }


    [SerializeField]
    Transform Panel_Setting;
    public void BtnClick_Panel_Setting()
    {
        if (Panel_Setting.gameObject.activeInHierarchy)
        {
            //Debug.Log(Panel_Setting.transform.localPosition);
            Panel_Setting.DOLocalMoveX(0, 1f);

            Tweener tw2 = Panel_Setting.GetComponent<CanvasGroup>().DOFade(0, 1f);
            tw2.OnComplete(delegate ()
            {
                Debug.Log("�ƶ���:" + Panel_Setting.transform.localPosition);
                Panel_Setting.gameObject.SetActive(false);
            });
        }
        else
        {
            Panel_Setting.gameObject.SetActive(true);
            Panel_Setting.DOLocalMoveX(85f, 1.5f);
            Tweener tw2 = Panel_Setting.GetComponent<CanvasGroup>().DOFade(1, 1.5f);
        }
    }

    #region ����������ʾ
    public Transform StaticLabel;
    /// <summary>
    /// ������ʾ��̬����
    /// </summary>
    public void SingleClickShowUI(Transform t)
    {
        Debug.Log("������ʾ: " + t.name);
        if (t.GetComponent<DoubleClickObject>().IsSingleClickOpen)
        {
            t.GetComponent<DoubleClickObject>().IsSingleClickOpen = false;
            StaticLabel.transform.DOLocalMoveX(2999, 2f);
        }
        else
        {
            t.GetComponent<DoubleClickObject>().IsSingleClickOpen = true;
            StaticLabel.transform.DOLocalMoveX(0, 2f);
        }
    }

    public void ShowStaticUI(string staticName)
    {
    }
    //ѡ��
    #endregion

    #endregion

    #region ��λUI
    /// <summary>
    /// Shwo_SPUI
    /// </summary>
    /// <param name="sp"></param>
    public void Shwo_SPUI(SystemPoint sp)
    {
        //����SP
        GameObject PB = Resources.Load<GameObject>("UI/Point");
        for (int i = 0; i < sp.Point.Count; i++)
        {
            GameObject GO = GameObject.Instantiate<GameObject>(PB);
            GO.name = sp.Point[i];
            GO.transform.position = sp.Position[i];
        }
    }

    public void Shwo_SPUI(SystemPoint sp, Transform Wp)
    {
        //����SP
        GameObject PB = Resources.Load<GameObject>("UI/Point");
        for (int i = 0; i < sp.Point.Count; i++)
        {
            GameObject GO = GameObject.Instantiate<GameObject>(PB);
            GO.name = sp.Point[i];
            GO.transform.position = sp.Position[i];
            GO.transform.parent = Wp;
        }
    }

    /// <summary>
    /// ����ӳ�䵽UI��
    /// </summary>
    public void Data2UI_Point(List<POINT> List_Data_Point)
    {
        for (int i = 0; i < List_Data_Point.Count; i++)
        {
            foreach (var a in List_DataDeviceMarker)
            {
                if (a != null)
                {
                    #region  ��Ч����
                    //if (a.GetComponent<DataLoader>().Deviceid == "V-101A")
                    //{
                    //    Debug.Log("����UI V101A������");
                    //    List<string> List_String = new List<string>();
                    //    a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_V101AData;
                    //    a.GetComponent<DataLoader>().SetListData();
                    //}
                    //if (a.GetComponent<DataLoader>().Deviceid == "V-101B")
                    //{
                    //    Debug.Log("����UI V101B������");
                    //    List<string> List_String = new List<string>();
                    //    a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_V101BData;
                    //    a.GetComponent<DataLoader>().SetListData();
                    //}
                    //if (a.GetComponent<DataLoader>().Deviceid == "P-101A")
                    //{
                    //    Debug.Log("����UI P101A������");
                    //    List<string> List_String = new List<string>();
                    //    a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_P101AData;
                    //    a.GetComponent<DataLoader>().SetListData();
                    //}
                    #endregion
                    if (List_Data_Point[i].name == a.GetComponent<DataLoader>().Deviceid)
                    {
                        Debug.LogWarning("����:" + List_Data_Point[i].name + "����");
                        a.GetComponent<DataLoader>().Poinfo1 = List_Data_Point[i];
                        a.GetComponent<DataLoader>().SetListData(List_Data_Point[i]);
                    }
                }
            }
        }

        #region UI
        //Transform UIParent = GameObject.Find("Envrionment/Ancker").transform;
        //Transform Root = GameObject.Find("Root").transform;
        ////ʹ��List����UI
        //foreach (POINT point in List_Data_Point)
        //{
        //    Debug.Log(point.name);
        //    GameObject a = GameObject.Instantiate(Resources.Load<GameObject>("PTAnchor"));
        //    a.transform.parent = UIParent;
        //    a.transform.position = Root.transform.position + new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        //}
        //��UIList���ҵ����ʵ�UI
        #endregion

    }
    #endregion

    #region JS����
    public void JSBrige(string jsJson)
    {
        Debug.Log("UI����");

        //���ݴ���
        DataMgr._instance.Data_Process1(jsJson);
        //����UI
        foreach (var a in List_DataDeviceMarker)
        {
            if (a.GetComponent<DataLoader>().Deviceid == "V-101A")
            {
                Debug.Log("����UI V-101A������");
                List<string> List_String = new List<string>();
                a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_V101AData;
                a.GetComponent<DataLoader>().SetListData();
            }
            if (a.GetComponent<DataLoader>().Deviceid == "V-101B")
            {
                Debug.Log("����UI V-101B������");
                List<string> List_String = new List<string>();
                a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_V101BData;
                a.GetComponent<DataLoader>().SetListData();
            }
            if (a.GetComponent<DataLoader>().Deviceid == "P-101A")
            {
                Debug.Log("����UI P-101A������");
                List<string> List_String = new List<string>();
                a.GetComponent<DataLoader>().List_P_Data = DataMgr._instance.List_P_YCL_P101AData;
                a.GetComponent<DataLoader>().SetListData();
            }
        }
    }

    #region ����UI
    public TextMeshProUGUI temptext;
    public TextMeshProUGUI JSTxt;
    public TextMeshProUGUI V101A;
    public TextMeshProUGUI V101B;
    public void JSSetValue(TextMeshProUGUI ui, string log)
    {
        Debug.Log(log);
        ui.text += log;
        ui.text += "\n";
    }


    /// <summary>
    /// ��ʼ����Ļ������log
    /// </summary>
    public void ClearLog()
    {
        V101A.text = null;
        V101B.text = null;
    }

    public void JSLog(string log)
    {
        Debug.Log(log);
        temptext.text = log;
    }
    #endregion
    #endregion


    public void Show_DataMarker()
    {
        if (IsShowDM == false)
        {
            OilSys.gameObject.SetActive(true);
            GasSys.gameObject.SetActive(true);
            WaterSys.gameObject.SetActive(true);
            IsShowDM = true;
        }
        else
        {
            OilSys.gameObject.SetActive(false);
            GasSys.gameObject.SetActive(false);
            WaterSys.gameObject.SetActive(false);
            IsShowDM = false;
        }
    }

}
