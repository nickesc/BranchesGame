using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class fixingOptions : MonoBehaviour
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

        if (MngrScript.Instance.Alternatives == true)
        {
            triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
            lighted = false;
            Destroy(this);
        }
        
        

        /*if (MngrScript.Instance.Radioed == true && MngrScript.Instance.playingVA == false)
        {
            MngrScript.Instance.WhatNext = true;
        }*/
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to check for ways to fix the light");
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
    

    private void OnTriggerStay(Collider other)
    {


        // make sure the object has a collider
        // and that 'isTrigger' is True
        // Apply to ALL MESHES WITH A COLLIDER
        // it will not activaate if the other
        // colliders in the trigger are also triggers



        // if the object needs to freeze the game on interaction, add this:
        if (activated == false)
        {
            if (lighted)
            {
                if (other == FOVCone && isAxisButtonDown(button))
                {
                    activated = true;
                    
                    print("alternatives");
                    MngrScript.Instance.chooseBlurbByChar("a");
                    triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                    MngrScript.Instance.SetPrompt("");
                    MngrScript.Instance.FixTheLight = true;
                    Destroy(this);


                }
            }
        }
    }
}
