using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivewayCarMovementController : MonoBehaviour
{
    [SerializeField] Transform carTransform;
    private float movementSpeed = 3.0f;
    private int currentTargetPos;
    private bool carTravelDone = false;
    public bool startCarMovement = false;

    private List<Transform> WayPoints;

    // Start is called before the first frame update
    void Start()
    {
        WayPoints = new List<Transform>();
        WayPoints.Add(GameObject.Find("WayPointDrivewayCar2").transform);

        currentTargetPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!carTravelDone && startCarMovement)
        {
            //rotationRoutine();

            carTransform.position = Vector3.MoveTowards(carTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
            updateTargetPosition();
        }
    }

    void updateTargetPosition()
    {
        if (carTransform.position == WayPoints[currentTargetPos].position)
        {
            currentTargetPos++;
        }

        if (carTransform.position == WayPoints[WayPoints.Count - 1].position)
        {
            carTravelDone = true;
        }
    }
}
