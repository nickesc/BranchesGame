using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixFin : MonoBehaviour
{
    private bool finned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (finned == false)
        {
            if (MngrScript.Instance.getCurrentState() == "Fixed")
            {
                finned = true;
                MngrScript.Instance.moveTheShip = true;
                MngrScript.Instance.Fin = true;
            }
        }
    }
}

