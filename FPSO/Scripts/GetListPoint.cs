using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SysTemType
{
    Oil,
    Gas,
    Water
}

public class GetListPoint : MonoBehaviour
{
    [SerializeField]
    SysTemType sysTemType = SysTemType.Oil;
    [SerializeField]
    Transform Par;
    public List<SystemPoint> List_SP=new List<SystemPoint>();
    // Start is called before the first frame update
    void Start()
    {
        //ªÒ»°
        SystemPoint sp1 = new SystemPoint();
        sp1.Point = new List<string>();
        sp1.Position = new List<Vector3>();
        foreach (Transform a in this.transform) {
            sp1.Point.Add(a.transform.name);
            sp1.Position.Add(a.transform.position);
        }
        UIMgr.instance.Shwo_SPUI(sp1,Par);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
