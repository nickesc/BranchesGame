using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openRight : MonoBehaviour
{

    private bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MngrScript.Instance.ChoosingFix == true && opened==false)
        {
            gameObject.SetActive(false);
            opened = true;
        }

    }
}
