using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject top;
    public GameObject controls;
    public GameObject intro;
    
    private bool m_isAxisInUse = true;

    private int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if( Input.GetAxisRaw("Jump") == 0)
        {
            m_isAxisInUse = false;
        }
        
        controls.SetActive(false);
        intro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if( Input.GetAxisRaw("Jump") != 0)
        {
            if(m_isAxisInUse == false)
            {
                // Call your event function here.
                m_isAxisInUse = true;

                //MngrScript.Instance.Menuing = false;
                if (count == 0)
                {
                    top.SetActive(false);
                    controls.SetActive(true);
                    count++;
                }
                else if (count==1)
                {
                    controls.SetActive(false);
                    intro.SetActive(true);
                    count++;
                }
                else
                {
                    MngrScript.Instance.Menuing = false;
                }
                
                
            }
        }
        if( Input.GetAxisRaw("Jump") == 0)
        {
            m_isAxisInUse = false;
        }    
        
    }
}
