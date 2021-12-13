using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasTrail : MonoBehaviour
{
    public TrailRenderer trail;
    private bool trying = true;

    private bool changed = false;
    // Start is called before the first frame update
    void Start()
    {
        trail.emitting = false;
    }
    
    IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(3);
        MngrScript.Instance.setOneBlurb("make a trail of gasoline outside");
    }
    IEnumerator WaitToChange2()
    {
        yield return new WaitForSeconds(1);
        MngrScript.Instance.setOneBlurb("light the gasoline");
    }

    // Update is called once per frame
    void Update()
    {
        if (MngrScript.Instance.WeDidntStartTheFire == true)
        {
            //print("help me please im drowning");
            if (changed == false)
            {
                trail.emitting = true;
                StartCoroutine(WaitToChange());
                changed = true;
            }
            
            
            if (MngrScript.Instance.LeavingWeDidnt && trail.emitting==true)
            {
                trail.emitting = false;
                MngrScript.Instance.chooseBlurbByChar("a");
                StartCoroutine(WaitToChange2());
                //Destroy(this);
                
            }
        }
    }
}
