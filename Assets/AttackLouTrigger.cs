using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLouTrigger : MonoBehaviour
{

    public Collider playerCapsule;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AttackLouSequence()
    {
        MngrScript.Instance.chooseBlurbByChar("a");
        MngrScript.Instance.PushSubtitle("Lou! You broke the damn light! I need you to fix it!","Keeper20",false);
        MngrScript.Instance.PushSubtitle("I broke- what-?","Lou1",false);
        MngrScript.Instance.PushSubtitle("distant shipwreck","crash",true);
        MngrScript.Instance.PushSubtitle("Oh no...","Keeper22",false);
        yield return new WaitForSeconds(15);
        MngrScript.Instance.Fin = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCapsule)
        {
            if (MngrScript.Instance.getCurrentState() == "FixTheLight")
            {
                MngrScript.Instance.AttackLou = true;
                StartCoroutine(AttackLouSequence());
            }
        }
    }
}
