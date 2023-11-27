using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

/// <summary>
/// 给定一个设备（3d物体root），遍历该物体的所有子部件（子部件的root名字包含[#]，命名格式如【#部件名字】），读取子部件物体的材质信息，返回一个字典：
/// Dictionary<string-部件的物体名字, List<(GameObject, Material[])-物体和它的材质数组>>
/// key用物体名字是用来快速提取某个子部件的材质信息，用于更换材质或者恢复材质
/// 
/// 层级关系及命名
/// root
///     #部件1
///        gameobject1
///        gameobject2
///        ...
///        gameobjectn
///     ...
///     #部件n
/// 
/// </summary>
/// <param name="root">3d物体——部件的root</param>
/// <returns> Dictionary<string-子部件名字, List<(GameObject -- 子部件的子物体, Material[] -- 物体对应的材质数组)>>  </returns>


public class TMEF : MonoBehaviour
{
    public Material transMat;
    static Dictionary<string, List<(GameObject, Material[])>> GetMaterialsDict(GameObject root)
    {
        //提前生成空的返回值
        var partsMaterialDict = new Dictionary<string, List<(GameObject, Material[])>>();

        //获取所有的零件
        var parts = root.GetComponentsInChildren<Transform>(true).Where(x => x.name.Contains('$')).ToList();

        Debug.LogWarning("保存Part字典");
        // Debug.LogWarning(parts.Count);
        // Debug.LogWarning(parts.Select(x => x.name.Split('$')[1]).First());

        parts.ForEach(x => Debug.Log(x.name.Split('$')[1]));

        //每个零件获取它的子物体的材质信息
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

        Debug.LogWarning("BW子物体:"+partsMaterialDict["BW"].Count);
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
        //  其它物体设置成半透明
        //  设备零部件的的父节点
        //partsMaterialDict = GetMaterialsDict(this.transform.gameObject);
    }

    public void SetPart() {
        partsMaterialDict = GetMaterialsDict(this.transform.gameObject);
    }

    public void SetTM() {
      
          partsMaterialDict.ToList()
          .Where(x => x.Key != "BW")   //给定的名字
          .SelectMany(x => x.Value).ToList()
          .ForEach(x =>
          {
                  //Debug.LogWarning(x.Item1.name);
                  if ("SM_DL_B"== x.Item1.name) {
                      Debug.LogWarning("透明队列:"+x.Item1.name);
                  }
         
                  //  此处有bug，数量要做一致
                  //  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; 
                  //  生成对数量的透明材质数组
                  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();
                  if (IsHaveTM==false) {
                      x.Item1.transform.GetComponent<MeshRenderer>().material.DOFade(0.5f, 0);
                      x.Item1.transform.GetComponent<MeshRenderer>().material.DOFade(0.054f, 1);
                  }
       
          });

        //partsMaterialDict.ToList()
        // .Where(x => x.Key == "BW")   //给定的名字
        // .SelectMany(x => x.Value).ToList()
        // .ForEach(x =>
        // {
        //     //Debug.LogWarning(x.Item1.name);
        //     if ("SM_DL_B" == x.Item1.name)
        //     {
        //         Debug.LogWarning("BW不透明队列:" + x.Item1.name);
        //     }

        //     //  此处有bug，数量要做一致
        //     //  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; 
        //     //  生成对数量的透明材质数组
        //     // x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();
        // });

    }

    public void SetDefault()
    {
        // 所有物体设置为正常材质
        partsMaterialDict.ToList()
                    .SelectMany(x => x.Value).ToList()   //展开成1d数组
                    .ForEach(x => x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item2);
    }



    private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) {  
                // 所有物体设置为正常材质
                partsMaterialDict.ToList()
                            .SelectMany(x => x.Value).ToList()   //展开成1d数组
                            .ForEach(x => x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item2);

                partsMaterialDict = GetMaterialsDict(this.transform.gameObject);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
   
                partsMaterialDict.ToList()
              .Where(x => x.Key != "BW")   //给定的名字
              .SelectMany(x => x.Value).ToList()
              .ForEach(x =>
              {
                  //  Debug.Log(x.Item1);
                  //  此处有bug，数量要做一致
                  //  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; 
                  //  生成对数量的透明材质数组
                  x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();
              });
            }

         }


    /// <summary>
    /// 显示指定的构件
    /// 指定构件从所有构件中脱颖而出（其他的透明显示，自己正常显示），高亮显示自己。
    /// 1、显示全貌
    /// 2、其它半透明显示，自己正常显示，且高亮
    /// </summary>
    /// <param name="name">部件名字</param>
    /// <param name="partsMaterialDict">部件的【物体】【材质信息】字典</param>
    /// <param name="transMat">透明材质</param>
    /// <param name="partsInfos">部件信息表</param>
    /// <returns>UniTask</returns>
    public static void UniTaskShow(string name, Dictionary<string, List<(GameObject, Material[])>> partsMaterialDict, Material transMat/*, List<PartsInfo> partsInfos*/)
    {
        //【1】显示所有【还原材质】
        partsMaterialDict.ToList()
            .SelectMany(x => x.Value).ToList()
            .ForEach(x => x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item2);

        //【2】关闭所有的高亮
        // partsInfos.ForEach(x => x.part3D.GetComponent<Highlighter>().tween = false);


        //【3】其它半透明
        partsMaterialDict.ToList()
            .Where(x => x.Key != name)
            .SelectMany(x => x.Value).ToList()
            .ForEach(x =>
            {
                //x.Item1.GetComponent<MeshRenderer>().sharedMaterials = new Material[] { transMat }; //此处有bug，数量要做一致
                x.Item1.GetComponent<MeshRenderer>().sharedMaterials = x.Item1.GetComponent<MeshRenderer>().sharedMaterials.Select(x => transMat).ToArray();//生成对数量的透明材质数组
            });

        //【4】自己高亮显示        
        //partsInfos.Where(x => x.name == name).First().part3D.GetComponent<Highlighter>().tween = true;
    }



}