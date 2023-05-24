using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWP6 : MonoBehaviour
{
    private BlinkWarningController myWarningController;

    private CarSpeedController mySpeedController1;
    private CarSpeedController mySpeedController2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject WarningObject = GameObject.Find("WarningSymbols");
        myWarningController = WarningObject.GetComponent<BlinkWarningController>();

        GameObject SpeedObject1 = GameObject.Find("CarMovementController1");
        GameObject SpeedObject2 = GameObject.Find("CarMovementController2");
        mySpeedController1 = SpeedObject1.GetComponent<CarSpeedController>();
        mySpeedController2 = SpeedObject2.GetComponent<CarSpeedController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        mySpeedController1.startCars();
        mySpeedController2.startCars();
        Invoke(nameof(callWarning), 3.0f);
    }

    private void callWarning()
    {
        myWarningController.playRightWarning();
    }
}
