using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LineCollect : MonoBehaviour
{
    public  List<Transform>  List_Arrow=new List<Transform>();
    public  LineRenderer  lineRenderer;

    public List<Vector3> list_V3 = new List<Vector3>();
    public Vector3[] ARRAYv3 = null;
    // Start is called before the first frame update

    void Start()
    {
        lineRenderer = null;
        List_Arrow.Clear();

        GameObject Linepb = Resources.Load<GameObject>("Line");
        lineRenderer = GameObject.Instantiate<GameObject>(Linepb).GetComponent<LineRenderer>();

        //添加子物体
        foreach (Transform item in this.transform)
        {
            List_Arrow.Add(item);
        }

        lineRenderer.positionCount = List_Arrow.Count;
        for (var i = List_Arrow.Count-1; i >= 0; i--)
        {
            lineRenderer.SetPosition(List_Arrow.Count-i-1, List_Arrow[i].position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
