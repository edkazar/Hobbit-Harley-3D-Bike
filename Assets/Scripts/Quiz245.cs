using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Quiz245 : MonoBehaviour, ISelectHandler
{

    public GameObject A1, A2, A3;
    public GameObject Q2, Q4, Q5;
    public GameObject Q2re, Q4re, Q5re;

    public AudioSource source;
    public AudioClip correct;
    public AudioClip wrong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("selected");
    }
    public void Q2isCorrect()
    {
        if (A1)
        {
            Debug.Log("Q2correct");
            source.clip = correct;
            source.Play();
            Q2re.SetActive(true);
            Q2.SetActive(false);
        }
        else
        {
            source.clip = wrong;
            source.Play();
        }

       
    }
    public void Q4isCorrect()
    {
        if (A1)
        {
            Debug.Log("Q4correct");
            Q4re.SetActive(true);
            Q4.SetActive(false);
        }


    }
    public void Q5isCorrect()
    {
        if (A1)
        {
            Debug.Log("Q5correct");
            Q5re.SetActive(true);
            Q5.SetActive(false);
        }


    }
}
