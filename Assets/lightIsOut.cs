using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using SensorToolkit;
using UnityEngine;

public class lightIsOut : MonoBehaviour
{
    private bool lighted = false;
    private bool activated = false;
    private bool sent = false;

    //private Transform target;
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    private bool tryRadio = false;

    // Start is called before the first frame update
    void Start()
    {
        //cam = cam.GetComponent<Camera>();
        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lighted == false)
        {
            if (MngrScript.Instance.tryingToLight==true && MngrScript.Instance.playingVA==false)
            {
                triggerObject.GetComponent<HighlightEffect>().SetHighlighted(true);
                lighted = true;
            }
        }
        
        if (sent == true && MngrScript.Instance.playingVA == false && tryRadio==false)
        {
            tryRadio = true;
            MngrScript.Instance.setOneBlurb("radio the ship");
            MngrScript.Instance.Radioing = true;
            Destroy(this);
        }

        if (activated && sent == false)
        {
            MngrScript.Instance.PushSubtitle("You've gotta be kidding me, Lou. You broke the igniter",
                "Keeper10", false);
            MngrScript.Instance.PushSubtitle("I should try to radio them, they still can't see a thing out there",
                "Keeper18", false);
            MngrScript.Instance.chooseBlurbByChar("a",false);
            sent = true;
        }

        
    }

    bool isAxisButtonDown(string _button)
    {
        print(Input.GetAxis(_button));
        return Input.GetAxis(_button) != 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        print("trigger enter");
        if (activated == false)
        {
            if (other == FOVCone && lighted)
            {
                MngrScript.Instance.SetPrompt("Press [E] or (X) to light the beacon");
                set = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("trigger enter");
        if (activated == false)
        {
            if (other == FOVCone && MngrScript.Instance.getCurrentState() == "GoneUp")
            {
                MngrScript.Instance.SetPrompt("");
            }
        }
    }

    private bool set = false;

    private void OnTriggerStay(Collider other)
    {


         



         
        if (activated == false)
        {
            if (lighted)
            {
                if (other == FOVCone)
                {
                    if (set == false)
                    {
                        MngrScript.Instance.SetPrompt("Press [E] or (X) to light the beacon");
                        set = true;
                    }

                    if (isAxisButtonDown(button))
                    {
                        print("fresnel lens trigger");
                        //MngrScript.Instance.toggleDoors();
                        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                        MngrScript.Instance.SetPrompt("");
                        MngrScript.Instance.LightOut = true;
                        activated = true;
                        //MngrScript.Instance.ApproachedLighthouse = true;
                        //Destroy(triggerObject);
                    }
                }
            }
        }
    }
}
