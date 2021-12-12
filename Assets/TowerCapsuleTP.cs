using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCapsuleTP : MonoBehaviour
{

    public GameObject partner;
    public GameObject player;
    public bool up;

    private Collider playerCapsule;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCapsule = player.GetComponent<Collider>();
    }

    IEnumerator tpTimeout()
    {
        MngrScript.Instance.tpTimeout = true;
        yield return new WaitForSeconds(1);
        MngrScript.Instance.tpTimeout = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (MngrScript.Instance.tpTimeout == false)
        {
            if (other == playerCapsule)
            {
                
                if (up == true)
                {
                    player.transform.Rotate(0, -90.0f, 0.0f, Space.Self);
                    player.transform.position = partner.transform.position + new Vector3(0, -0.665f);
                    

                }
                else
                {
                    player.transform.Rotate(0, 90.0f, 0.0f, Space.Self);
                    player.transform.position = partner.transform.position;
                }
            }
        }
    }
}
