using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint16Triggers : MonoBehaviour
{
    private MovementControllerScript myMovementController;
    private ChainSoundController myChainSoundController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();

        GameObject ChainController = GameObject.Find("ChainSoundManager");
        myChainSoundController = ChainController.GetComponent<ChainSoundController>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        myMovementController.movementSpeed = 3.0f;
        myChainSoundController.playSound(1.0f);
    }
}
