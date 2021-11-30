using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MngrScript.Instance.Score += 5;
        //print(MngrScript.Instance.Score);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
