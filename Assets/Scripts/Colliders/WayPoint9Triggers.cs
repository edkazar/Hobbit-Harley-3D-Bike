using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint9Triggers : MonoBehaviour
{
    private BlinkWarningController myWarningController;

    private CarSpeedController mySpeedController1;
    private CarSpeedController mySpeedController2;
    private DrivewayCarMovementController myDrivewayCarController;
    private MovementControllerScript myMovementController;
    private ChainSoundController myChainSoundController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject WarningObject = GameObject.Find("WarningSymbols");
        myWarningController = WarningObject.GetComponent<BlinkWarningController>();

        GameObject SpeedObject1 = GameObject.Find("CarMovementController1");
        GameObject SpeedObject2 = GameObject.Find("CarMovementController2");
        mySpeedController1 = SpeedObject1.GetComponent<CarSpeedController>();
        mySpeedController2 = SpeedObject2.GetComponent<CarSpeedController>();

        GameObject DrContr = GameObject.Find("DrivewayCarMovementController");
        myDrivewayCarController = DrContr.GetComponent<DrivewayCarMovementController>();

        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();

        GameObject ChainController = GameObject.Find("ChainSoundManager");
        myChainSoundController = ChainController.GetComponent<ChainSoundController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        myMovementController.movementSpeed = 7.0f;
        myChainSoundController.playSound(1.5f);
        mySpeedController1.startCars();
        mySpeedController2.startCars();
        Invoke(nameof(callWarning), 3.0f);
    }

    private void callWarning()
    {
        myDrivewayCarController.startCarMovement = true;
        myWarningController.playRightWarning();
    }
}
