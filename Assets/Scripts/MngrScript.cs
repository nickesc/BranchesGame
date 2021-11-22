using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MngrScript : Singleton<MngrScript>
{

    public int Score { get; set;}
    public bool FirstDoor { get; set;}
    public bool PlatformDoor { get; set;}
    
    public bool MouseFrozen { get; set;}
    
    public bool FeetFrozen { get; set;}

    public override void Awake()
    {
        base.Awake();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
