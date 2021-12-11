using System;
using System.Collections;
using System.Collections.Generic;
using SensorToolkit;
using UnityEditor;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        return ("Test");
    }
    
    public TestState(MngrScript owner) { this.mngr = mngr; }
 
    public void Enter()
    {
        Debug.Log("Entering "+getName()+" state");
    }
 
    public void Execute()
    {
        //Debug.Log("updating test state");
    }
 
    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");
    }
}

public class SplashScreen : IState
{
    MngrScript mngr;
    //private bool playing = true;

    public string getName()
    {
        return ("SplashScreen");
    }
    public SplashScreen(MngrScript mngr)
    {
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        MngrScript.Instance.Splash = false;
        Debug.Log("Entering "+getName()+" state");
        SceneManager.LoadScene("Splash");
        
        
        //mngr.setSunsetSky();
    }

    public void Execute()
    {
        if (mngr.Splash == true)
        {
            mngr.ChangeState(new Menu(mngr));
        }
    }
 
    public void Exit()
    {
        
        Debug.Log("Exiting "+getName()+" state");
    }
}

public class Menu : IState
{
    MngrScript mngr;
    private bool pushed = false;

    public string getName()
    {
        return ("Menu");
    }
    public Menu(MngrScript mngr)
    {
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("Entering "+getName()+" state");
        //mngr.setSunsetSky();
    }
 
    public void Execute()
    {
        if (mngr.isAxisButtonDown("Jump") && pushed==false)
        {
            pushed = true;
            mngr.setNightSky();
            mngr.Wait(.5f);
            
            
        }
        if (mngr.waiting != true && pushed==true)
        {
            mngr.ChangeState(new BranchesStart(mngr));
        }
    }
 
    public void Exit()
    {
        
        Debug.Log("Exiting "+getName()+" state");
    }
}
public class BranchesStart : IState
{
    MngrScript mngr;
    private bool changedSky = false;
    //private bool changedLight = false;

    public string getName()
    {
        return ("BranchesStart");
    }
    public BranchesStart(MngrScript mngr)
    {
        this.mngr = mngr;
    }
    
 
    public void Enter()
    {
        Debug.Log("Entering "+getName()+" state");
        SceneManager.LoadScene("SampleScene");
        
        
    }
 
    public void Execute()
    {
        if (changedSky == false)
        {
            try
            {
                mngr.sunsetLight = GameObject.FindWithTag("sunsetLight");
                mngr.nightLight = GameObject.FindWithTag("nightLight");
            }
            catch
            {
                Debug.Log("something is wrong with the sky");
            }

            mngr.setSunsetSky();
            //mngr.setBlurbs("get to the lighthouse","");
            mngr.setOneBlurb("get to the lighthouse");
            changedSky = true;
        }
        if (mngr.DisembarkedBoat == true)
        {
            mngr.ChangeState(new DisembarkedBoat(mngr));
        }
    }
 
    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");
    }
}
public class DisembarkedBoat : IState
{
    MngrScript mngr;
    public string getName()
    {
        return ("DisembarkedBoat");
    }
    
    public void SetIslandGameObjects()
    {
        Debug.Log("setting game objects");
        mngr.blockTower=GameObject.FindWithTag("blockTower");
        mngr.doorFrontOpen=GameObject.FindWithTag("frontDoorOpen");
        mngr.doorFrontOpen.SetActive(false);
        mngr.doorFrontClosed=GameObject.FindWithTag("frontDoorClosed");
        mngr.doorState = true;
        mngr.basementClosed = GameObject.FindWithTag("basementClosed");
        mngr.basementOpen = GameObject.FindWithTag("basementOpen");
        mngr.basementOpen.SetActive(false);
        mngr.basementState = true;
        mngr.yacht = GameObject.FindWithTag("yacht");
        mngr.yacht.SetActive(false);
        
    }

    public DisembarkedBoat(MngrScript mngr)
    {
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        Debug.Log("Entering "+getName()+" state");
        mngr.PushSubtitle("It's good to be back...", "silenceFive", false);
        SetIslandGameObjects();
        
        

        //mngr.InteractFreeze.Freeze();
        //mngr.SetImage("blackImage");
    }
 
    public void Execute()
    {
        //Debug.Log(MngrScript.Instance.getBlurbByChar("a") + " getbychar " + MngrScript.Instance.getBlurbByChar("b"));
        //Debug.Log("help please");
        if (mngr.ApproachedLighthouse == true)
        {
            
            mngr.ChangeState(new ApproachedLighthouse(mngr));
            
        }
    }
 
    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");
    }
}

public class ApproachedLighthouse : IState
{
    MngrScript mngr;
    private bool m_isAxisInUse;
    
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
        mngr.chooseBlurbByChar("a");
        Debug.Log("Entering "+getName()+" state");
        
        mngr.ReadLousNote = false;
        mngr.CancelFreeze.Freeze();
        m_isAxisInUse = true;
        mngr.PushSubtitle("There's a note on the door");
        mngr.SetPrompt("Press [LCtrl] or (B) to close");
        mngr.SetImage("LousNote");
        
        
        
    }
    
 
    public void Execute()
    {
        if (mngr.MouseFrozen==false)
        {
            if (mngr.ReadLousNote == false)
            {
                mngr.toggleDoors();
                mngr.SetPrompt("");
                mngr.SetImage("transparentImage");
                mngr.ReadLousNote = true;
                mngr.PushSubtitle("Thanks, Lou.", "silenceFive", false);
                mngr.setOneBlurb("get to bed");
            }
        }
        
        if (mngr.InBed)
        {
            //Exit();
            mngr.chooseBlurbByChar("a");
            mngr.ChangeState(new WokeUp(mngr));
        }
    }
    

    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");
        
        mngr.SetPrompt("");
        mngr.Blackout(true);
        mngr.OpeningDone = true;
        mngr.WokeUp = false;
    }
}
public class WokeUp : IState
{
    MngrScript mngr;
    //private bool m_isAxisInUse;
    
    public string getName()
    {
        return ("WokeUp");
    }

    public WokeUp(MngrScript mngr)
    {
        
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        Debug.Log("Entering "+getName()+" state");
        mngr.setNightSky();
        mngr.yacht.SetActive(false);
        //mngr.toggleBasement();
        mngr.setTwoBlurbs("head into town", "light the beacon", 7,"options");
        
        mngr.Wait(5);
        mngr.PushSubtitle("What time is it? Ugh...", "silenceFive", false);
        mngr.PushSubtitle("Better get get started on the things Lou mentioned.", "silenceFive", false);

        mngr.blockTower.SetActive(false);
        
        
    }
    
 
    public void Execute()
    {

        if (mngr.waiting==false && mngr.WokeUp==false)
        {
            mngr.Blackout(false);
            mngr.WokeUp = true;
        }

        if (mngr.GoneUp)
        {
            mngr.ChangeState(new GoneUp(mngr));
        }
        if (mngr.GoneOut)
        {
            mngr.ChangeState(new GoneOut(mngr));
        }
        
    }

    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");
        mngr.toggleDoors();
    }
}

//
//
//
// GONE UP BRANCH
//
//
//
//
public class GoneUp : IState
{
    MngrScript mngr;
    
    public string getName()
    {
        return ("GoneUp");
    }

    public GoneUp(MngrScript mngr)
    {
        
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        Debug.Log("Entering "+getName()+" state");
        mngr.chooseBlurbByChar("b");
        mngr.PushSubtitle("What's that on the water?","silenceFive",false);


    }
    
 
    public void Execute()
    {

        if (mngr.LightOut == true)
        {
            mngr.ChangeState(new LightOut(mngr));
        }
        
    }

    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");

    }
}
public class LightOut : IState
{
    MngrScript mngr;
    
    public string getName()
    {
        return ("LightOut");
    }

    public LightOut(MngrScript mngr)
    {
        
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        Debug.Log("Entering "+getName()+" state");


    }
    
 
    public void Execute()
    {
       
        
    }

    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");

    }
}




//
//
//
// GONE OUT BRANCH
//
//
//
//
public class GoneOut : IState
{
    MngrScript mngr;
    
    public string getName()
    {
        return ("GoneOut");
    }

    public GoneOut(MngrScript mngr)
    {
        
        this.mngr = mngr;
    }
 
    public void Enter()
    {
        Debug.Log("Entering "+getName()+" state");
        mngr.chooseBlurbByChar("a");
        
        
        
    }
    
 
    public void Execute()
    {
       
        
    }

    public void Exit()
    {
        Debug.Log("Exiting "+getName()+" state");

    }
}

public class MngrScript : Singleton<MngrScript>
{
    
    public bool MouseFrozen { get; set;}
    
    public bool FeetFrozen { get; set;}

    public int Score { get; set;}
    
    public bool Splash { get; set;}
    public bool DisembarkedBoat { get; set;}
    public bool ApproachedLighthouse { get; set;}
    public bool ReadLousNote { get; set;}
    public bool InBed { get; set;}
    public bool OpeningDone { get; set;}
    public bool WokeUp { get; set;}
    
    //
    // if you choose to go up to the light
    //
    public bool GoneUp { get; set;}
    
    public bool LightOut { get; set;}
    
    
    
    //If you choose to leave the lighthouse
    public bool GoneOut { get; set;}
    
    
    
    StateMachine stateMachine = new StateMachine();

    public GameObject Player = null;
    public CapsuleCollider playerCollider = null;
    public Collider FOVCollider = null;
    private Camera playerCamera;
    public AudioSource playerVASource = null;

    //public GameObject frontDoorClosed;
    //public GameObject frontDoorOpen;
    
    public GameObject doorFrontClosed;
    public GameObject doorFrontOpen;
    public GameObject basementClosed;
    public GameObject basementOpen;
    public bool doorState;
    public bool basementState;
    public GameObject blockTower;

    public GameObject yacht;
    public GameObject nightLight;
    public GameObject sunsetLight;
    
    private GameObject FreezerParent = null;
    private bool foundFreezers;

    public freezeInput CancelFreeze;
    public freezeInput JumpFreeze;
    public freezeInput InteractFreeze;
    public freezeInput PauseFreeze;
    public GameFreeze GameFreeze;

    public Text promptsUI = null;
    public RawImage imageUI = null;
    public GameObject fadeUI = null;
    public Text branchBlurbA = null;
    public Text branchBlurbB = null;
    public Text objectiveBlurb = null;
    public RawImage singleObjective = null;
    public RawImage doubleObjective = null;
    public Text subtitleUI = null;
    List<KeyValuePair<string, string>> subtitleQueue = new List<KeyValuePair<string, string>>();
    private int queueCount = 0;

    public bool waiting = false;
    public bool waiting1;
    public bool waiting2;
    public bool waiting3;
    public bool blurbWaiting;
    public bool playingVA = false;
    public bool tryingToLight = false;
    private bool blurbWait = false;

    //public Material sunset;
    //public Material night;
    
    //private string[] subtitles = new string[] {};
    //private float[] waitTimes = new float[] {};

    public bool isAxisButtonDown(string button)
    {
        //print(Input.GetAxis(_escapeKey));
        return Input.GetAxis(button) != 0;
    }
    public void Blackout(bool mode = true)
    {
        //fadeUI.SetActive(mode);
        
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
        print("help " + prompt);
        promptsUI.text = prompt;
    }


    public string getBlurbByChar(string blurb, bool @override = false)
    {
        if (@override == true)
        {
            if (blurb == "a")
            {
                return (branchBlurbA.text);
            }

            if (blurb == "b")
            {
                return (branchBlurbB.text);
            }
        }
        
        if (blurb == "a")
        {
            try
            {
                return (branchBlurbA.text.Substring(2));
            }
            catch
            {
                return "";
            }
        }

        if (blurb == "b")
        {
            try
            {
                return (branchBlurbB.text.Substring(2));
            }
            catch
            {
                return "";
            }
            
        }

        return "error";
    }

    public string getObjective(string title, string blurb)
    {
        if (blurb == "a")
        {
            return title + ":";
        }

        if (blurb=="b")
        {
            return title + ":\n\n\n\nor";
        }

        return "error";
    }

    public string[] getBlurbs()
    {
        string[] blurbs = {getBlurbByChar("a"), getBlurbByChar("b")};
        return blurbs;
    }

    public string[] clearBlurbs()
    {
        singleObjective.enabled = false;
        doubleObjective.enabled = false;

        branchBlurbA.text = "";
        branchBlurbB.text = "";
        objectiveBlurb.text = "";
        
        return getBlurbs();
    }

    IEnumerator SetBlurbWait(int time)
    {
        blurbWait = true;
        yield return new WaitForSeconds(time);
        blurbWait = false;
    }

    public string[] setOneBlurb(string text, int time=0, string title = "objectives")
    {
        StartCoroutine(SetBlurbWait(time));

        while (blurbWait)
        {
            blurbWait = blurbWait;
        }
        
        clearBlurbs();

        branchBlurbA.text = "☐ ";

        branchBlurbA.text = branchBlurbA.text + text;
        objectiveBlurb.text = getObjective(title, "a");
        singleObjective.enabled = true;


        string[] blurbs = {branchBlurbA.text, branchBlurbB.text};
        return blurbs;

    }
    
    public string[] setTwoBlurbs(string textA, string textB,int time = 0, string title = "objectives")
    {
        
        StartCoroutine(SetBlurbWait(time));

        while (blurbWait)
        {
            blurbWait = blurbWait;
        }
        
        clearBlurbs();

        branchBlurbA.text = "☐ ";
        branchBlurbB.text = "☐ ";

        branchBlurbA.text = branchBlurbA.text + textA;
        branchBlurbB.text = branchBlurbB.text + textB;
        objectiveBlurb.text = getObjective(title, "b");;
        doubleObjective.enabled = true;


        string[] blurbs = {branchBlurbA.text, branchBlurbB.text};
        return blurbs;

    }

    IEnumerator ChooseBlurbCoroutine(string blurb)
    {
        blurbWaiting = true;
        yield return new WaitForSeconds(10);
        if (getBlurbByChar(blurb, true).Contains("☑"))
        {
            clearBlurbs();
        }
        
    }

    public string[] chooseBlurbByChar(string blurb)
    {

        if (getBlurbByChar(blurb) != "")
        {
            string textA = getBlurbByChar("a");
            string textB = getBlurbByChar("b");
            string objective = objectiveBlurb.text;

            clearBlurbs();
            
            

            if (blurb == "a")
            {
                objectiveBlurb.text = objective.Replace("\n\n\n\nor","");
                branchBlurbA.text = "☑ " + textA;
                singleObjective.enabled = true;
                StartCoroutine(ChooseBlurbCoroutine(blurb));
            }

            if (blurb == "b")
            {
                objectiveBlurb.text = objective;
                branchBlurbA.text = "☐ " + textA;
                branchBlurbB.text = "☑ " + textB;
                doubleObjective.enabled = true;
                StartCoroutine(ChooseBlurbCoroutine(blurb));
            }
        }
        return getBlurbs();
    }
 

    public bool toggleDoors()
    {
        if (doorState == true)
        {
            doorFrontClosed.SetActive(false);
            doorFrontOpen.SetActive(true);
        }
        else
        {
            doorFrontClosed.SetActive(true);
            doorFrontOpen.SetActive(false);
        }

        doorState = !doorState;
        return doorState;
    }
    public bool toggleBasement()
    {
        if (basementState == true)
        {
            basementClosed.SetActive(false);
            basementOpen.SetActive(true);
        }
        else
        {
            basementClosed.SetActive(true);
            basementOpen.SetActive(false);
        }

        basementState = !basementState;
        return basementState;
    }

    IEnumerator Wait3Coroutine(float time)
    {
        
        waiting3 = true;
        yield return new WaitForSeconds(time);
        waiting3 = false;
    }

    IEnumerator Wait2Coroutine(float time)
    {
        
        waiting2 = true;
        yield return new WaitForSeconds(time);
        waiting2 = false;
    }
    
    IEnumerator Wait1Coroutine(float time)
    {
        
        waiting1 = true;
        yield return new WaitForSeconds(time);
        waiting1 = false;
    }

    public bool isWaiting()
    {
        
        if (waiting1 || waiting2 || waiting3)
        {
            return true;
        }

        return false;

    }

    public void Wait(float time)
    {
        if (waiting1)
        {
            if (waiting2)
            {
                StartCoroutine(Wait3Coroutine(time));
            }
            else
            {
                StartCoroutine(Wait2Coroutine(time));
            }
        }
        else
        {
            StartCoroutine(Wait1Coroutine(time));
        }
        
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

    private string cleanForSub(string subtitle, bool thought)
    {
        if (thought)
        {
            return "*" + subtitle + "*";
        }
        return "\"" + subtitle + "\"";
        
    }
    
    public void PushSubtitle(string subtitle, string fileName = "silenceFive", bool thought  = true)
    {
        
        if (subtitle == "")
        {
            subtitleUI.text = "";
        }
        else
        {
            
            
            KeyValuePair<string, string> subtitleInfo = new KeyValuePair<string, string>(cleanForSub(subtitle,thought), fileName);
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
    public void setSunsetSky()
    {
        Material sunset = Resources.Load<Material>("Skybox/Sunset1");
        Color fogColor;
        string htmlValue = "#F89C84";
        if (ColorUtility.TryParseHtmlString(htmlValue, out fogColor))
        {
            RenderSettings.fogColor = fogColor;
        }
        try
        {
            
            nightLight.SetActive(false);
            sunsetLight.SetActive(true);
        }
        catch
        {
            print("something is wrong with the sun");
        }
        RenderSettings.skybox=sunset;
    }
    public void setNightSky()
    {
        Material night = Resources.Load<Material>("Skybox/Night3");
        Color fogColor;
        string htmlValue = "#020013";
        if (ColorUtility.TryParseHtmlString(htmlValue, out fogColor))
        {
            RenderSettings.fogColor = fogColor;
        }

        try
        {
            nightLight.SetActive(true);
            sunsetLight.SetActive(false);
        }
        catch
        {
            print("something is wrong with the sun");
        }
        RenderSettings.skybox=night;
    }
    public void ChangeState(IState state)
    {
        stateMachine.ChangeState(state);
    }
    public string getCurrentState()
    {
        return stateMachine.currentState.getName();
    }
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
                GameFreeze = GameObject.FindWithTag("gameFreeze").GetComponent<GameFreeze>();
                
            }
            catch
            {
                print("freezers not found yet");
                
            }
        }

        if (GameFreeze == null)
        {
            GameFreeze = GameObject.FindWithTag("gameFreeze").GetComponent<GameFreeze>();
            if (GameFreeze == null)
            {
                print("GameFreeze not found yet");
            }
        }
    }
    void tryFindPlayer()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
            if (Player == null)
            {
                print("Player not found yet");
            }
        }
        
        try
        {
            playerCollider = Player.GetComponent<CapsuleCollider>();
        }
        catch
        {
            print("PlayerCollider not found yet");
        }


        
        if (playerVASource == null)
        {
            playerVASource = GameObject.FindWithTag("playerVASource").GetComponent<AudioSource>();
            if (playerVASource == null)
            {
                print("playerVASource not found yet");
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
            imageUI = GameObject.FindWithTag("imageUI").GetComponent<RawImage>();
            if (imageUI == null)
            {
                print("imageUI not found yet");
            }
        }
        if (fadeUI == null)
        {
            try
            {
                fadeUI = GameObject.FindWithTag("fadeUI");
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
        
        if (objectiveBlurb == null)
        {
            try
            {
                objectiveBlurb = GameObject.FindWithTag("objectiveBlurb").GetComponent<Text>();
                

            }
            catch
            {
                print("objectiveBlurb not found yet");
            }
        }
        if (branchBlurbA == null)
        {
            try
            {
                branchBlurbA = GameObject.FindWithTag("branchBlurbA").GetComponent<Text>();
                

            }
            catch
            {
                print("branchBlurbA not found yet");
            }
        }
        if (branchBlurbB == null)
        {
            try
            {
                branchBlurbB = GameObject.FindWithTag("branchBlurbB").GetComponent<Text>();
                

            }
            catch
            {
                print("branchBlurbB not found yet");
            }
        }
        if (singleObjective == null)
        {
            try
            {
                singleObjective = GameObject.FindWithTag("singleObjective").GetComponent<RawImage>();
                singleObjective.enabled = false;


            }
            catch
            {
                print("singleObjective not found yet");
            }
        }
        if (doubleObjective == null)
        {
            try
            {
                doubleObjective = GameObject.FindWithTag("doubleObjective").GetComponent<RawImage>();
                doubleObjective.enabled = false;


            }
            catch
            {
                print("doubleObjective not found yet");
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

    public override void Awake()
    {
        base.Awake();
    }
    
    void Start()
    {
         //tryFindFreezers();
         //tryFindCanvas();
         //tryFindPlayer();
         stateMachine.ChangeState(new SplashScreen(this));
    }
    
    // Update is called once per frame
    void Update()
    {
        waiting = isWaiting();
        
        if (getCurrentState() != "Menu" && getCurrentState() != "SplashScreen")
        {
            tryFindFreezers();
            tryFindCanvas();
            tryFindPlayer();
            tryPlayVA();
        }
        
        stateMachine.Update();
    }
}
