using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Singleton<SceneChanger>
{
    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene (name);
    }
    public void Exit()
    {
        Application.Quit ();
    }
}