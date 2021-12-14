using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haveTime : MonoBehaviour
{

    public Collider player;
    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            if (MngrScript.Instance.getCurrentState() == "Alternatives" ||
                MngrScript.Instance.getCurrentState() == "FixTheLight")
            {
                print("crossing havetime trigger");
                MngrScript.Instance.toggleDoors();
                MngrScript.Instance.PushSubtitle("I'm running out of time, I'd better hurry","Keeper28",false);
                Destroy(gameObject);
            }
            
            
        }
    }
}
