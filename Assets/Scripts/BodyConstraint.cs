using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyConstraint : MonoBehaviour
{
    [SerializeField] private Transform rootObject, followObject;
    private float followY;
    public float fixedRotation = 0;

    [SerializeField] private MovementControllerScript myMovementController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myMovementController.getBikeMovement() > 0.0f)
        {
            followY = followObject.eulerAngles.y;
            rootObject.eulerAngles = new Vector3(fixedRotation, followY, fixedRotation);
        }   
    }
}
