using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWP8 : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private CameraRotations myCameraScript;

    void Start()
    {
        GameObject CameraController = GameObject.Find("Camera");
        myCameraScript = CameraController.GetComponent<CameraRotations>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        myCameraScript.positionUpdated = true;
    }
}
