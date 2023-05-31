using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz3 : MonoBehaviour
{
	public GameObject A1, A2, A3, A4, A5;
	public GameObject B1, B2, B3, B4, B5;
	public GameObject Q3re;
	public GameObject Q3;

	Vector2 Pos1, Pos2, Pos3, Pos4, Pos5;

	public AudioSource source;

	private TestControllerManager myTestManager;

	public AudioClip correct;
	public AudioClip wrong;
	bool A1C, A2C, A3C, A4C, A5C = false;
	bool first_time = true;
	// Start is called before the first frame update
	void Start()
	{
		Pos1 = A1.transform.position;
		Pos2 = A2.transform.position;
		Pos3 = A3.transform.position;
		Pos4 = A4.transform.position;
		Pos5 = A5.transform.position;

		source.Play();

		GameObject TestManager = GameObject.Find("TestController");
		myTestManager = TestManager.GetComponent<TestControllerManager>();
	}

	// Update is called once per frame
	void Update()
	{
		/*if (A1C && A2C && A3C && A4C && A5C)
		{

			Debug.Log("Q3correct");
		}*/
	}

	public void dragA1()
	{
		A1.transform.position = Input.mousePosition;
	}

	public void dragA2()
	{
		A2.transform.position = Input.mousePosition;
	}

	public void dragA3()
	{
		A3.transform.position = Input.mousePosition;
	}

	public void dragA4()
	{
		A4.transform.position = Input.mousePosition;
	}

	public void dragA5()
	{
		A5.transform.position = Input.mousePosition;
	}

	

	public void dropA1()
	{
		float Distance = Vector3.Distance(A1.transform.position, B1.transform.position);
		if (Distance < 20)
		{
			A1.transform.position = B1.transform.position;
			source.clip = correct;
			source.Play();
			A1C = true;
		}
		else
		{
			A1.transform.position = Pos1;
			source.clip = wrong;
			source.Play();
		}
	}
	public void dropA2()
	{
		float Distance = Vector3.Distance(A2.transform.position, B2.transform.position);
		if (Distance < 20)
		{
			A2.transform.position = B2.transform.position;
			source.clip = correct;
			source.Play();
			A2C = true;
		}
		else
		{
			A2.transform.position = Pos2;
			source.clip = wrong;
			source.Play();
		}
	}
	public void dropA3()
	{
		float Distance = Vector3.Distance(A3.transform.position, B3.transform.position);
		if (Distance < 20)
		{
			A3.transform.position = B3.transform.position;
			source.clip = correct;
			source.Play();
			A3C = true;
		}
		else
		{
			A3.transform.position = Pos3;
			source.clip = wrong;
			source.Play();
		}
	}
	public void dropA4()
	{
		float Distance = Vector3.Distance(A4.transform.position, B4.transform.position);
		if (Distance < 20)
		{
			A4.transform.position = B4.transform.position;
			source.clip = correct;
			source.Play();
			A4C = true;
		}
		else
		{
			A4.transform.position = Pos4;
			source.clip = wrong;
			source.Play();
		}
	}
	public void dropA5()
	{
		float Distance = Vector3.Distance(A5.transform.position, B5.transform.position);
		if (Distance < 20)
		{
			A5.transform.position = B5.transform.position;
			source.clip = correct;
			source.Play();
			A5C = true;
		}
		else
		{
			A5.transform.position = Pos5;
			source.clip = wrong;
			source.Play();
		}
	}
	public void Q3isCorrect()
	{
		if (A1C && A2C && A3C && A4C && A5C)
		{
			Q3.SetActive(false);
		}
	}
}

