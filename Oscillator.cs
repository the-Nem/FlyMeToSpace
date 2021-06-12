using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public static Oscillator instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    Vector3 StratingPos;
    [SerializeField] Vector3 MoveventVector;
    [SerializeField] [Range(0,1)] float MoveventFactor;
    [SerializeField] float period = 2f;

    public bool coll;

    void Start()
    {
        coll = false;
        StratingPos = transform.position;
    }
    void Update()
    {
        AtoB();
    }

    private void AtoB()
    {
    
            if (period <= Mathf.Epsilon) { return; }
            float Cycles = Time.time / period;              //continually growing over time
            const float tau = Mathf.PI * 2;                 //const value of 6.283
            float rawSinWave = Mathf.Sin(Cycles * tau);       //going from -1,1
            MoveventFactor = (rawSinWave + 1f) / 2f;        //without this, movement distance will be -1,1, now it is 0,1
            Vector3 offset = MoveventVector * MoveventFactor;
            transform.position = StratingPos + offset;
        
    }
}
