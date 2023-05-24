using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDown245 : MonoBehaviour
{

    public GameObject o1, o2, o3;
    public void Dropdown(int index)
    {
        switch (index)
        {
            case 1: o1.SetActive(true); break;

        }
    }
}
