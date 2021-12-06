using System;
using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;



public class ApproachLighthouse : MonoBehaviour
{
    private Transform target;
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    public Camera cam;

    private bool seen;
    private bool unfrozen = false;
    

    // Start is called before the first frame update
    void Start()
    {
        target = triggerObject.GetComponent<Transform>();
        cam = cam.GetComponent<Camera>();
        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);

        if (seen == false)
        {
            if (viewPos.x > 0 && viewPos.x < 1)
            {
                if (viewPos.z > 0 && viewPos.z < 30)
                {
                    if (viewPos.y > 0 && viewPos.y < 1)
                    {
                        MngrScript.Instance.CancelFreeze.Freeze();
                        seen = true;
                        
                        MngrScript.Instance.SetPrompt("Objects outlined in white are interactable\nPress [LCtrl] or (B) to continue");
                    }
                }
               
                //print(viewPos.z + " helppp");

            }
        }

        
        if (seen == true && MngrScript.Instance.FeetFrozen == false)
        {
            
            if (unfrozen == false)
            {
                MngrScript.Instance.SetPrompt("");
            }
            
            unfrozen = true;
        }

        if (MngrScript.Instance.getCurrentState() == "DisembarkedBoat")
        {
            triggerObject.GetComponent<HighlightEffect>().SetHighlighted(true);
        }

    }
    
    bool isAxisButtonDown(string _button)
    {
        print(Input.GetAxis(_button));
        return Input.GetAxis(_button) != 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == FOVCone && MngrScript.Instance.getCurrentState()=="DisembarkedBoat")
        {
            MngrScript.Instance.SetPrompt("Press [E] or (X) to interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == FOVCone && MngrScript.Instance.getCurrentState()=="DisembarkedBoat")
        {
            MngrScript.Instance.SetPrompt("");
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
        if (MngrScript.Instance.getCurrentState() == "DisembarkedBoat")
        {
            if (other == FOVCone && isAxisButtonDown(button))
            {
                print("lighthouse trigger");
                //MngrScript.Instance.toggleDoors();
                triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                MngrScript.Instance.ApproachedLighthouse = true;
                
                Destroy(triggerObject);
                
            }
        }



        //GameObject originalGameObject = GameObject.Find("FreezeObjects");
        //GameObject child = originalGameObject.transform.GetChild(0).gameObject;

        //freezeInput[] childScripts = originalGameObject.GetComponentsInChildren<freezeInput>();
        //gameObject.GetComponent<freezeInput>.Freeze();
        //childScripts[0].Freeze();


        //Destroy(triggerObject);
        
        //SceneManager.LoadScene("MainMenuScene");
        //MngrScript.Instance.variable = true;
        //Instantiate(GameObject, new Vector3(-23, 41, 9), Quaternion.identity);



    }
}