using System.Collections;
using System.Collections.Generic;
using Pinwheel.Griffin;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class raiseLight : MonoBehaviour
{
    public Light light;

    private bool raised = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (raised == false)
        {
            if (MngrScript.Instance.getCurrentState() == "WokeUp")
            {
                light.shadows = LightShadows.None;
                light.range = 10;
                //light.color = new Color(255,255,199);
                transform.position += new Vector3(0,-.5f);
                raised = true;
            }
        }
    }
}
