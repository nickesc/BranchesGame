using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using HighlightPlus;
using UnityEngine;

public class alternatives : MonoBehaviour
{
    // Start is called before the first frame update
    private bool lighted = false;
    private bool activated = false;
    private bool sent = false;
    
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;

    // Start is called before the first frame update
    void Start()
    {
        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lighted == false)
        {
            if (MngrScript.Instance.getCurrentState()=="WhatNext")
            {
                triggerObject.GetComponent<HighlightEffect>().SetHighlighted(true);
                lighted = true;
            }
        }
        if (MngrScript.Instance.FixTheLight == true)
        {
            triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
            lighted = false;
            Destroy(this);
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
            if (lighted)
            {
                MngrScript.Instance.SetPrompt("Press [E] or (X) to look for alternate ways to signal the ship in the emergency manual");
                set = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("trigger exit");
        if (activated == false)
        {
            if (other == FOVCone && lighted)
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
                        MngrScript.Instance.SetPrompt("Press [E] or (X) to look for alternate ways to signal the ship in the emergency manual");
                        set = true;
                    }

                    if (isAxisButtonDown(button))
                    {
                        activated = true;

                        print("alternatives");
                        //MngrScript.Instance.chooseBlurbByChar("a");
                        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                        MngrScript.Instance.SetImage("emergencyManual");
                        MngrScript.Instance.CancelFreeze.Freeze();
                        MngrScript.Instance.SetPrompt("Press [LCtrl] or (B) to continue");
                        MngrScript.Instance.Alternatives = true;
                        Destroy(this);

                    }
                }
            }
        }
    }
}
