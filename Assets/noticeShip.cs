using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noticeShip : MonoBehaviour
{
    public Collider FOVCone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (MngrScript.Instance.tryingToLight == true && MngrScript.Instance.playingVA==false)
        {
            MngrScript.Instance.setOneBlurb("ignite the beacon");
            Destroy(this);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == FOVCone)
        {
            if (MngrScript.Instance.getCurrentState() == "GoneUp" && MngrScript.Instance.tryingToLight==false)
            {
                MngrScript.Instance.PushSubtitle("Oh no... That ship is gonna crash straight into the beach!", "Keeper11", false);
                MngrScript.Instance.PushSubtitle("I need to turn on the light to signal them, they can't tell in the dark that there's an island in front of them", "Keeper13",false);
                MngrScript.Instance.tryingToLight = true;
                
            }
        }
    }
}
