using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject welcomeElements;

    [SerializeField]
    private GameObject finalElements;

	[SerializeField]
	private GameObject Q1;
	[SerializeField]
	private GameObject Q1re;

	[SerializeField]Transform playerTransform;
	[SerializeField] GameObject hel;
	public Animator anim;

	[SerializeField] GameObject h1;
	[SerializeField] private GameObject h2;
	[SerializeField] private GameObject h3;
	[SerializeField] private GameObject h4;
	[SerializeField] private GameObject h5;
	[SerializeField] private GameObject h6;
	
	[SerializeField] Toggle option1;
	[SerializeField] Toggle option2;
	[SerializeField] Toggle option3;
	[SerializeField] Toggle option4;
	[SerializeField] Toggle option5;
	[SerializeField] Toggle option6;

	[SerializeField] GameObject oops;

	private Transform lastWayPoint;
	private Transform WayPtOne;

	private Animation helmet;

	private UITaskController myUIController;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}
    // Start is called before the first frame update
    void Start()
    {
        welcomeElements.SetActive(true);
        finalElements.SetActive(false);
		
		Q1.SetActive(false);
		Q1re.SetActive(false);
		startHalo();
		Time.timeScale = 0f;
		anim.SetBool("HelmetFloat", false);
		helmet = hel.GetComponent<Animation>();
		

		lastWayPoint = GameObject.Find("WayPoint13").transform;
		WayPtOne = GameObject.Find("WayPoint2").transform;

		//GameObject UIController = GameObject.Find("UI_Checklist");
        //myUIController = UIController.GetComponent<UITaskController>();
	}

    // Update is called once per frame
    void Update()
    {
		//beginHalo();
		
		if (playerTransform.position == lastWayPoint.position)
        {
            finalElements.SetActive(true);
            //myUIController.hideObjectives();
            Time.timeScale = 0f; 
        }

        
    }

    public void startExperience()
    {
		welcomeElements.SetActive(false);
        Time.timeScale = 1f;
	}

    public void endExperience()
    {
        Application.Quit();
    }

    public void Quiz1()
    {
		welcomeElements.SetActive(false);
		
		Q1.SetActive(true);
		Time.timeScale = 0f;
		oops.SetActive(false);
		beginHalo();
		Q1isCorrect();
        
    }

    public void restartQ1()
    {
		toggleOff();
		startHalo();
		oops.SetActive(false);

	}

    public void Q1isCorrect()
    {
		oops.SetActive(false);
		anim.SetBool("HelmetFloat", false);
		if (option1.isOn && option2.isOn && option3.isOn && option4.isOn && option5.isOn)
		{
            if (option6.isOn == false)
            {
                Debug.Log("Q1isCorrect");
				Q1.SetActive(false);
				Time.timeScale = 0f;
				anim.SetBool("HelmetFloat", true);
				Q1re.SetActive(true);
				//ui Q1remove
				//play animation 
				//ui reinforcement
			}
		}
		else
		{
			restartQ1();
			anim.SetBool("HelmetFloat", false);
			oops.SetActive(true);
			//show "The answer is wrong, try again."
		}

	}

	private void toggleOff()
	{
		option1.isOn = false;
		option2.isOn = false;
		option3.isOn = false;
		option4.isOn = false;
		option5.isOn = false;
		option6.isOn = false;
	}
    public void startHalo()
    {
		h1.SetActive(false);
		h2.SetActive(false);
		h3.SetActive(false);
		h4.SetActive(false);
		h5.SetActive(false);
		h6.SetActive(false);
	}

    public void beginHalo()
    {
		if (option1.isOn)
		{
			h1.SetActive(true);

		}
		else
		{
			h1.SetActive(false);
		}
			
		if (option2.isOn)
		{
			h2.SetActive(true);

		}
		else
		{
			h2.SetActive(false);
		}

		if (option3.isOn)
		{
			h3.SetActive(true);

		}
		else
		{
			h3.SetActive(false);
		}

		if (option4.isOn)
		{
			h4.SetActive(true);

		}
		else
		{
			h4.SetActive(false);
		}

		if (option5.isOn)
		{
			h5.SetActive(true);

		}
		else
		{
			h5.SetActive(false);
		}

		if (option6.isOn)
		{
			h6.SetActive(true);

		}
		else
		{
			h6.SetActive(false);
		}

	}
	
}
