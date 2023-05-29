using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint3Triggers : MonoBehaviour
{
    private MovementControllerScript myMovementController;
    private ChainSoundController myChainSoundController;
    private CameraRotations myCameraScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();

        GameObject CameraController = GameObject.Find("Camera");
        myCameraScript = CameraController.GetComponent<CameraRotations>();

        GameObject ChainController = GameObject.Find("ChainSoundManager");
        myChainSoundController = ChainController.GetComponent<ChainSoundController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        myMovementController.movementSpeed = 3.0f;
        myCameraScript.positionUpdated = true;
        myChainSoundController.playSound(1.0f);
    }
}
