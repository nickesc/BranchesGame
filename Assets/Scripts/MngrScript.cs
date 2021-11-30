using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;




public interface IState
{
    public string getName();
    public void Enter();
    public void Execute();
    public void Exit();
}
 
public class StateMachine
{
    public IState currentState;
 
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
 
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
 
public class TestState : IState
{
    MngrScript mngr;

    public string getName()
    {
        return ("");
    }
    
    public TestState(MngrScript owner) { this.mngr = mngr; }
 
    public void Enter()
    {
        Debug.Log("entering test state");
    }
 
    public void Execute()
    {
        Debug.Log("updating test state");
    }
 
    public void Exit()
    {
        Debug.Log("exiting test state");
    }
}


public class StartState : IState
{
    MngrScript mngr;

    public string getName()
    {
        return ("StartState");
    }
    public StartState(MngrScript mngr)
    {
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        Debug.Log("entering StartState state");
    }
 
    public void Execute()
    {
        if (mngr.DisembarkedBoat == true)
        {
            mngr.ChangeState(new DisembarkedBoat(mngr));
        }
    }
 
    public void Exit()
    {
        Debug.Log("entering DisembarkedBoat state");
    }
}
public class DisembarkedBoat : IState
{
    MngrScript mngr;
    public string getName()
    {
        return ("DisembarkedBoat");
    }

    public DisembarkedBoat(MngrScript mngr)
    {
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        Debug.Log("entering DisembarkedBoat state");
        mngr.PushSubtitle("It's good to be back...");
    }
 
    public void Execute()
    {
        //Debug.Log("help please");
        if (mngr.ApproachedLighthouse == true)
        {
            mngr.ChangeState(new ApproachedLighthouse(mngr));
        }
    }
 
    public void Exit()
    {
        Debug.Log("entering DisembarkedBoat state");
    }
}

public class ApproachedLighthouse : IState
{
    MngrScript mngr;
    public string getName()
    {
        return ("ApproachedLighthouse");
    }

    public ApproachedLighthouse(MngrScript mngr)
    {
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        mngr.ReadLousNote = false;
        mngr.InteractFreeze.Freeze();
        mngr.SetPrompt("There's a note on the door");
        mngr.SetImage("blackImage");
        
        Debug.Log("entering ApproachedLighthouse state");
        
    }
    
 
    public void Execute()
    {
        if (mngr.FeetFrozen==false && mngr.ReadLousNote == false)
        {
            mngr.SetPrompt("");
            mngr.SetImage("transparentImage");
            mngr.ReadLousNote = true;
            mngr.PushSubtitle("Thanks, Lou.","VASampleClip");
        }

        if (mngr.InBed)
        {
            Exit();
        }
    }

    /*IEnumerator ExitFade()
    {
        mngr.InteractFreeze.Freeze();
        mngr.fadeControl.disableWhenFinish = true;
        mngr.fadeUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        //mngr.fadeUI.SetActive(false);
        
        mngr.fadeControl.firstToLast = false;
        mngr.fadeUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        mngr.InteractFreeze.Unfreeze();
        //mngr.fadeUI.SetActive(false);
    }*/

    public void Exit()
    {
        mngr.SetPrompt("");
        mngr.Blackout(true);
        mngr.OpeningDone = true;

        //StartCoroutine(ExitFade());


        //mngr.fadeControl.firstToLast = false;
        //mngr.fadeControl.disableWhenFinish = true;
        //mngr.fadeUI.SetActive(true);
        
        Debug.Log("we finished!");
        //mngr.Blackout(false);
    }
}

public class MngrScript : Singleton<MngrScript>
{
    public bool MouseFrozen { get; set;}
    
    public bool FeetFrozen { get; set;}

    public int Score { get; set;}
    
    public bool DisembarkedBoat { get; set;}
    public bool ApproachedLighthouse { get; set;}
    public bool ReadLousNote { get; set;}
    public bool InBed { get; set;}
    public bool OpeningDone { get; set;}
    
    
    StateMachine stateMachine = new StateMachine();

    private Camera playerCamera;
    public AudioSource playerVASource;
    
    private GameObject FreezerParent = null;
    
    public freezeInput CancelFreeze;
    public freezeInput JumpFreeze;
    public freezeInput InteractFreeze;
    public freezeInput PauseFreeze;
    public freezeInput GameFreeze;

    public Text promptsUI = null;
    public RawImage imageUI = null;
    public GameObject fadeUI = null;
    public GDTFadeEffect fadeControl;
    public Text subtitleUI = null;
    List<KeyValuePair<string, string>> subtitleQueue = new List<KeyValuePair<string, string>>();
    private int queueCount = 0;
    public bool playingVA = false;
    
    //private string[] subtitles = new string[] {};
    //private float[] waitTimes = new float[] {};

    public void Blackout(bool mode = true)
    {
        if (mode)
        {
            fadeUI.SetActive(true);
            GameFreeze.Freeze();
        }
        else
        {
            fadeUI.SetActive(false);
            GameFreeze.Unfreeze();
        }

    }
    public void SetPrompt(string prompt)
    {
        promptsUI.text = prompt;
    }

    IEnumerator SubtitleCoroutine(KeyValuePair<string, string> subtitleInfo)
    {
        while (subtitleUI.text != "")
        {
            yield return null;
        }
        
        subtitleUI.text = subtitleInfo.Key;
        playingVA = true;
        AudioClip voiceActing = Resources.Load<AudioClip>("Audio/Voice/"+subtitleInfo.Value);
        playerVASource.PlayOneShot(voiceActing);
        //print();
        yield return new WaitForSeconds(voiceActing.length);
        subtitleUI.text = "";
        playingVA = false;
        subtitleQueue.RemoveAt(0);
        queueCount--;
    }
    
    public void PushSubtitle(string subtitle, string fileName = "VASampleClip")
    {
        
        if (subtitle == "")
        {
            subtitleUI.text = "";
        }
        else
        {
            KeyValuePair<string, string> subtitleInfo = new KeyValuePair<string, string>(subtitle, fileName);
            subtitleQueue.Add(subtitleInfo);
            queueCount++;
            //int index = subtitles.IndexOf(subtitleInfo);
            //StartCoroutine(SubtitleCoroutine(subtitleInfo));
        }
    }
    public void SetImage(string imageName)
    {
        imageUI.texture = Resources.Load<Texture>("UI Images/"+imageName);
    }
    public void ChangeState(IState state)
    {
        stateMachine.ChangeState(state);
    }

    public string getCurrentState()
    {
        return stateMachine.currentState.getName();
    }

    public override void Awake()
    {
        base.Awake();
    }
    
    // Start is called before the first frame update

    void tryFindFreezers()
    {
        if (FreezerParent == null)
        {
            try
            {
                FreezerParent = GameObject.FindWithTag("FreezeObjects");
                freezeInput[] TempFreezers = FreezerParent.GetComponentsInChildren<freezeInput>();

                CancelFreeze = TempFreezers[0];
                JumpFreeze = TempFreezers[1];
                InteractFreeze = TempFreezers[2];
                PauseFreeze = TempFreezers[3];
                GameFreeze = TempFreezers[3];
            }
            catch
            {
                print("freezers not found yet");
            }
        }
    }
    
    void tryFindCanvas()
    {
        if (promptsUI == null)
        {
            try
            {
                promptsUI = GameObject.FindWithTag("promptsUI").GetComponent<Text>();
                SetPrompt("");

            }
            catch
            {
                print("promptsUI not found yet");
            }
        }
        if (imageUI == null)
        {
            try
            {
                imageUI = GameObject.FindWithTag("imageUI").GetComponent<RawImage>();
               
            }
            catch
            {
                print("imageUI not found yet");
            }
        }
        if (fadeUI == null)
        {
            try
            {
                print("help me");
                fadeUI = GameObject.FindWithTag("fadeUI");
                //fadeControl = fadeUI.GetComponent<GDTFadeEffect>();
                fadeUI.SetActive(false);
               
            }
            catch
            {
                print("fadeUI not found yet");
            }
        }
        if (subtitleUI == null)
        {
            try
            {
                subtitleUI = GameObject.FindWithTag("subtitleUI").GetComponent<Text>();
                PushSubtitle("");
               
            }
            catch
            {
                print("subtitleUI not found yet");
            }
        }
        
    }

    void tryPlayVA()
    {
        if (queueCount != 0 && playingVA==false)
        {
            StartCoroutine(SubtitleCoroutine(subtitleQueue[0]));
        }
    }
    
    void Start()
    {
         tryFindFreezers();
         tryFindCanvas();
         playerVASource = GameObject.FindWithTag("playerVASource").GetComponent<AudioSource>();
         stateMachine.ChangeState(new StartState(this));
    }

    

    // Update is called once per frame
    void Update()
    {
        tryFindFreezers();
        tryFindCanvas();
        tryPlayVA();
        stateMachine.Update();
    }
}
