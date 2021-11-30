using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveUI : MonoBehaviour
{

    public Texture transparentImage;
    public RawImage crosshair;
    
    // Start is called before the first frame update
    void Start()
    {
        crosshair.texture = transparentImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
