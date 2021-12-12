using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class TryRadio : MonoBehaviour
{
    
    private bool lighted = false;
    private bool activated = false;
    private bool sent = false;
    
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    private bool tryRadio = false;
    public GameObject headphones;
    private bool waitingForVoice = false;
    public GameObject photoLight;

    // Start is called before the first frame update
    void Start()
    {
        photoLight.SetActive(false);
        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lighted == false)
        {
            if (MngrScript.Instance.getCurrentState()=="Radioing")
            {
                triggerObject.GetComponent<HighlightEffect>().SetHighlighted(true);
                photoLight.SetActive(true);
                lighted = true;
            }
        }

        if (MngrScript.Instance.Radioed == true && MngrScript.Instance.playingVA == false)
        {
            MngrScript.Instance.WhatNext = true;
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to radio the ship");
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

    IEnumerator WaitForResponse()
    {
        headphones.SetActive(false);
        MngrScript.Instance.PushSubtitle("static");
        yield return new WaitForSeconds(5);
        headphones.SetActive(true);
        MngrScript.Instance.Radioed = true;
        MngrScript.Instance.PushSubtitle("Crap, no answer","Keeper19", false );
        MngrScript.Instance.PushSubtitle("What am I gonna do now?","Keeper14", false );
        //waitingForVoice = true;

    }

    private bool set = false;

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
                if (other == FOVCone)
                {
                    if (set == false)
                    {
                        MngrScript.Instance.SetPrompt("Press [E] or (X) to radio the ship");
                        set = true;
                    }

                    if (isAxisButtonDown(button))
                    {
                        activated = true;

                        print("radioing");
                        MngrScript.Instance.chooseBlurbByChar("a", false);
                        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                        MngrScript.Instance.SetPrompt("");
                        StartCoroutine(WaitForResponse());
                    }

                }
            }
        }
    }
}
