using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class tpBack : MonoBehaviour
{
     private bool lighted = false;
    private bool activated = false;
    private bool sent = false;
    
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    public GameObject houseTarget;
    public GameObject player;

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
            if (MngrScript.Instance.getCurrentState()=="BasementTools")
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to go back up");
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
                if (other == FOVCone && isAxisButtonDown(button))
                {
                    
                    activated = true;

                    print("tp basement");
                    
                    triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                    MngrScript.Instance.SetPrompt("");
                    player.transform.position = houseTarget.transform.position;
                    player.transform.rotation = houseTarget.transform.rotation;
                    //MngrScript.Instance.setOneBlurb("use tools from the basement","fix the light");
                    //MngrScript.Instance.Blackout(false,false);
        
                    Destroy(this);
                    //MngrScript.Instance.Alternatives = true;

                }
            }
        }
    }
}
