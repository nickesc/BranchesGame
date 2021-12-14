using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapCargo : MonoBehaviour
{
    public GameObject cargo;
    public GameObject blocker;
    
    // Start is called before the first frame update
    void Start()
    {
        cargo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MngrScript.Instance.ChoosingFix==true)
        {
            blocker.SetActive(false);
            cargo.SetActive(true);
            Destroy(this);
        }
    }
}
