using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTemplate : MonoBehaviour
{
    public GameObject triggerObject;


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
        // it will not activaate if the other
        // colliders in the trigger are also triggers

        print("help");


        Destroy(triggerObject);
        //Destroy(this);
        //Destroy(gameObject);
        //SceneManager.LoadScene("MainMenuScene");
        //MngrScript.Instance.variable = true;
        //Instantiate(GameObject, new Vector3(-23, 41, 9), Quaternion.identity);



    }
}
