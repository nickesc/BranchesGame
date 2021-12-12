using System;
using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;
using Object = UnityEngine.Object;

public class seeingShip : MonoBehaviour
{


    private bool lighted = false;
    public HighlightEffect fenceEffect;
    public GameObject triggerObject;
    public Collider playerCapsule;
    public Collider FOVCone;

    // Start is called before the first frame update
    void Start()
    {
        fenceEffect.SetHighlighted(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (lighted == false)
        {
            if (MngrScript.Instance.getCurrentState()=="Lit")
            {
                MngrScript.Instance.setOneBlurb("Go to the cliff by the lighthouse");
                fenceEffect.SetHighlighted(true);
                lighted = true;
            }
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (lighted)
        {
            if (other == playerCapsule || other == FOVCone)
            {
                if (MngrScript.Instance.getCurrentState() == "Lit" && MngrScript.Instance.SeeingShip)
                {
                    fenceEffect.SetHighlighted(false);
                    lighted = false;
                        MngrScript.Instance.chooseBlurbByChar("a");
                        MngrScript.Instance.PushSubtitle("Thank God, it worked...", "Keeper25", false);
                        MngrScript.Instance.moveTheShip = true;
                        MngrScript.Instance.GameFreeze.Freeze();
                        Destroy(MngrScript.Instance.PauseFreeze);
                        MngrScript.Instance.Fin = true;
                        //MngrScript.Instance.SetPrompt("Objects outlined in white are interactable\nPress [LCtrl] or (B) to continue");

                }
            }
        }
    }
    
    

}

