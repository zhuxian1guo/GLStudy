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
            Debug.Log("������:" /*+ this.gameObject.name*/);
            // ��ʾѡ��Ч��
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
                // ��ʾlabel
                StaticData01.gameObject.SetActive(true);
                StaticData01.gameObject.transform.DOMove(this.transform.position, 0.5f);
            }    
        }

        public void OnMouseExit()
        {
            this.transform.gameObject.layer = 0;
            if (StaticData01 != null&& StaticData01.gameObject.activeInHierarchy)
            {
                // ��ʾlabel
                //StaticData01.gameObject.SetActive(false);
                StaticData01.gameObject.transform.DOMove(new Vector3(999,999,999), 0.5f);
        }
    }

        public Transform FlytoGo;
        public Transform ycl;
        bool isShow=false;

        public bool isHight = false;    //��ǰ�����Ƿ����
        public void OnMouseDown()
         {
            //Debug.Log("���:"+this.gameObject.name);
            //StartCoroutine(translateT());      
            Debug.LogWarning("��굥��");
            Debug.LogWarning("TMЧ��");

            #region TMЧ��
            //if (TMEF._instance.IsHaveTM == false)
            //{
            //    //  ��ǰδ����͸��Ч��--- ������ǰ�����͸��Ч��
            //    Debug.LogWarning("δ����ȫ��͸��Ч��");
            //    this.transform.parent = GameObject.Find("$BW").transform;
            //    TMEF._instance.SetPart();
            //    TMEF._instance.SetTM();
            //    TMEF._instance.IsHaveTM = true;
            //    isHight = true;
            //    Debug.LogWarning("δ����ȫ��͸��Ч��-->����ȫ��͸��Ч��");
            //}
            //else
            //{
            //    // �ѿ���͸��Ч��            
            //    if (isHight == true)
            //    {
            //        //  1 ��ǰ�����Ƿ�͸��,����������͸����
            //        Debug.LogWarning("�ѿ���ȫ��͸��Ч�� --> ��ǰ�������--> �رո���ȫ��͸��");
            //        TMEF._instance.SetDefault();

            //        //  ����1
            //        //GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("QHD32-6-CEPI_Diaolong").transform;
            //        GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("$Other").transform;
            //        TMEF._instance.SetPart();
            //        TMEF._instance.IsHaveTM = false;
            //        isHight = false;
            //        Debug.LogWarning("�ѿ���ȫ��͸��Ч��-->��ǰ�����л�Ϊ��͸��--->���Ĭ�ϵ�ȫ�ֲ�͸��Ч��");
            //    }
            //    else
            //    {
            //        // 2 ��ǰ������͸��  ���������и���
            //        Debug.LogWarning("�ѿ���ȫ��͸��Ч�� --> ��ǰ����δ����-->�ָ�Ĭ����ɫ--->������ǰ����ĸ���Ч�� ");

            //        GameObject.Find("$BW").transform.GetChild(0).GetComponent<TestClick>().isHight = false;
            //        GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("$Other").transform;
            //        //����1
            //        //GameObject.Find("$BW").transform.GetChild(0).parent = GameObject.Find("QHD32-6-CEPI_Diaolong").transform;
            //        TMEF._instance.SetDefault();
            //        TMEF._instance.SetPart();

            //        //������ǰ�������
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
                      
        //                    //����Ani
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


