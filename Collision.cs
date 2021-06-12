
using System;
using UnityEngine;
using UnityEngine.SceneManagement;





public class Collision : MonoBehaviour
{
    public static Collision instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    [SerializeField] float DeleyLoadLvl = 3f;
    [SerializeField] AudioClip SoundDead;
    [SerializeField] AudioClip SoundFinishLvl;

    [SerializeField] ParticleSystem SuccessPartSys;
    [SerializeField] ParticleSystem CrashPartSys;



    AudioSource AudioSource;


    bool isTrans = false;
    bool CheatColl = false;

    void Start()
    {  
        AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        CheatNextLvl();
        CheatColliderOff();

    } 


    private void CheatNextLvl()
    {
        if (Input.GetKeyDown(KeyCode.L)) { FinishLevel(); }
    }
    private void CheatColliderOff()
    {
        if (Input.GetKeyDown(KeyCode.C)) { CheatColl=!CheatColl; }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (isTrans || CheatColl) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Method1();
                break;

            case "Finish":
                StartSuccessSequence();
                FinishLevel();
                break;

            case "Fuel":
                Method3();
                 break;
            default:
                Dead();
                break;
        }





    }

    private void StartSuccessSequence()
    {
        isTrans = true;
        AudioSource.Stop();
        AudioSource.PlayOneShot(SoundFinishLvl);
        SuccessPartSys.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("FinishLevel", 5f);

    }

    void  Method1()
    {
        Debug.Log("Friendly");
    }
    void FinishLevel()
    {
        
        int nextLevel = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = nextLevel + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;

        }

        SceneManager.LoadScene(nextSceneIndex);



    }
    void Method3()
    {
        Debug.Log("fuel");
    }
    void Dead()
    {
        //Oscillator.instance.coll = true;    this is giveing error
        isTrans = true;
        AudioSource.Stop();
        AudioSource.PlayOneShot(SoundDead);
        StartCrashSequence();

        Debug.Log("dead");
    }

    private void StartCrashSequence()
    {
        CrashPartSys.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLvL1", DeleyLoadLvl);


    }

    private void ReloadLvL1()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }

    public void LoadFirstLvl()
    {
        SceneManager.LoadScene(1);
    }
}
