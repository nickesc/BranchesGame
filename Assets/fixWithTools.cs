using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class fixWithTools : MonoBehaviour
{
    // Start is called before the first frame update
    private bool lighted = false;
    private bool activated = false;
    private bool sent = false;
    
    public GameObject stand;
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    public AudioSource fixClip;
    public GameObject beaconLight;
    

    // Start is called before the first frame update
    void Start()
    {
        beaconLight.SetActive(false);
        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lighted == false)
        {
            if (MngrScript.Instance.BasementTools==true)
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
                MngrScript.Instance.SetPrompt("Press [E] or (X) to fix the light");
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

    IEnumerator FixingSequence()
    {
        fixClip.PlayOneShot(fixClip.clip);
        yield return new WaitForSeconds(fixClip.clip.length+2);
        beaconLight.SetActive(true);
        stand.SetActive(false);
        MngrScript.Instance.turnAround = true;
        MngrScript.Instance.chooseBlurbByChar("a");
        MngrScript.Instance.PushSubtitle("Thank God, it worked...", "Keeper25", false);
        MngrScript.Instance.PushSubtitle("I'd better make sure they're alright", "Keeper27", false);
        while (MngrScript.Instance.playingVA)
        {
            yield return null;
        }
        MngrScript.Instance.Fixed = true;
        Destroy(this);
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
                    print("fix the light!");
                    //MngrScript.Instance.chooseBlurbByChar("b");
                    triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                    MngrScript.Instance.SetPrompt("");
                    StartCoroutine(FixingSequence());

                    //MngrScript.Instance.Alternatives = true;



                }

            }
        }
    }
}
