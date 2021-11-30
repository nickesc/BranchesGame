using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFreeze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        MngrScript.Instance.ApproachedLighthouse = true;
        
        GameObject originalGameObject = GameObject.Find("FreezeObjects");
        GameObject child = originalGameObject.transform.GetChild(0).gameObject;

        freezeInput[] childScripts = originalGameObject.GetComponentsInChildren<freezeInput>();
        //gameObject.GetComponent<freezeInput>.Freeze();
        childScripts[0].Freeze();
        
        Destroy(gameObject);
    }
}
