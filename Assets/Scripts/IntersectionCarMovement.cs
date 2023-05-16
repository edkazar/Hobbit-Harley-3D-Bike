using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionCarMovement : MonoBehaviour
{
    [SerializeField] Transform carTransform;
    private float movementSpeed = 3.0f;
    private int degresPerSecond = 2;
    private int currentTargetPos;
    private bool carTravelDone = false;
    public bool startCarMovement = false;

    public Transform[] wheels;
    private List<Transform> WayPoints;
    Vector3 directionFromMeToTarget;

    // Start is called before the first frame update
    void Start()
    {
        WayPoints = new List<Transform>();
        WayPoints.Add(GameObject.Find("WayPointCar2").transform);
        WayPoints.Add(GameObject.Find("WayPointCar3").transform);
        WayPoints.Add(GameObject.Find("WayPointCar4").transform);
        WayPoints.Add(GameObject.Find("WayPointCar5").transform);

        currentTargetPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!carTravelDone && startCarMovement)
        {
            rotationRoutine();

            carTransform.position = Vector3.MoveTowards(carTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
            updateTargetPosition();
        }
    }

    private void rotationRoutine()
    {
        //playerTransform.LookAt(WayPoints[currentTargetPos].position);
        
        if (currentTargetPos < 2)
        {
            directionFromMeToTarget = (carTransform.position - new Vector3(WayPoints[currentTargetPos].position.x + 90, WayPoints[currentTargetPos].position.y, WayPoints[currentTargetPos].position.z));
        }
        else
        {
            directionFromMeToTarget = (carTransform.position - new Vector3(WayPoints[currentTargetPos].position.x + 90, WayPoints[currentTargetPos].position.y, WayPoints[currentTargetPos].position.z + 90));
        }
        

        //directionFromMeToTarget.z = Mathf.Abs(directionFromMeToTarget.z);
        //directionFromMeToTarget.z = -1.0f * (directionFromMeToTarget.z);
        directionFromMeToTarget.y = 0.0f; //remove y component, as we will rotate around axis
        //directionFromMeToTarget.x = Mathf.Abs(directionFromMeToTarget.x);
        //directionFromMeToTarget.x = -1.0f * (directionFromMeToTarget.x);


        Quaternion lookRotation = Quaternion.LookRotation(directionFromMeToTarget);

        carTransform.rotation = Quaternion.Lerp(carTransform.rotation, lookRotation, Time.deltaTime * degresPerSecond);
    }

    void updateTargetPosition()
    {
        if (carTransform.position == WayPoints[currentTargetPos].position)
        {
            currentTargetPos++;
        }

        if (carTransform.position == WayPoints[WayPoints.Count-1].position)
        {
            carTravelDone = true;
        }
    }
}
