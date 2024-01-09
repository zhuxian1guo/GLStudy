using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiaoZhiToText : MonoBehaviour
{
    public string 压力表名称 = "压力值\n";
    public string 压力表单位 = "帕";
    public string 开关名称 = "开关值\n";
    public string 开关单位= "°";


    public float 显示压力表初始角度;
    public float 显示压力表最大角度;
    public float 压力表初始角度;
    public float 压力表最大角度;
    public float 显示开关初始角度;
    public float 显示开关最大角度;
    public float 开关初始角度;
    public float 开关最大角度;

    public TextMesh 压力表文本;
    public Transform 压力表指针;
    public AnimationCurve 开关对照表;
    public TextMesh 开关文本;
    public Transform 开关表指针;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float 暂存 = (压力表指针.localEulerAngles.y - 压力表初始角度) / (压力表最大角度 - 压力表初始角度);
        压力表文本.text = 压力表名称 +Mathf.Lerp(显示压力表初始角度, 显示压力表最大角度, 暂存 ).ToString("F2") + 压力表单位;
         暂存 = (开关表指针.localEulerAngles.x - 开关初始角度) / (开关最大角度 - 开关初始角度);
        开关文本.text = 开关名称 +(int) Mathf.Lerp(显示开关初始角度, 显示开关最大角度, 暂存)+ 开关单位;
        开关文本.text = 开关名称 +(int)开关对照表.Evaluate(开关表指针.localEulerAngles.x) + 开关单位;
    }
}
