using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestControllerManager : MonoBehaviour
{
    [SerializeField] private Camera myCamera;

    private int testID;
    private MovementControllerScript myMovementController;
    private IntersectionCarMovement myIntersectionController;
    private UITaskController myUIController;
    private List<List<GameObject>> Tests;

    private int outerTestID;
    private int innerTestID;

    private int[] testsOrder = new int[] {2, 4, 1, 0, 1, 3, 1, 0 , 1, 2, 3, 2, 3}; // 0: right, 1: left, 2: face, 3: forward, 4: yield
    private string[] helpTexts = new string[] { "Before crossing a street, look to your right to make sure cars are not coming!",
                                                "Before crossing a street, look to your left to make sure cars are not coming!",
                                                "If a car is coming, make eye contact with the driver to ask for the right-of-way!",
                                                "You are doing great! Now keep going forward!",
                                                "Oops! There goes your ball! Cross the street to recover it!"};
    private int testOrderCounter;
    private int timeTaken;
    private int testTimeTaken;
    private int targetHelpTime;
    [SerializeField] private int targetTestTime;
    [SerializeField] private int watchDrivertargetTestTime;
    private int offset;

    [SerializeField] private Transform Ring1Pos;
    [SerializeField] private Transform Ring2Pos;
    [SerializeField] private Transform Ring3Pos;
    [SerializeField] private Transform Ring4Pos;

    [SerializeField] private GameObject HelpText;
    private Text helpTextField;

    private CarSpeedController mySpeedController;
    private const int stopMovementID = 1;

    private TimelineController myTimelineController;
    private bool RollingProcess;
    private bool firstTest = true;

    private int waitForCar;

    public int showReinforcement = 0;
    public GameObject Q3re;
    public GameObject Q6re;
    public GameObject Q7re;
    private bool first_time3 = true;
    private bool first_time6 = true;
    private bool first_time7 = true;

    public bool waving;
    public bool stopRenderBall = false;

    // Start is called before the first frame update
    void Start()
    {
        loadTests();
        outerTestID = 0;
        innerTestID = 0;

        testOrderCounter = 0;
        timeTaken = 0;
        testTimeTaken = 0;
        targetHelpTime = targetTestTime * 2;
        offset = 20;
        waitForCar = 0;

        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();

        GameObject IntController = GameObject.Find("IntersectionCarMovementController");
        myIntersectionController = IntController.GetComponent<IntersectionCarMovement>();

        //GameObject speedController = GameObject.Find("CarMovementController");
        //mySpeedController = speedController.GetComponent<CarSpeedController>();

        //GameObject UIController = GameObject.Find("UI_Checklist");
        //myUIController = UIController.GetComponent<UITaskController>();

        Transform waypoint2 = MovementController.transform.Find("WayPoint2");
        myTimelineController = waypoint2.GetComponent<TimelineController>();
        
        Transform hText = HelpText.transform.Find("FinalText");
        helpTextField = hText.GetComponent<Text>();
        HelpText.SetActive(false);

        waving = false;

    }

    // Update is called once per frame
    void Update()
    {
       if (myMovementController.startTest)
        {

            runTest();         
        }

        activateReinforcements();
    }


    void loadTests()
    {
        Tests = new List<List<GameObject>>();

        for (int i = 0; i < this.transform.childCount; i++)
        {
            List<GameObject> temp = new List<GameObject>();
            Transform child = this.transform.GetChild(i);

            for (int j = 0; j < child.childCount; j++)
            {
                temp.Add(child.GetChild(j).gameObject);
            }
            Tests.Add(temp);
        }

        for (int i = 0; i < Tests.Count; i++)
        {
            for (int j = 0; j < Tests[i].Count; j++)
            {
                Tests[i][j].SetActive(false);
            }
        }
    }

    void runTest()
    {
        testTimeTaken++;

        /*if(testTimeTaken >= targetHelpTime)
        {
            if(!myMovementController.getExperienceDone())
            {
                setText();
                HelpText.SetActive(true);
            } 
        }*/

        /*if(myTimelineController.startRollingProcess)
        {
            helpTextField.text = helpTexts[4];
            HelpText.SetActive(true);   
        }*/

        if (outerTestID < myMovementController.getWaypointsLength() - 1) // minus initial waypoint
        {
            Tests[outerTestID][innerTestID].SetActive(true);
            float mousePosX = Input.mousePosition.x;
            Vector3 screenPos = myCamera.WorldToScreenPoint(Tests[outerTestID][innerTestID].transform.position);

            if (testsOrder[testOrderCounter] == 0)
            {
                Vector3 toTarget = (Tests[outerTestID][innerTestID].transform.position - myCamera.transform.position).normalized;
                float dotProd = Vector3.Dot(toTarget, myCamera.transform.forward);

                if (screenPos.x + (offset * 10.0f) < mousePosX && dotProd > 0.35f)
                {
                    timeTaken++;
                }
                else
                {
                    timeTaken = 0;
                }
            }
            else if (testsOrder[testOrderCounter] == 1)
            {
                Vector3 toTarget = (Tests[outerTestID][innerTestID].transform.position - myCamera.transform.position).normalized;
                float dotProd = Vector3.Dot(toTarget, myCamera.transform.forward);

                if (screenPos.x - (offset * 10.0f) > mousePosX && dotProd > 0.25f)
                {
                    timeTaken++;
                }
                else
                {
                    timeTaken = 0;
                }
            }
            else if (testsOrder[testOrderCounter] == 2)
            {
                float mousePosY = Input.mousePosition.y;
                Vector3 ring1 = myCamera.WorldToScreenPoint(Ring1Pos.position);
                Vector3 ring2 = myCamera.WorldToScreenPoint(Ring2Pos.position);
                Vector3 ring3 = myCamera.WorldToScreenPoint(Ring3Pos.position);
                Vector3 ring4 = myCamera.WorldToScreenPoint(Ring4Pos.position);

                //if (mousePosX < anillo4.x + offset * 2 && mousePosX > anillo4.x - offset * 2 && mousePosY < anillo4.y + offset * 2 && mousePosY > anillo4.y - offset * 2)

                if ((mousePosX < ring1.x + offset * 2 && mousePosX > ring1.x - offset * 2 && mousePosY < ring1.y + offset * 2 && mousePosY > ring1.y - offset * 2) ||
                (mousePosX < ring2.x + offset * 2 && mousePosX > ring2.x - offset * 2 && mousePosY < ring2.y + offset * 2 && mousePosY > ring2.y - offset * 2) ||
                (mousePosX < ring3.x + offset * 2 && mousePosX > ring3.x - offset * 2 && mousePosY < ring3.y + offset * 2 && mousePosY > ring3.y - offset * 2) ||
                (mousePosX < ring4.x + offset*2 && mousePosX > ring4.x - offset*2 && mousePosY < ring4.y + offset*2 && mousePosY > ring4.y - offset*2))
                {
                    timeTaken++;

                    if (timeTaken >= watchDrivertargetTestTime)
                    {
                        //mySpeedController.changeMovementspeed(stopMovementID);
                        timeTaken = targetTestTime;
                        //waving = true;
                    }
                }
                else
                {
                    timeTaken = 0;
                }
            }
            else if (testsOrder[testOrderCounter] == 3)
            {
                float sentitivity = 3.0f;
                if (mousePosX < screenPos.x + (offset * sentitivity) && mousePosX > screenPos.x - (offset * sentitivity))
                {
                    timeTaken++;
                    if (timeTaken >= watchDrivertargetTestTime / 2)
                    {
                        timeTaken = targetTestTime;
                    }
                }
                else
                {
                    timeTaken = 0;
                }
            }
            else // == 4 --> yield
            {
                myIntersectionController.startCarMovement = true;
                waitForCar++;
                if(waitForCar >= 600)
                {
                    timeTaken = targetTestTime;
                    waitForCar = 0;
                }
                //StartCoroutine(yieldForCar());
            }

            if (timeTaken >= targetTestTime)
            {
                if(testsOrder[testOrderCounter] != 3)
                {
                    //myUIController.unhideCompleted();
                }

                Tests[outerTestID][innerTestID].SetActive(false);
                timeTaken = 0;
                testTimeTaken = 0;
                innerTestID++;
                testOrderCounter++;
                HelpText.SetActive(false);

                if (innerTestID >= Tests[outerTestID].Count)
                {
                    showReinforcement = 1;
                    innerTestID = 0;
                    outerTestID++;
                    myMovementController.setStartTestFalse();
                    //StartCoroutine(resumeCarMovement());
                }
            }
        }
    }

    private void activateReinforcements()
    {
        if (showReinforcement == 1 && first_time3)
        {
            Time.timeScale = 0f;
            Q3re.SetActive(true);
            first_time3 = false;
            showReinforcement = 0;
        }

        else if (showReinforcement == 1 && first_time6)
        {
            Time.timeScale = 0f;
            Q6re.SetActive(true);
            first_time6 = false;
            showReinforcement = 0;
        }

        else if (showReinforcement == 1 && first_time7)
        {
            Time.timeScale = 0f;
            Q7re.SetActive(true);
            first_time7 = false;
            showReinforcement = 0;
        }
    }

    IEnumerator waitForBall()
    {
        helpTextField.text = helpTexts[4];
        HelpText.SetActive(true);
        yield return new WaitForSeconds(5);
        firstTest = false;
        runTest();
    }

    IEnumerator resumeCarMovement()
    {
        if (!myMovementController.hasCrossed)
        {
            mySpeedController.justCrossed = true;
            yield return new WaitForSeconds(4);
            stopRenderBall = true;
            yield return new WaitForSeconds(1);
            mySpeedController.resetSpeed(false);
            yield return new WaitForSeconds(2);
            myMovementController.hasCrossed = true;  
        }
    }

    IEnumerator yieldForCar()
    {
        myIntersectionController.startCarMovement = true;
        yield return new WaitForSeconds(5);
    }

    void setText()
    {
        helpTextField.text = helpTexts[testsOrder[testOrderCounter]];
    }

   
}
