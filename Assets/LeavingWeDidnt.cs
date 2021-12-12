using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavingWeDidnt : MonoBehaviour
{

    public Collider playerCapsule;
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
        if (MngrScript.Instance.getCurrentState()=="WeDidntStartTheFire")
        {
            if (other == playerCapsule)
            {
                MngrScript.Instance.LeavingWeDidnt = true;
                MngrScript.Instance.toggleDoors();
                Destroy(this);
            }
        }
        
    }
}
