using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoSetDeviceName : MonoBehaviour
{
    public TextMeshProUGUI pro_text_DeviceName;
    // Start is called before the first frame update
    void Start()
    {
        pro_text_DeviceName.text = this.transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
