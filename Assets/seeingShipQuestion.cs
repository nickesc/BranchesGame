using System.Collections;
using System.Collections.Generic;
using SensorToolkit;
using UnityEngine;

public class seeingShipQuestion : MonoBehaviour
{
    public Sensor yachtSensor;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        yachtSensor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (MngrScript.Instance.getCurrentState() == "Lit")
        {
            yachtSensor.enabled = true;
            if (yachtSensor.IsDetected(player))
            {
                MngrScript.Instance.SeeingShip = true;
                print("seeing it");
            }
        }
    }
    
    
}
