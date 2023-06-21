using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    private float movementSpeed = 1.5f;
    private float ratio = 350.0f;
    private int currentTargetPos;
    private bool movementDone = false;
    public bool startMovement = false;

    [SerializeField] private List<Transform> WayPoints;

    // Start is called before the first frame update
    void Start()
    {
        //WayPoints = new List<Transform>();

        currentTargetPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movementDone && startMovement)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, WayPoints[currentTargetPos].position, movementSpeed / ratio);
            updateTargetPosition();
        }
    }

    void updateTargetPosition()
    {
        if (objectToMove.position == WayPoints[currentTargetPos].position)
        {
            currentTargetPos++;
        }

        if (objectToMove.position == WayPoints[WayPoints.Count - 1].position)
        {
            movementDone = true;
        }
    }

    public void deactivateObject()
    {
        objectToMove.gameObject.SetActive(false);
    }
}
