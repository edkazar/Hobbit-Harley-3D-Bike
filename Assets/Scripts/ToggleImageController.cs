using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImageController : MonoBehaviour
{
    Toggle m_Toggle;

    private bool firstTime = true;

    [SerializeField] private GameObject CorrectImage;
    [SerializeField] private GameObject IncorrectImage1;
    [SerializeField] private GameObject IncorrectImage2;

    private void Start()
    {
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
        });
    }
    void ToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            CorrectImage.SetActive(true);
            IncorrectImage1.SetActive(false);
            IncorrectImage2.SetActive(false);
        }
        else
        {
            CorrectImage.SetActive(false);
        }
    }
}
