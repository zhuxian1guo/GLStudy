using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestClick : MonoBehaviour
{
        public Transform StaticData01;
        public Transform ShowMesh;
        public void OnMouseEnter()
        {
            Debug.Log("鼠标进入:" /*+ this.gameObject.name*/);
            // 显示选中效果
            if (isShow == false)
            {
                this.transform.gameObject.layer = 1;
            }
            else
            {
                this.transform.gameObject.layer = 0;
            }

            if (StaticData01!=null) 
            {
                // 显示label
                StaticData01.gameObject.SetActive(true);
                StaticData01.gameObject.transform.DOMove(this.transform.position, 0.5f);
            }    
        }

        public void OnMouseExit()
        {
            this.transform.gameObject.layer = 0;
            if (StaticData01 != null&& StaticData01.gameObject.activeInHierarchy)
            {
                // 显示label
                //StaticData01.gameObject.SetActive(false);
                StaticData01.gameObject.transform.DOMove(new Vector3(999,999,999), 0.5f);
        }
    }

        public Transform FlytoGo;
        public Transform ycl;
        bool isShow=false;

        public bool isHight = false;    //当前物体是否高亮
        public void OnMouseDown()
         {
            //Debug.Log("点击:"+this.gameObject.name);
            //StartCoroutine(translateT());      
            Debug.LogWarning("鼠标单击");
            Debug.LogWarning("TM效果");

            #region TM效果
            //if (TMEF._instance.IsHaveTM == false)
            //{
            //    //  当前未开启透明效果--- 开启当前物体的透明效果
            //    Debug.LogWarning("未开启全局透明效果");
            //    this.transform.parent = GameObject.Find("$BW").transform;
            //    TMEF._instance.SetPart();
            //    TMEF._instance.SetTM();
            //    TMEF._instance.IsHaveTM = true;
            //    isHight = true;
            //    Debug.LogWarning("未开启全局透明效果-->开启全局透明效果");
            //}
            //else
            //{
            //    // 已开启透明效果            
            //    if (isHight == true)
            //    {
            //        //  1 当前物体是非透明,其他物体是透明的
            //        Debug.LogWarning("已开启全局透明效果 --> 当前物体高亮--> 关闭高亮全局透明");
            //        TMEF._instance.SetDefault();

            //        //  交付1
            //        //GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("QHD32-6-CEPI_Diaolong").transform;
            //        GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("$Other").transform;
            //        TMEF._instance.SetPart();
            //        TMEF._instance.IsHaveTM = false;
            //        isHight = false;
            //        Debug.LogWarning("已开启全局透明效果-->当前物体切换为非透明--->变成默认的全局不透明效果");
            //    }
            //    else
            //    {
            //        // 2 当前物体是透明  其他物体有高亮
            //        Debug.LogWarning("已开启全局透明效果 --> 当前物体未高亮-->恢复默认颜色--->开启当前物体的高亮效果 ");

            //        GameObject.Find("$BW").transform.GetChild(0).GetComponent<TestClick>().isHight = false;
            //        GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("$Other").transform;
            //        //交付1
            //        //GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("QHD32-6-CEPI_Diaolong").transform;
            //        TMEF._instance.SetDefault();
            //        TMEF._instance.SetPart();

            //        //开启当前物体高亮
            //        this.transform.parent = GameObject.Find("$BW").transform;
            //        TMEF._instance.SetPart();
            //        TMEF._instance.SetTM();
            //        isHight = true;
            //    }

            //}
            #endregion

        }

        public TextMeshProUGUI text1;
        public void DoubleClickThis() {
            GameMgr.Instance.DeviceAlone = FlytoGo;
            GameMgr.Instance.TestClickT = this.transform;
            StartCoroutine(GameMgr.Instance.translateT(this.transform, FlytoGo, 50));
            UIMgr.instance.V102UIShow(true);
         }

        //IEnumerator  translateT() {
        //            yield return new WaitForSeconds(0.3f);
        //            if (FlytoGo != null)
        //            {
        //                    this.transform.gameObject.layer = 0;
                      
        //                    //动画Ani
        //                    Vector3 direction = FlytoGo.transform.position - GameObject.Find("Root").transform.position;
        //                    float distance = direction.magnitude;
        //                    GameObject.Find("Root").transform.Translate(direction, Space.World);
        //                    CameraController._instance.FlyAni(30F, 2);

        //                    //ycl.gameObject.SetActive(false);
        //                    FlytoGo.gameObject.SetActive(true);
        //                    UIMgr.instance.V102UIShow(true);

        //            }             
        //    }

    private void Start()
    {
        if (this.GetComponent<DoubleClickObject>()!=null) {
            this.GetComponent<DoubleClickObject>().DoubleClickEvents.AddListener(DoubleClickThis);
        }
    }

}


