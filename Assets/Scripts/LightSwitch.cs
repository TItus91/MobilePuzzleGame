using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public bool isOn = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void switchLight()
	{
        if (isOn)
		{
            isOn = false;
            this.transform.localEulerAngles = new Vector3(0f, 45f, 0f);
		} else
		{
            isOn = true;
            this.transform.localEulerAngles = Vector3.zero;
		}
	}
}
