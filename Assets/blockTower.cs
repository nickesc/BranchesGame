using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockTower : MonoBehaviour
{
    public string subtitle;

    public string fileName;
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
        print("colliding with blockTower");
        if (MngrScript.Instance.playingVA == false)
        {
            if (MngrScript.Instance.getCurrentState() == "ApproachedLighthouse")
            {
                MngrScript.Instance.PushSubtitle(subtitle, fileName);
            }
        }
    }
}
