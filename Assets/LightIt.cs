using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIt : MonoBehaviour
{
    private bool lighted = false;
    private bool activated = false;
    private bool sent = false;

    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    

    public GameObject hallFire;
    public GameObject towerFire1;
    public GameObject towerFire2;
    public GameObject beaconFire1;
    public GameObject beaconFire2;
    public TrailRenderer gasTrail;

    // Start is called before the first frame update
    void Start()
    {
        hallFire.SetActive(false);
        towerFire1.SetActive(false);
        beaconFire1.SetActive(false);
        towerFire2.SetActive(false);
        beaconFire2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lighted == false)
        {
            if (MngrScript.Instance.LeavingWeDidnt == true)
            {
                lighted = true;
            }
        }
    }

    bool isAxisButtonDown(string _button)
    {
        print(Input.GetAxis(_button));
        return Input.GetAxis(_button) != 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        print("trigger enter");
        if (activated == false)
        {
            if (lighted)
            {
                MngrScript.Instance.SetPrompt("Press [E] or (X) to light the gasoline");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("trigger exit");
        if (activated == false)
        {
            if (other == FOVCone && lighted)
            {
                MngrScript.Instance.SetPrompt("");
            }
        }
    }

    IEnumerator LightItCoroutine()
    {
        MngrScript.Instance.turnAround = true;
        MngrScript.Instance.PushSubtitle("...", "silenceFive", false);
        yield return new WaitForSeconds(2);
        gasTrail.Clear();
        yield return new WaitForSeconds(2);
        hallFire.SetActive(true);
        yield return new WaitForSeconds(2);
        towerFire1.SetActive(true);
        yield return new WaitForSeconds(3);
        towerFire2.SetActive(true);
        yield return new WaitForSeconds(4);
        beaconFire1.SetActive(true);
        yield return new WaitForSeconds(2);
        beaconFire2.SetActive(true);
        yield return new WaitForSeconds(2);
        MngrScript.Instance.Lit = true;
        MngrScript.Instance.PushSubtitle("I'd better make sure they're alright", "Keeper27", false);
        Destroy(gameObject);
    }




private void OnTriggerStay(Collider other)
    {


        // make sure the object has a collider
        // and that 'isTrigger' is True
        // Apply to ALL MESHES WITH A COLLIDER
        // it will not activaate if the other
        // colliders in the trigger are also triggers



        // if the object needs to freeze the game on interaction, add this:
        if (activated == false)
        {
            if (lighted)
            {
                if (other == FOVCone && isAxisButtonDown(button))
                {
                    activated = true;
                    //MngrScript.Instance.WeDidntStartTheFire = true;
                    
                    print("we didn't start the fire");
                    MngrScript.Instance.chooseBlurbByChar("a");
                    MngrScript.Instance.SetPrompt("");
                    //Destroy(gameObject);
                    //MngrScript.Instance.Alternatives = true;
                    StartCoroutine(LightItCoroutine());



                }
            }
        }
    }
}
