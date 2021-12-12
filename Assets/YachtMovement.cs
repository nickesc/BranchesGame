using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YachtMovement : MonoBehaviour
{
    private bool turned = false;
    private bool moved = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (turned == false)
        {
            if (MngrScript.Instance.turnAround == true)
            {
                gameObject.transform.Rotate(0, 180, 0.0f, Space.Self);
                turned = true;
            }
        }

        if (MngrScript.Instance.moveTheShip == true)
        {
            //print("this is real this is me");
            gameObject.transform.position += new Vector3(-.25f, 0, .25f);
        }

    }
}
