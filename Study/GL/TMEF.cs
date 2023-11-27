using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

/// <summary>
/// ����һ���豸��3d����root��������������������Ӳ������Ӳ�����root���ְ���[#]��������ʽ�硾#�������֡�������ȡ�Ӳ�������Ĳ�����Ϣ������һ���ֵ䣺
/// Dictionary<string-��������������, List<(GameObject, Material[])-��������Ĳ�������>>
/// key����������������������ȡĳ���Ӳ����Ĳ�����Ϣ�����ڸ������ʻ��߻ָ�����
/// 
/// �㼶��ϵ������
/// root
///     #����1
///        gameobject1
///        gameobject2
///        ...
///        gameobjectn
///     ...
///     #����n
/// 
/// </summary>
/// <param name="root">3d���塪��������root</param>
/// <returns> Dictionary<string-�Ӳ�������, List<(GameObject -- �Ӳ�����������, Material[] -- �����Ӧ�Ĳ�������)>>  </returns>


public class TMEF : MonoBehaviour
{
    public Material transMat;
    static Dictionary<string, List<(GameObject, Material[])>> GetMaterialsDict(GameObject root)
    {
        //��ǰ���ɿյķ���ֵ
        var partsMaterialDict = new Dictionary<string, List<(GameObject, Material[])>>();

        //��ȡ���е����
        var parts = root.GetComponentsInChildren<Transform>(true).Where(x => x.name.Contains('$')).ToList();

        Debug.LogWarning("����Part�ֵ�");
        // Debug.LogWarning(parts.Count);
        // Debug.LogWarning(parts.Select(x => x.name.Split('$')[1]).First());

        parts.ForEach(x => Debug.Log(x.name.Split('$')[1]));

        //ÿ�������ȡ����������Ĳ�����Ϣ
        parts.ForEach(part =>
        {
            var partName = part.name.Split('$')[1];
            List<(GameObject, Material[])> goMatList = new List<(GameObject, Material[])>();
            part.GetComponentsInChildren<Transform>().ToList().ForEach(p =>
            {
                //Debug.Log(p.GetComponent<Renderer>());
                if (p.GetComponent<Renderer>() != null)
                {
                    goMatList.Add((p.gameObject, p.GetComponent<Renderer>().materials));
                }
            });
            partsMaterialDict[partName] = goMatList;
        });

        Debug.LogWarning("BW������:"+partsMaterialDict["BW"].Count);
        partsMaterialDict.Keys.ToList().ForEach(x =>
        {
            Debug.Log($"======{x}====== {partsMaterialDict[x].Count}");
        });
        return partsMaterialDict;
    }


    Dictionary<string, List<(GameObject, Material[])>> partsMaterialDict = new Dictionary<string, List<(GameObject, Material[])>>();

    public static TMEF _instance;
    private void Awake()
    {
       _instance = this;
    }

    public bool IsHaveTM=false;
    private void Start()
    {
        //  �����������óɰ�͸��
        //  �豸�㲿���ĵĸ��ڵ�
        //partsMaterialDict = GetMaterialsDict(this.transform.gameObject);
    }

    public void SetPart() {
        partsMaterialDict = GetMaterialsDict(this.transform.gameObject);
    }

    public void SetTM() {
      
          partsMaterialDict.ToList()
          .Where(x => x.Key != "BW")   //����������
          .SelectMany(x => x.Value).ToList()
          .ForEach(x =>
          {
                  //Debug.LogWarning(x.Item1.name);
                  if ("SM_DL_B"== x.Item1.name) {
                      Debug.LogWarning("͸������:"+x.Item1.name);
                  }
         
                  //  �˴���bug������Ҫ��һ��
                  //  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; 
                  //  ���ɶ�������͸����������
                  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();
                  if (IsHaveTM==false) {
                      x.Item1.transform.GetComponent<MeshRenderer>().material.DOFade(0.5f, 0);
                      x.Item1.transform.GetComponent<MeshRenderer>().material.DOFade(0.054f, 1);
                  }
       
          });

        //partsMaterialDict.ToList()
        // .Where(x => x.Key == "BW")   //����������
        // .SelectMany(x => x.Value).ToList()
        // .ForEach(x =>
        // {
        //     //Debug.LogWarning(x.Item1.name);
        //     if ("SM_DL_B" == x.Item1.name)
        //     {
        //         Debug.LogWarning("BW��͸������:" + x.Item1.name);
        //     }

        //     //  �˴���bug������Ҫ��һ��
        //     //  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; 
        //     //  ���ɶ�������͸����������
        //     // x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();
        // });

    }

    public void SetDefault()
    {
        // ������������Ϊ��������
        partsMaterialDict.ToList()
                    .SelectMany(x => x.Value).ToList()   //չ����1d����
                    .ForEach(x => x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item2);
    }



    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) {  
                // ������������Ϊ��������
                partsMaterialDict.ToList()
                            .SelectMany(x => x.Value).ToList()   //չ����1d����
                            .ForEach(x => x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item2);

                partsMaterialDict = GetMaterialsDict(this.transform.gameObject);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
   
                partsMaterialDict.ToList()
              .Where(x => x.Key != "BW")   //����������
              .SelectMany(x => x.Value).ToList()
              .ForEach(x =>
              {
                  //  Debug.Log(x.Item1);
                  //  �˴���bug������Ҫ��һ��
                  //  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; 
                  //  ���ɶ�������͸����������
                  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();
              });
            }

         }


    /// <summary>
    /// ��ʾָ���Ĺ���
    /// ָ�����������й�������ӱ������������͸����ʾ���Լ�������ʾ����������ʾ�Լ���
    /// 1����ʾȫò
    /// 2��������͸����ʾ���Լ�������ʾ���Ҹ���
    /// </summary>
    /// <param name="name">��������</param>
    /// <param name="partsMaterialDict">�����ġ����塿��������Ϣ���ֵ�</param>
    /// <param name="transMat">͸������</param>
    /// <param name="partsInfos">������Ϣ��</param>
    /// <returns>UniTask</returns>
    public static void UniTaskShow(string name, Dictionary<string, List<(GameObject, Material[])>> partsMaterialDict, Material transMat/*, List<PartsInfo> partsInfos*/)
    {
        //��1����ʾ���С���ԭ���ʡ�
        partsMaterialDict.ToList()
            .SelectMany(x => x.Value).ToList()
            .ForEach(x => x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item2);

        //��2���ر����еĸ���
        // partsInfos.ForEach(x => x.part3D.GetComponent<Highlighter>().tween = false);


        //��3��������͸��
        partsMaterialDict.ToList()
            .Where(x => x.Key != name)
            .SelectMany(x => x.Value).ToList()
            .ForEach(x =>
            {
                //x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; //�˴���bug������Ҫ��һ��
                x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();//���ɶ�������͸����������
            });

        //��4���Լ�������ʾ        
        //partsInfos.Where(x => x.name == name).First().part3D.GetComponent<Highlighter>().tween = true;
    }



}