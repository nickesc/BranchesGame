using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (MngrScript.Instance.playingVA == false)
        {
            if (MngrScript.Instance.getCurrentState() == "ApproachedLighthouse")
            {
                MngrScript.Instance.PushSubtitle("I should head to bed before I go up...", "silenceFive");
            }
        }
    }
}
