//using BestHTTP.SecureProtocol.Org.BouncyCastle.Asn1.X509;
using DG.Tweening;
using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using DG.Tweening;
using UnityEngine;
using System.Collections.ObjectModel;

public class GameMgr : MonoBehaviour
{
    public static GameMgr Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //InitGoList();
        UnDisplayPipe();
    }

    #region 属性
    List<GameObject> ListGO = new List<GameObject>();
    public Transform v102;
    public Transform ycl;
    List<Transform> O_OilFm = new List<Transform>();
    List<Transform> O_WaterFm = new List<Transform>();
    List<Transform> O_GasFm = new List<Transform>();
    public Transform PipeNormal;
    public Transform PipeColor;
    public LiquidVolume lqV;
    #endregion

    #region 显示彩色线条
    public Material oIL;
    public Material ColorLine;
    public Transform Obj;
    bool isShowColorLine = false;
    public void ShowColorLine()
    {
        if (isShowColorLine)
        {
            //显示colorline  隐藏OilLine
            Obj.GetComponent<Renderer>().material = ColorLine;
            Obj.GetComponent<LineMove>().enabled = true;
            isShowColorLine = false;
        }
        else
        {
            //隐藏colorline  显示OilLine
            Obj.GetComponent<Renderer>().material = oIL;
            Obj.GetComponent<LineMove>().enabled = false;
            isShowColorLine = true;
        }
    }

    public void ShowGasLayer()
    {
        //DOTween.To(() => lqV.liquidLayers[0].amount, x => lqV.liquidLayers[0].amount = x, 0.5, 4);
        StartCoroutine(yieldShowLayer());
    }

    IEnumerator yieldShowLayer()
    {
        lqV.liquidLayers[0].amount = 0;
        lqV.UpdateLayers(false);
        yield return new WaitForSeconds(2f);

        lqV.liquidLayers[0].amount = 0.1f;
        lqV.UpdateLayers(false);
        yield return new WaitForSeconds(2f);

        lqV.liquidLayers[0].amount = 0.3f;
        lqV.UpdateLayers(false);
        yield return new WaitForSeconds(3f);

        lqV.liquidLayers[0].amount = 0.5f;
        lqV.UpdateLayers(false);
        yield return new WaitForSeconds(3f);

        lqV.liquidLayers[0].amount = 0.7f;
        lqV.UpdateLayers(false);
    }

    public Transform WaterPiPC;
    public Transform GasPiPC;
    public Transform OilPiPC;

    public void ShowColorLine1()
    {
        if (isShowColorLine)
        {
            //显示colorline  隐藏OilLine
            WaterPiPC.gameObject.SetActive(false);
            GasPiPC.gameObject.SetActive(false);
            OilPiPC.gameObject.SetActive(false);

            isShowColorLine = false;
        }
        else
        {
            //隐藏colorline  显示OilLine     
            WaterPiPC.gameObject.SetActive(true);
            GasPiPC.gameObject.SetActive(true);
            OilPiPC.gameObject.SetActive(true);
            isShowColorLine = true;
        }
        ShowColorPipe_Type(3);
    }

    public List<Transform> List_OilPipeCol = new List<Transform>();
    public List<Transform> List_GasPipeCol = new List<Transform>();
    public List<Transform> List_WaterPipeCol = new List<Transform>();

    public void ShowColorPipe_Type(int x) {

        switch (x)
        {
            case 0:
                if (List_OilPipeCol[0].gameObject.activeInHierarchy == false)
                {
                    foreach (var item in List_OilPipeCol)
                    {
                        item.gameObject.SetActive(true);

                    }
                    UIMgr.instance.ChangeTM(true);
                }
                else {
                    foreach (var item in List_OilPipeCol)
                    {
                        item.gameObject.SetActive(false);
                    }

                    if (List_OilPipeCol[0].gameObject.activeInHierarchy == false && List_WaterPipeCol[0].gameObject.activeInHierarchy == false && List_GasPipeCol[0].gameObject.activeInHierarchy == false)
                    {
                        UIMgr.instance.ChangeTM(false);
                    }
                }
                break;

            case 1:
                if (List_GasPipeCol[0].gameObject.activeInHierarchy == false)
                {
                    foreach (var item in List_GasPipeCol)
                    {
                        item.gameObject.SetActive(true);
                    }
                    UIMgr.instance.ChangeTM(true);
                }
                else {
                    foreach (var item in List_GasPipeCol)
                    {
                        item.gameObject.SetActive(false);
                    }

                    if (List_OilPipeCol[0].gameObject.activeInHierarchy == false && List_WaterPipeCol[0].gameObject.activeInHierarchy == false && List_GasPipeCol[0].gameObject.activeInHierarchy == false)
                    {
                        UIMgr.instance.ChangeTM(false);
                    }
                }

                break;

            case 2:
                if (List_WaterPipeCol[0].gameObject.activeInHierarchy == false)
                {
                    foreach (var item in List_WaterPipeCol)
                    {
                        item.gameObject.SetActive(true);
                    }
                    UIMgr.instance.ChangeTM(true);
                }
                else
                {
                    foreach (var item in List_WaterPipeCol)
                    {
                        item.gameObject.SetActive(false);
                    }

                    if (List_OilPipeCol[0].gameObject.activeInHierarchy == false && List_WaterPipeCol[0].gameObject.activeInHierarchy == false && List_GasPipeCol[0].gameObject.activeInHierarchy == false)
                    {
                        UIMgr.instance.ChangeTM(false);
                    }
                }

                break;

            case 3:
                foreach (var item in List_OilPipeCol)
                {
                    item.gameObject.SetActive(true);
                }
                foreach (var item in List_GasPipeCol)
                {
                    item.gameObject.SetActive(true);
                }
                foreach (var item in List_WaterPipeCol)
                {
                    item.gameObject.SetActive(true);
                }
                break;
        }

    }

    public void UnDisplayPipe() {
        foreach (var item in List_OilPipeCol)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in List_GasPipeCol)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in List_WaterPipeCol)
        {
            item.gameObject.SetActive(false);
        }
    }
    #endregion

    #region 显隐设备标签
    public Transform Oil_DM;
    public Transform Water_DM;
    public Transform Gas_DM;
    bool IsShowDM = true;
    public void ShowDM()
    {
        if (IsShowDM == false)
        {
            Oil_DM.gameObject.SetActive(true);
            Water_DM.gameObject.SetActive(true);
            Gas_DM.gameObject.SetActive(true);
            IsShowDM = true;
        }
        else
        {
            Oil_DM.gameObject.SetActive(false);
            Water_DM.gameObject.SetActive(false);
            Gas_DM.gameObject.SetActive(false);
            IsShowDM = false;
        }
    }
    #endregion

    #region 显隐数据标签

    #endregion

    #region FM和管线显示隐藏
    public void ShowOilFM(bool isShow)
    {
        foreach (Transform respawn in O_OilFm)
        {
            if (!isShow)
            {
                Debug.Log("隐藏石油阀门");
                respawn.gameObject.SetActive(false);
            }
            else if (isShow)
            {
                Debug.Log("显示石油阀门");
                respawn.gameObject.SetActive(true);
            }
        }
    }

    public void ShowWaterFM(bool isShow)
    {
        foreach (Transform respawn in O_WaterFm)
        {
            if (!isShow)
            {
                Debug.Log("隐藏水阀门");
                respawn.gameObject.SetActive(false);
            }
            else if (isShow)
            {
                Debug.Log("显示水阀门");
                respawn.gameObject.SetActive(true);
            }
        }
    }

    public void ShowGasFM(bool isShow)
    {
        foreach (Transform respawn in O_GasFm)
        {
            if (!isShow)
            {
                Debug.Log("隐藏GAS阀门");
                respawn.gameObject.SetActive(false);
            }
            else if (isShow)
            {
                Debug.Log("显示GAS阀门");
                respawn.gameObject.SetActive(true);
            }
        }
    }

    public void InitGoList()
    {
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("Oilfm");
        foreach (GameObject respawn in respawns)
        {
            O_OilFm.Add(respawn.transform);
        }

        GameObject[] respawns1 = GameObject.FindGameObjectsWithTag("gasfm");
        foreach (GameObject respawn1 in respawns1)
        {
            O_GasFm.Add(respawn1.transform);
        }

        GameObject[] respawns2 = GameObject.FindGameObjectsWithTag("waterfm");
        foreach (GameObject respawn2 in respawns2)
        {
            O_WaterFm.Add(respawn2.transform);
        }

        if (PipeColor != null)
        {
            PipeColor.gameObject.SetActive(false);
        }

    }
    #endregion

    #region 全船-->单个设备
    public Transform TestClickT;
    public Transform DeviceAlone;
    public void ShowV102(bool isShow)
    {
        UIMgr.instance.V102UIShow(isShow);
        if (isShow == false)
        {
            StartCoroutine(translateT(DeviceAlone, TestClickT, 50));
        }
    }


    //动画
    public IEnumerator translateT(Transform from, Transform to, float dis)
    {
        yield return new WaitForSeconds(0.3f);
        if (to != null)
        {
            if (from!=null) {
                from.gameObject.SetActive(false);
            }       
            to.gameObject.SetActive(true);

            //动画Ani
            Vector3 direction = to.transform.position - GameObject.Find("Root").transform.position;
            GameObject.Find("Root").transform.Translate(direction, Space.World);
            CameraController._instance.FlyAni(dis, 2);
        }
    }


    public Transform ChoosenT;
    public IEnumerator translateT( Transform to, float dis)
    {
        yield return new WaitForSeconds(0.3f);
        if (to != null)
        {

            to.gameObject.SetActive(true);

            //动画Ani
            Vector3 direction = to.transform.position - GameObject.Find("Root").transform.position;
            GameObject.Find("Root").transform.Translate(direction, Space.World);
            CameraController._instance.FlyAni(dis, 2);

            if (ChoosenT!=null) {

                ChoosenT.gameObject.layer = 0;
                foreach (var t in ChoosenT.transform.GetComponentsInChildren<Transform>(true))
                {
                    t.gameObject.layer = 0;
                }
            }


            ChoosenT = to;
            ChoosenT.gameObject.layer = 1;
            //foreach (Transform t in ChoosenT.transform) {
            //    t.gameObject.layer = 1;
            //}

            foreach (var t in ChoosenT.transform.GetComponentsInChildren<Transform>(true))
            {
                t.gameObject.layer = 1;
            }

        }
    }
    #endregion

    #region 油气水系统分类及其显示
    public Transform OilSystem;
    public Transform WaterSystem;
    public Transform GasSystem;
    public Transform OtherSystem;
    public Transform TSSystem;
    public Transform XFSystem;

    public Transform TMCT;
    public Transform BTMCT;

    public Transform OilSystem_TM;
    public Transform GasSystem_TM;
    public Transform OtherSystem_TM;
    public Transform WaterSystem_TM;

    public void ShowGasSys(bool isShow)
    {
        if (!isShow)
        {
            GasSystem.gameObject.SetActive(false);
        }
        else if (isShow)
        {
            GasSystem.gameObject.SetActive(true);
        }
    }

    public void ShowOilSys(bool isShow = true)
    {
        if (!isShow)
        {
            OilSystem.gameObject.SetActive(false);
        }
        else if (isShow)
        {
            OilSystem.gameObject.SetActive(true);

            //Root
        }
    }

    public void ShowWaterSys(bool isShow)
    {
        if (!isShow)
        {
            WaterSystem.gameObject.SetActive(false); ;
        }
        else if (isShow)
        {
            WaterSystem.gameObject.SetActive(true);
        }


    }

    public void ShowOtherSys(bool isShow)
    {
        if (!isShow)
        {
            OtherSystem.gameObject.SetActive(false);
        }
        else if (isShow)
        {
            OtherSystem.gameObject.SetActive(true);
        }
    }

    public void ShowTMSys(bool isShow, int Shownum)
    {
        TMCT.gameObject.SetActive(isShow);
        switch (Shownum)
        {
            case 0:
                OilSystem_TM.gameObject.SetActive(false);
                GasSystem_TM.gameObject.SetActive(true);
                OtherSystem_TM.gameObject.SetActive(true);
                WaterSystem_TM.gameObject.SetActive(true);
                break;
            case 1:
                OilSystem_TM.gameObject.SetActive(true);
                GasSystem_TM.gameObject.SetActive(false);
                OtherSystem_TM.gameObject.SetActive(true);
                WaterSystem_TM.gameObject.SetActive(true);
                break;
            case 2:
                OilSystem_TM.gameObject.SetActive(true);
                GasSystem_TM.gameObject.SetActive(true);
                OtherSystem_TM.gameObject.SetActive(true);
                WaterSystem_TM.gameObject.SetActive(false);
                break;
            case 3:
                OilSystem_TM.gameObject.SetActive(false);
                GasSystem_TM.gameObject.SetActive(false);
                OtherSystem_TM.gameObject.SetActive(false);
                WaterSystem_TM.gameObject.SetActive(false);
                break;
            case 4:
                OilSystem_TM.gameObject.SetActive(true);
                GasSystem_TM.gameObject.SetActive(true);
                OtherSystem_TM.gameObject.SetActive(true);
                WaterSystem_TM.gameObject.SetActive(true);
                break;
        }

        //if (!isShow)
        //{
        //    TMCT.gameObject.SetActive(isShow);
        //    BTMCT.gameObject.SetActive(true);
        //}
        //else if (isShow)
        //{
        //    TMCT.gameObject.SetActive(true);
        //    BTMCT.gameObject.SetActive(false);
        //}
    }

    public void ShowTSSys(bool isShow)
    {
        if (!isShow)
        {
            TSSystem.gameObject.SetActive(false);
        }
        else if (isShow)
        {
            TSSystem.gameObject.SetActive(true);
        }
    }

    public void ShowXFSys(bool isShow)
    {
        if (!isShow)
        {
            XFSystem.gameObject.SetActive(false);
        }
        else if (isShow)
        {
            XFSystem.gameObject.SetActive(true);
        }
    }
    #endregion

    #region  定位设备
    //public Transform Dev;
    public void SetDesDev(Transform Dev,float dis) {
        StartCoroutine(translateT(Dev, dis));
    }

    public void SetDesFM(Transform Dev,float Dis)
    {
        StartCoroutine(translateT(Dev, Dis));
    }
    #endregion

}
