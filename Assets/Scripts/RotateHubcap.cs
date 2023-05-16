using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHubcap : MonoBehaviour
{
    [SerializeField] Transform myHubcap;
    private float wheelSpeed = -5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myHubcap.Rotate(new Vector3(0,0, wheelSpeed));
    }
}
