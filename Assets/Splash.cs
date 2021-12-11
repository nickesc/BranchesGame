using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Splash : MonoBehaviour
{
    private string movie = "LogoSplash.mov";
    public VideoPlayer video;

    void Start()
    {
        StartCoroutine(wait6());

    }

    IEnumerator wait6()
    {
        yield return new WaitForSeconds(6);
        MngrScript.Instance.Splash = true;
    }

    void Update()
    {
        if (MngrScript.Instance.isAxisButtonDown("Jump") && MngrScript.Instance.Splash == false)
        {
            MngrScript.Instance.Splash = true;


        }

    }
}