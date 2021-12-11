using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTP : MonoBehaviour
{
    public bool up;
    public bool down;
    public GameObject player;

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
        if (up)
        {
            player.transform.position = player.transform.position + new Vector3(0, 18.65f);
        }

        if (down)
        {
            player.transform.position = player.transform.position + new Vector3(0, -18.65f);
        }
    }
}
