using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWP7 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private MovementControllerScript myMovementController;

    void Start()
    {
        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        myMovementController.movementSpeed = 3.0f;
        //
    }
}
