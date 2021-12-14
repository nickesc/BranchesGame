using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class grabTools : MonoBehaviour
{
    private bool lighted = false;
    private bool activated = false;
    private bool sent = false;
    
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    public GameObject box;

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
            if (MngrScript.Instance.ChoosingFix==true)
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to pick up the tools");
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
    
    bool set = false;

    IEnumerator WaitForChange()
    {
        Destroy(box);
        MngrScript.Instance.chooseBlurbByChar("a");
        yield return new WaitForSeconds(3);
        MngrScript.Instance.setOneBlurb("fix the light", "objective");
        MngrScript.Instance.BasementTools = true;
        Destroy(this);
    }

    private void OnTriggerStay(Collider other)
    {
        


         



         
        if (activated == false)
        {
            if (lighted)
            {
                if (other == FOVCone && isAxisButtonDown(button))
                {
                    activated = true;
                    MngrScript.Instance.ChoosingFix = false;
                    print("basementTools");
                    triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                    MngrScript.Instance.SetPrompt("");
                    StartCoroutine(WaitForChange());
                    //MngrScript.Instance.Alternatives = true;
                }

            }
        }
    }
}
