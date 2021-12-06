using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeingShip : MonoBehaviour
{
    private bool seen = false;
    public GameObject triggerObject;
    public Transform target;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        target = triggerObject.GetComponent<Transform>();
        cam = cam.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (MngrScript.Instance.getCurrentState() == "WokeUp")
        {
            if (seen == false)
            {
                Vector3 viewPos = cam.WorldToViewportPoint(target.position);

                if (seen == false)
                {
                    if (viewPos.x > 0 && viewPos.x < 1)
                    {
                    
                        if (viewPos.y > 0 && viewPos.y < 1)
                        {
                            //MngrScript.Instance.CancelFreeze.Freeze();
                            seen = true;
                            MngrScript.Instance.PushSubtitle("That doesn't look good...", "silenceFive", false);
                            //MngrScript.Instance.SetPrompt("Objects outlined in white are interactable\nPress [LCtrl] or (B) to continue");
                        }

                    }
                }
            }
        }
        
    }
}
