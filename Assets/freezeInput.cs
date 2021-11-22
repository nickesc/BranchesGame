using System;
using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;

public class freezeInput : MonoBehaviour
{
    //public GameObject walkerController;
    public bool controlPause;
    public bool unpauseAllowed;
    public bool freezeMouse;
    public bool freezeFeet;

    public string escapeKey;
    //public KeyCode escapeKey;
    public AdvancedWalkerController walkerController;
    public CameraController cameraController;
    protected static bool mouseFrozen;
    protected static bool feetFrozen;
    
    private bool m_isAxisInUse = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        MngrScript.Instance.MouseFrozen = false;
        MngrScript.Instance.FeetFrozen = false;
        unpauseAllowed = controlPause;
        

    }

    bool isAxisButtonDown(string _escapeKey)
    {
        //print(Input.GetAxis(_escapeKey));
        return Input.GetAxis(_escapeKey) != 0;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.GetAxis(escapeKey));
        if( Input.GetAxisRaw(escapeKey) != 0)
        {
            if(m_isAxisInUse == false)
            {
                // Call your event function here.
                m_isAxisInUse = true;
                
                if (MngrScript.Instance.MouseFrozen || MngrScript.Instance.FeetFrozen)
                {
                    if (unpauseAllowed)
                    {
                        if (MngrScript.Instance.MouseFrozen)
                        {
                            if (isAxisButtonDown(escapeKey))
                            {
                                Unfreeze(true, false);
                            }
                        }

                        if (MngrScript.Instance.FeetFrozen)
                        {
                            if (isAxisButtonDown(escapeKey))
                            {
                                Unfreeze(false, true);
                            }
                        }
                    }
                }
                else
                {
                    if (controlPause)
                    {
                        if (isAxisButtonDown(escapeKey))
                        {
                            Freeze();
                        }
                    }
                }
                
            }
        }
        if( Input.GetAxisRaw(escapeKey) == 0)
        {
            m_isAxisInUse = false;
        } 
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Freeze(freezeMouse,freezeFeet);
    }

    public void Freeze(bool mouse=true, bool feet=true)
    {
        if (mouse)
        {
            MngrScript.Instance.MouseFrozen = cameraController.FreezeMouse();
            unpauseAllowed = true;
        }
        else
        {
            MngrScript.Instance.MouseFrozen = MngrScript.Instance.MouseFrozen;
        }
        
        if (feet)
        {
            MngrScript.Instance.FeetFrozen = walkerController.FreezeFeet();
            unpauseAllowed = true;
        }
        else
        {
            MngrScript.Instance.FeetFrozen = MngrScript.Instance.FeetFrozen;
        }

        if (controlPause)
        {
            Time.timeScale = 0;
        }
        
        
        
    }
    public void Unfreeze(bool mouse=true, bool feet=true)
    {
        if (mouse)
        {
            MngrScript.Instance.MouseFrozen = cameraController.UnfreezeMouse();
            unpauseAllowed = controlPause;
        }
        else
        {
            MngrScript.Instance.MouseFrozen = MngrScript.Instance.MouseFrozen;
        }
        
        if (feet)
        {
            MngrScript.Instance.FeetFrozen = walkerController.UnfreezeFeet();
            unpauseAllowed = controlPause;
        }
        else
        {
            MngrScript.Instance.FeetFrozen = MngrScript.Instance.FeetFrozen;
        }
        
        if (controlPause)
        {
            Time.timeScale = 1;
        }
        
    }
}
