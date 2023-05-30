using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint17Triggers : MonoBehaviour
{
    private ChainSoundController myChainSoundController;
    private CameraRotations myCameraScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject CameraController = GameObject.Find("Camera");
        myCameraScript = CameraController.GetComponent<CameraRotations>();

        GameObject ChainController = GameObject.Find("ChainSoundManager");
        myChainSoundController = ChainController.GetComponent<ChainSoundController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        myChainSoundController.stopSound();
        myCameraScript.positionUpdated = true;
    }
}
