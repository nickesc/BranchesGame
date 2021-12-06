using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmOff : MonoBehaviour
{
    private bool played = false;

    public AudioSource clock;
    public AudioClip alarm;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (played == false)
        {
            if (MngrScript.Instance.getCurrentState() == "WokeUp")
            {
                clock.PlayOneShot(alarm);
                played = true;
            }
        }
    }
}
