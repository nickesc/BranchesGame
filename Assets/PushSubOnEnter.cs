using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSubOnEnter : MonoBehaviour
{

    public Collider playerCapsule;
    public string sub;
    public string fileName;
    public string stateName;
    
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
        if (MngrScript.Instance.getCurrentState() == stateName)
        {
            if (other == playerCapsule)
            {
                MngrScript.Instance.PushSubtitle(sub, fileName, false);
                Destroy(this);
            }
        }
    }
}
