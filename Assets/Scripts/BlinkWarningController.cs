using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkWarningController : MonoBehaviour
{
    [SerializeField]
    private GameObject LeftWarning;

    [SerializeField]
    private GameObject RightWarning;

    [SerializeField]
    private GameObject DownWarning;

    public void playLeftWarning()
    {
        LeftWarning.SetActive(true);
        Invoke(nameof(deactivateWarning), 3.0f);
    }

    public void playRightWarning()
    {
        RightWarning.SetActive(true);
        DownWarning.SetActive(true);
        Invoke(nameof(deactivateWarning), 3.0f);
    }

    private void deactivateWarning()
    {
        LeftWarning.SetActive(false);
        RightWarning.SetActive(false);
        DownWarning.SetActive(false);
    }
}
