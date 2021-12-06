using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRoomStairsUpTrigger : MonoBehaviour
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
        if (other == MngrScript.Instance.playerCollider);
        {
            print("crossing LightRoomStairsUpTrigger");
            if (MngrScript.Instance.getCurrentState() == "WokeUp")
            {
                MngrScript.Instance.GoneUp = true;
            }
            print("woooo");
        }
    }
}
