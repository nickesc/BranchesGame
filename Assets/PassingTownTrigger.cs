using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingTownTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    private bool disembarkBoatPass = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (MngrScript.Instance.getCurrentState() == "DisembarkedBoat" && disembarkBoatPass == false)
        {
            MngrScript.Instance.PushSubtitle("Wonder what that is...");
            MngrScript.Instance.PushSubtitle("Oh well, better get up.");
            //MngrScript.Instance.PushSubtitle("im so excited");
            //MngrScript.Instance.PushSubtitle("i hoep to god it actually works");
            //MngrScript.Instance.PushSubtitle("fuck yes");
            disembarkBoatPass = true;
        }
    }
}
