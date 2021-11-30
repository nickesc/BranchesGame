using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onMouseOverToolTip : MonoBehaviour
{
    public Transform target;
    public Text hint;
    public Camera cam;
    private bool justCleared = false;
    public string hintText;
    
    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main;
        cam = cam.GetComponent<Camera>();
        hint.text = "";
        justCleared = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 viewPos = cam.WorldToViewportPoint(target.position);

        if (viewPos.x > 0.4F && viewPos.x < 0.6F)
        {
            if (viewPos.z > 0 && viewPos.z < 2.5)
            {
                if (viewPos.y > 0.25f && viewPos.y < 0.75f)
                {
                    hint.text = hintText;
                    justCleared = false;
                }
            }
            else
            {
                hint.text = "";
                justCleared = true;
            }
            //print(viewPos.z + " helppp");
            
        }
        else
        {
            if (!justCleared)
            {
                hint.text = "";
                justCleared = true;
            }
        }
        
    }


}
