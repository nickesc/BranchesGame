using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstDoorScript : MonoBehaviour
{
    public GameObject firstDoorBarrier;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print("help");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("help");
        //MngrScript.Instance.FirstDoor = true;
        Destroy(gameObject);
        //print(MngrScript.Instance.FirstDoor);
        Instantiate(firstDoorBarrier, new Vector3(-24, 2, 25), Quaternion.identity);
        Destroy(this);
        //SceneManager.LoadScene("MainMenuScene");


    }
}
