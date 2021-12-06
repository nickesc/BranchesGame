using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearLighthouseTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == MngrScript.Instance.playerCollider)
        {
            print("crossing nearLighthouseTrigger");

            if (MngrScript.Instance.getCurrentState() == "DisembarkedBoat" && MngrScript.Instance.getBlurbByChar("a") != "")
            {
                MngrScript.Instance.chooseBlurbByChar("a");
            }
            if (MngrScript.Instance.getCurrentState() == "WokeUp")
            {
                MngrScript.Instance.GoneOut = true;
            }
        }
    }
}
