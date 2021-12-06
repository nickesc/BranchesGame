using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingTownTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    private int disembarkBoatPass = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("crossing PassingTownTrigger");
        if (other == MngrScript.Instance.playerCollider)
        {
            if (MngrScript.Instance.getCurrentState() == "DisembarkedBoat")
            {
                if (disembarkBoatPass == 0)
                {
                    MngrScript.Instance.PushSubtitle("Wonder what that is...");
                }
                if (disembarkBoatPass == 1)
                {
                    MngrScript.Instance.PushSubtitle("Oh well, better get up.");
                }

                disembarkBoatPass++;
            }
        }
    }
}
