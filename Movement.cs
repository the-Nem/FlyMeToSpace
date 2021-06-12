using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }


    Rigidbody rb;
    [SerializeField] float MainThrust = 1000f;
    [SerializeField] float MainRotate = 200f;
    [SerializeField] AudioClip mainEngine;
    AudioSource AudioSource;


    [SerializeField] ParticleSystem MainBoost;
    [SerializeField] ParticleSystem LeftBoost;
    [SerializeField] ParticleSystem RightBooster;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        QuitApp();
    }

    public static void QuitApp()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }

    public void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SpaceBut();

        }
        else { AudioSource.Stop(); MainBoost.Stop(); }
    }

    public void SpaceBut()
    {
        rb.AddRelativeForce(Vector3.up * MainThrust * Time.deltaTime);
        //if (!AudioSource.isPlaying) { AudioSource.PlayOneShot(mainEngine); }
        //if (!MainBoost.isPlaying) { MainBoost.Play(); }

        AudioSource.PlayOneShot(mainEngine); 
        MainBoost.Play(); 




    }

    public void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ButLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ButRight();

        }
    }

    public void ButRight()
    {
        ApplyRotation(-MainRotate);
        if (!LeftBoost.isPlaying) { LeftBoost.Play(); }
    }

    public void ButLeft()
    {
        ApplyRotation(MainRotate);
        if (!RightBooster.isPlaying) { RightBooster.Play(); }
    }

    public void ApplyRotation(float iritationthisframe)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * iritationthisframe * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
