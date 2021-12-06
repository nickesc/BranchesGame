using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;

public class GameFreeze : MonoBehaviour
{
    //public bool freezeMouse;
    //public bool freezeFeet;
    public bool freezing;
    public bool freezingMouse;
    public bool freezingFeet;
    
    
    public AdvancedWalkerController walkerController;
    public CameraController cameraController;
    
    
    // Start is called before the first frame update
    void Start()
    {

        MngrScript.Instance.FeetFrozen = MngrScript.Instance.MouseFrozen = false;
        freezingFeet = freezingMouse = freezing = false;
        
        Cursor.lockState = CursorLockMode.None;
    }

    public void Freeze(bool timePause = false, bool mouse=true, bool feet=true)
    {
        if (mouse)
        {
            freezingMouse = cameraController.FreezeMouse();
            MngrScript.Instance.MouseFrozen = freezingMouse;
        }

        if (feet)
        {
            freezingFeet = walkerController.FreezeFeet();
            MngrScript.Instance.FeetFrozen = freezingMouse;
        }

        

        if (freezingFeet || freezingMouse)
        {
            freezing = true;
        }
    }


    public void Unfreeze(bool timePause = false, bool mouse=true, bool feet=true)
    {
        //print("unfreezing: " + mouse + feet + timePause);
        if (mouse)
        {
            
            freezingMouse = cameraController.UnfreezeMouse(true);
            //print(freezingMouse);
            MngrScript.Instance.MouseFrozen = freezingMouse;
        }

        if (feet)
        {
            freezingFeet = walkerController.UnfreezeFeet(true);
            //print(freezingFeet);
            MngrScript.Instance.FeetFrozen = freezingFeet;
        }

        

        if (freezingFeet || freezingMouse)
        {
            freezing = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
