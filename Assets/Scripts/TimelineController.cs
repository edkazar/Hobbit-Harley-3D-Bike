using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    [SerializeField] Transform playerTransform = null;
    [SerializeField] Transform WayPoint2 = null;
    
    public GameObject Timeline;
    public TestControllerManager testControllerScript;
    public GameObject wave;
    public GameObject wave2;
   

    private bool startBallRolling = true;
    public bool startRollingProcess = false;
    private GameObject ball;
    private SkinnedMeshRenderer visible;
    

    private List<Vector3> WayPoints;
    private int currentTargetPos;
    

    private Animator animator;


    void Start()
    {
        WayPoints = new List<Vector3>();
        GameObject manager = GameObject.Find("TestController");
        testControllerScript = manager.GetComponent<TestControllerManager>();

        currentTargetPos = 0;
    }

    void Update()
    {
      

        if (testControllerScript.waving && wave != null)
        {

            updateWave();
            
            
            testControllerScript.waving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayableDirector pd = Timeline.GetComponent<PlayableDirector>();
        if(pd != null)
        {
            pd.Play();
        }

       
    }

    void updateTargetPosition()
    {

        if (currentTargetPos < WayPoints.Count - 1)
        {
            currentTargetPos++;
        }

    }


    void updateWave()
    {

        if (!visible.enabled)
        {
            PlayableDirector pd3 = wave2.GetComponent<PlayableDirector>();
            pd3.Play();
        }

        else
        {
           PlayableDirector pd2 = wave.GetComponent<PlayableDirector>();
           pd2.Play();
        }
    }
}
