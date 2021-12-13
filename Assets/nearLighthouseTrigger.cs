using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearLighthouseTrigger : MonoBehaviour
{
    private bool leftForLevel2 = false;

    public AudioSource ocean;
    private int volumeBit = 0;

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

            if (volumeBit % 2 == 0)
            {
                ocean.volume = .7f;
            }
            else
            {
                ocean.volume = 1;
            }

            volumeBit++;

            if (MngrScript.Instance.getCurrentState() == "DisembarkedBoat" && MngrScript.Instance.getBlurbByChar("a") != "")
            {
                MngrScript.Instance.chooseBlurbByChar("a");
            }
            if (MngrScript.Instance.getCurrentState() == "WokeUp")
            {
                MngrScript.Instance.GoneOut = true;
            }

            if (MngrScript.Instance.getCurrentState() == "Alternatives" || MngrScript.Instance.getCurrentState() == "FixTheLight")
            {
                if (leftForLevel2==false)
                { 
                    MngrScript.Instance.toggleDoors(); 
                    leftForLevel2 = true;
                }
            }
        }
    }
}
