using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWP2 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private MovementControllerScript myMovementController;

    private CameraRotations myCameraScript;

    void Start()
    {
        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();

        GameObject CameraController = GameObject.Find("Camera");
        myCameraScript = CameraController.GetComponent<CameraRotations>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        myMovementController.movementSpeed = 3.0f;
        myCameraScript.positionUpdated = true;
        //Player.transform.Rotate(Vector3.up * 45 * Time.deltaTime, Space.Self);
    }
}
