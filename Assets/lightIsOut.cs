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
            if (MngrScript.Instance.tryingToLight==true)
            {
                triggerObject.GetComponent<HighlightEffect>().SetHighlighted(true);
                lighted = true;
            }
        }

        if (activated && sent == false)
        {
            MngrScript.Instance.PushSubtitle("You've gotta be kidding me, Lou. You broke the igniter",
                "silenceFive", false);
            MngrScript.Instance.chooseBlurbByChar("a");
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to interact");
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
