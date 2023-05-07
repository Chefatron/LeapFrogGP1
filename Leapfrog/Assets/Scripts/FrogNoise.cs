using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogNoise : MonoBehaviour
{
    public AudioClip FrogAudioClip;
    public float interval = 5f;
    public AudioSource FrogAudioSource;
    private float CurrentNoiseTime = 0f;
    
    void Start()
    {
        FrogAudioSource = GameObject.Find("FrogAudio").GetComponent<AudioSource>();
       //nvokeRepeating("PlayFrogNoise", interval, interval);
    }

    private void Update()
    {
        if(CurrentNoiseTime < interval)
        {
            CurrentNoiseTime += Time.deltaTime;
        }
        else
        {
            FrogAudioSource.Play();
            CurrentNoiseTime = 0f;
        }
    }
    

    public void StopSound(PlayerDeath playerDeath)
    {
        if(playerDeath == true) { 

            FrogAudioSource.Stop();
        }
    }
    
}
