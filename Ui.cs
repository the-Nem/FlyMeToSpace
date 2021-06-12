using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Ui : MonoBehaviour
{
    //public GameObject Butt;
    public bool SpaceBoostBool = false;
    public bool LeftButbool = false;
    public bool RightButbool = false;

    void Start()
    {
        
    }


    void Update()
    {
        //if(Input.GetButton(Butt)) { }
        if (SpaceBoostBool) { Movement.instance.SpaceBut(); }
        if (LeftButbool) { Movement.instance.ButLeft(); }
        if (RightButbool) { Movement.instance.ButRight(); }
    }

    public void StartBut()
    {
        Collision.instance.LoadFirstLvl();
    }
    public void BoostOnClickDown()
    {
        SpaceBoostBool = true;
    }
    public void BoostOnClickUp()
    {
        SpaceBoostBool = false;
    }

    public void LeftDown()
    {
        LeftButbool = true;
        Debug.Log("L-D");
    }
    public void LeftUp()
    {
        LeftButbool = false;
        Debug.Log("L-u");
    }
    public void RightDown()
    {
        RightButbool = true; ;
        Debug.Log("R-D");
    }
    public void RightUp()
    {
        RightButbool = false;
        Debug.Log("R-u");
    }


}
