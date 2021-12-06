using System.Collections;
using System.Collections.Generic;
using HighlightPlus;
using UnityEngine;

public class GetInBed : MonoBehaviour
{
    public GameObject triggerObject;
    public string button;
    public Collider FOVCone;
    


    // Start is called before the first frame update
    void Start()
    {
        triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MngrScript.Instance.getCurrentState() == "ApproachedLighthouse" && MngrScript.Instance.ReadLousNote)
        {
            triggerObject.GetComponent<HighlightEffect>().SetHighlighted(true);
        }

    }
    
    bool isAxisButtonDown(string _button)
    {
        print(Input.GetAxis(_button));
        return Input.GetAxis(_button) != 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == FOVCone && MngrScript.Instance.getCurrentState()=="ApproachedLighthouse")
        {
            MngrScript.Instance.SetPrompt("Press [E] or (X) to interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == FOVCone && MngrScript.Instance.getCurrentState()=="ApproachedLighthouse")
        {
            MngrScript.Instance.SetPrompt("");
        }
    }

    private void OnTriggerStay(Collider other)
    {

        
        // make sure the object has a collider
        // and that 'isTrigger' is True
        // Apply to ALL MESHES WITH A COLLIDER
        // it will not activaate if the other
        // colliders in the trigger are also triggers
        

        
        // if the object needs to freeze the game on interaction, add this:
        if (MngrScript.Instance.getCurrentState()=="ApproachedLighthouse")
        {
            if (other == FOVCone && isAxisButtonDown(button))
            {
                print("inbed trigger");
                triggerObject.GetComponent<HighlightEffect>().SetHighlighted(false);
                MngrScript.Instance.InBed = true;

                triggerObject.GetComponent<MeshCollider>().isTrigger = false;
                //Destroy(triggerObject.GetComponent<Rigidbody>());
                //Destroy(this);
                //doorsClosed.SetActive(false);
                //doorsOpen.SetActive(true);
            }
        }



        //GameObject originalGameObject = GameObject.Find("FreezeObjects");
        //GameObject child = originalGameObject.transform.GetChild(0).gameObject;

        //freezeInput[] childScripts = originalGameObject.GetComponentsInChildren<freezeInput>();
        //gameObject.GetComponent<freezeInput>.Freeze();
        //childScripts[0].Freeze();


        //Destroy(triggerObject);
        
        //SceneManager.LoadScene("MainMenuScene");
        //MngrScript.Instance.variable = true;
        //Instantiate(GameObject, new Vector3(-23, 41, 9), Quaternion.identity);



    }
}
