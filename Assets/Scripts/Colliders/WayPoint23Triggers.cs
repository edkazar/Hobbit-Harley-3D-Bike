using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint23Triggers : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        myMovementController.movementSpeed = 2.5f;
        myChainSoundController.playSound(0.5f);
    }
}
