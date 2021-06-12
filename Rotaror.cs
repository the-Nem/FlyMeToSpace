using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaror : MonoBehaviour
{
    [SerializeField] float xRot = 0;
    [SerializeField] float yRot = 1;
    [SerializeField] float zRot = 0;
    [SerializeField] float Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRot, yRot, zRot);
    }
}
