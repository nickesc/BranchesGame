using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargoShipBehave : MonoBehaviour
{
    public GameObject CargoShip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (MngrScript.Instance.WokeUp == true)
        {
            Destroy(CargoShip);
        }
        
    }
}
