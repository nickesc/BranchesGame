using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateLou : MonoBehaviour
{

    public Animation animation;
    
    // Start is called before the first frame update
    void Start()
    {
        animation.wrapMode = WrapMode.Loop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
