using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeSounds : MonoBehaviour
{
    [SerializeField] private AudioSource bikeBrake;

    private void OnCollisionEnter(Collision collision)
    {
        bikeBrake.Play();
    }
}
