using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class GrabGas : MonoBehaviour
{
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to pick up the gas can");
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
                        MngrScript.Instance.SetPrompt("Press [E] or (X) to pick up the gas can");
                        set = true;
                    }
                    if (isAxisButtonDown(button))
                    {
                        MngrScript.Instance.ChoosingAlt = false;
                        activated = true;
                        MngrScript.Instance.WeDidntStartTheFire = true;

                        print("we didn't start the fire");
                        //MngrScript.Instance.chooseBlurbByChar("b");
                        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                        MngrScript.Instance.SetPrompt("");
                        Destroy(gameObject);
                        //MngrScript.Instance.Alternatives = true;



                    }
                }
            }
        }
    }
}
