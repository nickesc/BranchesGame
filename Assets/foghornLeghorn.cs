using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class foghornLeghorn : MonoBehaviour
{
    // Start is called before the first frame update
    private bool lighted = false;
    private bool activated = false;
    private bool sent = false;
    
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    public AudioSource foggy;
    public AudioClip crash;

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
            if (MngrScript.Instance.ChoosingAlt==true)
            {
                triggerObject.GetComponent<HighlightEffect>().SetHighlighted(true);
                lighted = true;
            }
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to use the foghorn");
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
                    MngrScript.Instance.ChoosingAlt = false;
                    activated = true;
                    MngrScript.Instance.FoghornLeghorn = true;

                    print("foghorn leghorn");
                    //MngrScript.Instance.chooseBlurbByChar("b");
                    triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                    MngrScript.Instance.SetPrompt("");
                    MngrScript.Instance.PushSubtitle("I hope this is loud enough...","Keeper26",false);
                    MngrScript.Instance.PushSubtitle("foghorn","foghorn");
                    MngrScript.Instance.PushSubtitle("distant shipwreck","crash");
                    MngrScript.Instance.PushSubtitle("Oh no...","Keeper22",false);
                    Destroy(this);

                    //MngrScript.Instance.Alternatives = true;



                }

            }
        }
    }
}
