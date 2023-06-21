using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeedController : MonoBehaviour
{
    private const float fastMovementSpeed = 14.0f;
    private const float slowMovementSpeed = 7.0f;
    private const float stopMovementSpeed = 0.0f;

    public float currentMovementSpeed;
    public float wheelSpeed;

    private const int slowMovementID = 0;
    private const int stopMovementID = 1;

    public bool justCrossed = false;
    public int crossCounter = 0;
    public bool slowingDown = false;

    public Transform[] wheels;

    // Start is called before the first frame update
    void Start()
    {
        currentMovementSpeed = stopMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rotateWheel();
    }

    public void resetSpeed(bool hasCrossed)
    {
        currentMovementSpeed = fastMovementSpeed;
    }

    public void changeMovementspeed(int ID)
    {
        if (currentMovementSpeed != stopMovementSpeed)
        {
            if (ID == slowMovementID)
            {
                currentMovementSpeed = slowMovementSpeed;
            }
            else if (ID == stopMovementID)
            {
                currentMovementSpeed = stopMovementSpeed;
            }
            else
            {
                currentMovementSpeed = fastMovementSpeed;
            }
        }
    }

    public void rotateWheel()
    {
        wheelSpeed = currentMovementSpeed * 20;
        foreach(Transform hubcap in wheels)
        {
            hubcap.RotateAround(hubcap.position, Vector3.forward, wheelSpeed * Time.deltaTime * Time.timeScale);
        }

    }

    public void startCars()
    {
        resetSpeed(false);
    }

    public void stopCars()
    {
        currentMovementSpeed = stopMovementSpeed;
    }

}
