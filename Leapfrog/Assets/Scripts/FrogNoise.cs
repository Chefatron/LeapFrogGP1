using UnityEngine;

public class FrogNoise : MonoBehaviour
{
    public AudioClip FrogAudioClip;
    public float interval = 5f;
    public AudioSource FrogAudioSource;
    private float CurrentNoiseTime = 0f;
    bool attackActive;
    
    void Start()
    {
        FrogAudioSource = GameObject.Find("FrogAudio").GetComponent<AudioSource>();       
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
