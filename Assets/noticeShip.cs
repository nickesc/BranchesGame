using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noticeShip : MonoBehaviour
{
    public Collider player;
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
        if (other == player)
        {
            if (MngrScript.Instance.getCurrentState() == "GoneUp")
            {
                MngrScript.Instance.PushSubtitle("Oh no... That ship is gonna crash straight into the beach!", "silenceFive", false);
                MngrScript.Instance.PushSubtitle("I need to turn on the light to signal them, they can't tell in the dark that theres an island in front of them", "silenceFive",false);
                MngrScript.Instance.setOneBlurb("switch on the light");
                MngrScript.Instance.tryingToLight = true;
                Destroy(gameObject);
            }
        }
    }
}
