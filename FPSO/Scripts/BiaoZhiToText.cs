using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiaoZhiToText : MonoBehaviour
{
    public string ѹ�������� = "ѹ��ֵ\n";
    public string ѹ����λ = "��";
    public string �������� = "����ֵ\n";
    public string ���ص�λ= "��";


    public float ��ʾѹ�����ʼ�Ƕ�;
    public float ��ʾѹ�������Ƕ�;
    public float ѹ�����ʼ�Ƕ�;
    public float ѹ�������Ƕ�;
    public float ��ʾ���س�ʼ�Ƕ�;
    public float ��ʾ�������Ƕ�;
    public float ���س�ʼ�Ƕ�;
    public float �������Ƕ�;

    public TextMesh ѹ�����ı�;
    public Transform ѹ����ָ��;
    public AnimationCurve ���ض��ձ�;
    public TextMesh �����ı�;
    public Transform ���ر�ָ��;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float �ݴ� = (ѹ����ָ��.localEulerAngles.y - ѹ�����ʼ�Ƕ�) / (ѹ�������Ƕ� - ѹ�����ʼ�Ƕ�);
        ѹ�����ı�.text = ѹ�������� +Mathf.Lerp(��ʾѹ�����ʼ�Ƕ�, ��ʾѹ�������Ƕ�, �ݴ� ).ToString("F2") + ѹ����λ;
         �ݴ� = (���ر�ָ��.localEulerAngles.x - ���س�ʼ�Ƕ�) / (�������Ƕ� - ���س�ʼ�Ƕ�);
        �����ı�.text = �������� +(int) Mathf.Lerp(��ʾ���س�ʼ�Ƕ�, ��ʾ�������Ƕ�, �ݴ�)+ ���ص�λ;
        �����ı�.text = �������� +(int)���ض��ձ�.Evaluate(���ر�ָ��.localEulerAngles.x) + ���ص�λ;
    }
}
