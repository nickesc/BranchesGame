using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerEvent : MonoBehaviour
{
  public GameObject square;
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
        //MngrScript.Instance.FirstDoor = true;
        //Destroy(other);
        //print(MngrScript.Instance.FirstDoor);
        //SceneManager.LoadScene("MainMenuScene");
    }
}
