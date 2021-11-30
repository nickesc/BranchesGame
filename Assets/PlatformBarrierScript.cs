using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformBarrierScript : MonoBehaviour
{
  public GameObject platformBarrier;
  public GameObject frontDoorBarrier;
  public GameObject frontDoorTrigger;
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
        //MngrScript.Instance.PlatformDoor = true;
        Destroy(gameObject);
        Destroy(frontDoorTrigger);
        //print(MngrScript.Instance.PlatformDoor);
        Instantiate(platformBarrier, new Vector3(-23, 41, 9), Quaternion.identity);
        Instantiate(frontDoorBarrier, new Vector3(-24, 2, 25), Quaternion.identity);
        Destroy(this);
        //SceneManager.LoadScene("MainMenuScene");


    }
}
