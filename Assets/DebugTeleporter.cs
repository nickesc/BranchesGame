using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTeleporter : MonoBehaviour
{
    public KeyCode lighthouseTPButton;
    public KeyCode townTPButton;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(lighthouseTPButton))
        {
            print("debug teleport to lighthouse");
            player.transform.position = new Vector3(348.8f, 174.59f, 731.7f);
        }
        if (Input.GetKeyDown(townTPButton))
        {
            print("debug teleport to town");
            player.transform.position = new Vector3(348.8f, 174.59f, 731.7f);
        }
    }
}
