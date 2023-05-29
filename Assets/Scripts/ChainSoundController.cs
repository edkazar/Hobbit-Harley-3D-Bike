using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSoundController : MonoBehaviour
{
    private AudioSource bikeChain;

    // Start is called before the first frame update
    void Start()
    {
        bikeChain = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(float pPitch)
    {
        bikeChain.pitch = pPitch;
        bikeChain.Play();
    }

    public void stopSound()
    {
        bikeChain.Stop();
    }
}
