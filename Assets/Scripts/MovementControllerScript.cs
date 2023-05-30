using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
	[SerializeField] Transform wheel1;
	[SerializeField] Transform wheel2;
	
	[SerializeField] public float movementSpeed = 1.0f;
	[SerializeField] float rotateSpeed = 1.0f;
	[SerializeField] private Vector3 TurnSpeed;

	public int currentTargetPos;

    private List<Transform> WayPoints;
	public ButtonManager buttonManager;

	public GameObject quiz2;
	public GameObject quiz3;
	public GameObject quiz4;
	public GameObject quiz5;
	public GameObject quiz6;
	public GameObject quiz7;

    public GameObject chain;

	public bool hasCrossed = false;
    public bool fulfilledTest = false;
    public bool startTest = false;

    private UITaskController myUIController;

    private bool experienceDone = false;
    private int degresPerSecond = 2;
    private float bikeMovement = 1.0f;

    private BlinkWarningController myWarningController;

    private CarSpeedController mySpeedController1;
    private CarSpeedController mySpeedController2;

    // Start is called before the first frame update
    void Start()
    {
        setStartTestFalse();

        //chain.SetActive(false);
        WayPoints = new List<Transform>();
        WayPoints.Add(GameObject.Find("WayPoint2").transform);
        WayPoints.Add(GameObject.Find("WayPoint3").transform);
        WayPoints.Add(GameObject.Find("WayPoint4").transform);
        WayPoints.Add(GameObject.Find("WayPoint5").transform);
        WayPoints.Add(GameObject.Find("WayPoint6").transform);
		WayPoints.Add(GameObject.Find("WayPoint7").transform);
		WayPoints.Add(GameObject.Find("WayPoint8").transform);
		WayPoints.Add(GameObject.Find("WayPoint9").transform);
		WayPoints.Add(GameObject.Find("WayPoint10").transform);
		WayPoints.Add(GameObject.Find("WayPoint11").transform);
        WayPoints.Add(GameObject.Find("WayPoint12").transform);
        WayPoints.Add(GameObject.Find("WayPoint13").transform);
        WayPoints.Add(GameObject.Find("WayPoint14").transform);
        WayPoints.Add(GameObject.Find("WayPoint15").transform);
        WayPoints.Add(GameObject.Find("WayPoint16").transform);
        WayPoints.Add(GameObject.Find("WayPoint17").transform);
        WayPoints.Add(GameObject.Find("WayPoint18").transform);
        WayPoints.Add(GameObject.Find("WayPoint19").transform);
        WayPoints.Add(GameObject.Find("WayPoint20").transform);
        WayPoints.Add(GameObject.Find("WayPoint21").transform);
        WayPoints.Add(GameObject.Find("WayPoint22").transform);
        WayPoints.Add(GameObject.Find("WayPoint23").transform);

        currentTargetPos = 0;

        GameObject WarningObject = GameObject.Find("WarningSymbols");
        myWarningController = WarningObject.GetComponent<BlinkWarningController>();

        GameObject SpeedObject1 = GameObject.Find("CarMovementController1");
        GameObject SpeedObject2 = GameObject.Find("CarMovementController2");
        mySpeedController1 = SpeedObject1.GetComponent<CarSpeedController>();
        mySpeedController2 = SpeedObject2.GetComponent<CarSpeedController>();

        //GameObject UIController = GameObject.Find("UI_Checklist");
        //myUIController = UIController.GetComponent<UITaskController>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationRoutine();

        //updateTurning();

        if(!experienceDone)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime * bikeMovement);
        }

        updateWheelRotate();
        
		updateTargetPosition();
    }

    /*void updateTurning()
    {
        
        if(playerTransform.position == WayPoints[0].position)
        {
			//playerTransform.rotation = WayPoints[currentTargetPos].rotation;
			playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
			buttonManager.Quiz1();
            if (playerTransform.rotation != WayPoints[1].rotation)
            {
				playerTransform.Rotate(TurnSpeed * Time.deltaTime);
				
			}
            else
            {
				playerTransform.Translate(rotateSpeed * 0.1f * Time.deltaTime, 0f, 0f);
			}

            
            buttonManager.Quiz1();
		}
		
        else if (playerTransform.position == WayPoints[0].position)
        {
			
		}

		else
		{
			playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime);
		}
       
	}*/

    private void rotationRoutine()
    {
        //playerTransform.LookAt(WayPoints[currentTargetPos].position);
        //playerTransform.LookAt(WayPoints[currentTargetPos].position);
        Vector3 directionFromMeToTarget = (playerTransform.position - WayPoints[currentTargetPos].position);

        directionFromMeToTarget.z = -1.0f * (directionFromMeToTarget.z);
        directionFromMeToTarget.y = 0.0f; //remove y component, as we will rotate around axis
        directionFromMeToTarget.x = Mathf.Abs(directionFromMeToTarget.x);
        if (currentTargetPos < 6)
        {
            Mathf.Abs(directionFromMeToTarget.x);
        }
        else
        {
            directionFromMeToTarget.x = -1.0f * (directionFromMeToTarget.x);
        }

        Quaternion lookRotation = Quaternion.LookRotation(directionFromMeToTarget);

        playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, lookRotation, Time.deltaTime * degresPerSecond);
    }

    void updateWheelRotate()
    {
		if (playerTransform.position != WayPoints[currentTargetPos].position)
		{
			wheel1.Rotate(360 * rotateSpeed * Time.deltaTime * bikeMovement, 0, 0);
			wheel2.Rotate(360 * rotateSpeed * Time.deltaTime * bikeMovement, 0, 0);
            //chain.SetActive(true);
		}
        else
        {
            //chain.SetActive(false);
        }
        
	}
    void updateTargetPosition()
    {
        if (playerTransform.position == WayPoints[currentTargetPos].position)
        {
			if (playerTransform.position == WayPoints[2].position)
			{
				Time.timeScale = 0f;
				quiz2.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);
			}

			else if (playerTransform.position == WayPoints[6].position )
            {
                bikeMovement = 0.0f;
                Time.timeScale = 0f;
				quiz3.SetActive(true);
                Invoke(nameof(timeContinue), 2.0f);

            }

            else if (playerTransform.position == WayPoints[8].position)
			{
				Time.timeScale = 0f;
				quiz4.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);

			}
            else if (playerTransform.position == WayPoints[12].position)
			{
				Time.timeScale = 0f;
				quiz5.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);


			}
            else if (playerTransform.position == WayPoints[15].position)
			{
                mySpeedController1.stopCars();
                mySpeedController2.stopCars();
                Time.timeScale = 0f;
				quiz6.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);

			}
            else if (playerTransform.position == WayPoints[19].position)
			{
				Time.timeScale = 0f;
				quiz7.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);


			}
			currentTargetPos++;
            /*if (fulfilledTest)
            {
                if (currentTargetPos < WayPoints.Count - 1)
                {
                    currentTargetPos++;
                    fulfilledTest = false;
                }
            }
            else
            {
                startTest = true;
                if (!myUIController.ongoingTest && currentTargetPos != 2 && currentTargetPos < 4)
                {
                    myUIController.showObjectives();
                    myUIController.ongoingTest = true;
                }
            }*/
        }

        if (playerTransform.position == WayPoints[WayPoints.Count-1].position)
        {
            experienceDone = true;
        }
    }

    public void setStartTestFalse()
    {
        startTest = false;
        fulfilledTest = true;
        bikeMovement = 1.0f;
        
        //myUIController.ongoingTest = false;
    }

    public int getWaypointsLength()
    {
        return WayPoints.Count;
    }

    public bool getExperienceDone()
    {
        return experienceDone;
    }

    public void timeContinue()
    {
		Time.timeScale = 1f;

        if(playerTransform.position == WayPoints[6].position)
        {
            startTest = true;
        }

    }

    public void timeContinueWarning()
    {
        Time.timeScale = 1f;
        Invoke(nameof(callWarning), 3.0f);
    }

    private void callWarning()
    {
        myWarningController.playRightWarning();
    }

    public float getBikeMovement()
    {
        return bikeMovement;
    }
}
