using System.Collections;
using System.Collections.Generic;
using CMF;
using UnityEngine;
using UnityEngine.UI;

public class DisembarkBoat : MonoBehaviour
{
    public GameObject triggerObject;
    //public GameObject ApproachLighthouseTrigger;
    //public GameObject Cube;

    //public AdvancedWalkerController player;
    //public CameraController cameraController;
    //public Camera camera;
    //public Text promptText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        // make sure the object has a collider
        // and that 'isTrigger' is True
        // Apply to ALL MESHES WITH A COLLIDER

        //print("help");
        MngrScript.Instance.DisembarkedBoat = true;
        //Instantiate(ApproachLighthouseTrigger, new Vector3(346.105f, 175.507f, 740.599f), Quaternion.identity);
        //Instantiate(Cube, new Vector3(244.4123f, 77.59f, 442.7618f), Quaternion.identity);
        
        
        Destroy(triggerObject);
        //Destroy(this);
        //SceneManager.LoadScene("MainMenuScene");
        //MngrScript.Instance.variable = true;
        //Instantiate(GameObject, new Vector3(-23, 41, 9), Quaternion.identity);
        


    }
}
