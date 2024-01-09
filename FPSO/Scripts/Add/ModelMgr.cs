using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.GetChild(0));
        Debug.Log(transform.GetChild(1));
        Debug.Log(transform.GetChild(0).GetChild(0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
