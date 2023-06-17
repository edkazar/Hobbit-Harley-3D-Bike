using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint22Triggers : MonoBehaviour
{
    private ChainSoundController myChainSoundController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ChainController = GameObject.Find("ChainSoundManager");
        myChainSoundController = ChainController.GetComponent<ChainSoundController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        myChainSoundController.stopSound();
    }
}
